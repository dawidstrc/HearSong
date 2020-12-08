using DDD.Base.DomainModelLayer.Events;
using DDD.Base.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HearSongLib.DomainModelLayer.Models
{
    public class Song: AggregateRoot
    {
        public string Title { get; protected set; }
        public Money UnitPrice { get; protected set; }
        public double AverageRating { get; protected set; }


        private List<Outcome> _outcomes;
        public IEnumerable<Outcome> Outcomes
        {
            get { return _outcomes.AsReadOnly(); }
        }

        public Song(Guid songId, string title, Money unitPrice, IDomainEventPublisher eventPublisher)
             : base(songId, eventPublisher)
        {
            if (string.IsNullOrEmpty(title)) throw new ArgumentNullException("Song title is empty.");
            if (unitPrice < Money.Zero) throw new ArgumentNullException("Unit price is less then zero.");

            this.Title = title;
            this.AverageRating = 0;
            this.UnitPrice = unitPrice;
            this._outcomes = new List<Outcome>();
        }

        public void UpdateRating(double averageRating)
        {
            this.AverageRating = averageRating;
        }

        public void ListenToASong(Guid userId, string userName, int time, DateTime created)
        {
            this.UpdateOutcome(userId, userName, time, created);
        }

        private void UpdateOutcome(Guid userId, string userName, int time, DateTime created)
        {
            Outcome o = new Outcome(userId, userName, time, created);
            this._outcomes.Add(o);

            this._outcomes.Sort((o1, o2) => o1.Compare(o2));

            if (this._outcomes.Count > 5) this._outcomes.RemoveRange(5, 1);
        }
    }
}
