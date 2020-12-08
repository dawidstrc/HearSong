using DDD.Base.DomainModelLayer.Events;
using HearSongLib.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HearSongLib.DomainModelLayer.Factories
{
    public class HearFactory
    {
        private IDomainEventPublisher _domainEventPublisher;
        public HearFactory(IDomainEventPublisher domainEventPublisher)
        {
            this._domainEventPublisher = domainEventPublisher;
        }

        public Hear Create(Guid hearId, DateTime enterDateTime, Song song, User user)
        {
            return new Hear(hearId, song.Id, user.Id, enterDateTime, this._domainEventPublisher);
        }

    }
}
