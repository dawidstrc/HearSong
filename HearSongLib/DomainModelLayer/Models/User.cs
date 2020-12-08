using DDD.Base.DomainModelLayer.Events;
using DDD.Base.DomainModelLayer.Models;
using HearSongLib.DomainModelLayer.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace HearSongLib.DomainModelLayer.Models
{
    public class User: AggregateRoot
    {
        public string Name { get; protected set; }
        public Email Email { get; protected set; }
        public User(Guid userId, string name, string email, IDomainEventPublisher eventPublisher)
            : base(userId, eventPublisher)
        {
            if (String.IsNullOrEmpty(name)) throw new Exception("User name is null or empty");
            if (String.IsNullOrEmpty(email)) throw new Exception("Email name is null or empty");

            Name = name;
            Email = new Email(email);

            this.DomainEventPublisher.Publish(new UserCreatedEvent(this.Id, this.Name.ToString(), this.Email.Value));
        }
    }
}
