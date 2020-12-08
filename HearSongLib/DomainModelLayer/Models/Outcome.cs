using DDD.Base.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HearSongLib.DomainModelLayer.Models
{
    public class Outcome: ValueObject
    {
        public string User { get; protected set; }
        public int Time { get; protected set; }
        public DateTime Created { get; protected set; }

        public Outcome(Guid userId, string userName, int time, DateTime created)
        {
            this.User = userName + " (" + userId + ")";
            this.Time = time;
            this.Created = created;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return User.ToUpper();
            yield return Time;
            yield return Created;
        }

        public int Compare(Outcome o)
        {
            return this.Time.CompareTo(o.Time);
        }

        public static bool operator <(Outcome m, Outcome m2)
        {
            return m.Time.CompareTo(m2.Time) < 0;
        }

        public static bool operator >(Outcome m, Outcome m2)
        {
            return m.Time.CompareTo(m2.Time) > 0;
        }

        public static bool operator >=(Outcome m, Outcome m2)
        {
            return m.Time.CompareTo(m2.Time) >= 0;
        }

        public static bool operator <=(Outcome m, Outcome m2)
        {
            return m.Time.CompareTo(m2.Time) <= 0;
        }
    }
}
