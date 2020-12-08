using DDD.Base.DomainModelLayer.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace HearSongLib.DomainModelLayer.Events
{
    public class HearFinishedEvent : IDomainEvent
    {
        public Guid SongId { get; private set; }
        public Guid UserId { get; private set; }
        public Guid HearId { get; private set; }

        public HearFinishedEvent(Guid hearId, Guid songId, Guid userId)
        {
            this.HearId = hearId;
            this.SongId = songId;
            this.UserId = userId;
        }
    }
}
