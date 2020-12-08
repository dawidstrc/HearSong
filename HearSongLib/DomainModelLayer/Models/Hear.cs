using DDD.Base.DomainModelLayer.Events;
using DDD.Base.DomainModelLayer.Models;
using HearSongLib.DomainModelLayer.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace HearSongLib.DomainModelLayer.Models
{
    public class Hear: AggregateRoot
    {
        public DateTime Started { get; protected set; }
        public DateTime? Finished { get; protected set; }
        public Money Total { get; protected set; }
        public Guid UserId { get; protected set; }
        public Guid SongId { get; protected set; }
        public Hear(Guid hearId, Guid songId, Guid userId, DateTime started, IDomainEventPublisher eventPublisher)
            : base(hearId, eventPublisher)
        {
            this.Started = started;
            this.SongId = songId;
            this.UserId = userId;
            this.Total = Money.Zero;

            this.DomainEventPublisher.Publish<HearStartedEvent>(new HearStartedEvent(this.Id, this.SongId, this.UserId));
        }

        public void StopHear(DateTime finished, Money unitPrice)
        {
            if (finished < Started)
                throw new Exception($"Exit date and time is earlier than enter date and time.");

            this.Finished = finished;

            var timeInMinutes = (this.Finished.Value - this.Started).Minutes;
            Total = unitPrice.MultiplyBy(timeInMinutes);

            this.DomainEventPublisher.Publish<HearFinishedEvent>(new HearFinishedEvent(this.Id, this.SongId, this.UserId));
        }

        public int GetTimeInMinutes()
        {
            if (!this.Finished.HasValue) throw new Exception("Not finished hear");

            return (this.Finished.Value - this.Started).Minutes;
        }
    }
}
