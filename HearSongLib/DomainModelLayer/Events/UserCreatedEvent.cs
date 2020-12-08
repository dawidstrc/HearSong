using DDD.Base.DomainModelLayer.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace HearSongLib.DomainModelLayer.Events
{
    public class UserCreatedEvent : IDomainEvent
    {
        public Guid UserId { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }

        public UserCreatedEvent(Guid id, string name, string email)
        {
            this.UserId = id;
            this.Name = name;
            this.Email = email;
        }
    }
}
