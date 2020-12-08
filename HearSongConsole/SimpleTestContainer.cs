using DDD.Base.DomainModelLayer.Events;
using DDD.Base.InfrastructureLayer;
using HearSongLib.ApplicationLayer.Interfaces;
using HearSongLib.ApplicationLayer.Mappers;
using HearSongLib.ApplicationLayer.Services;
using HearSongLib.DomainModelLayer.Events;
using HearSongLib.DomainModelLayer.Events.Listeners;
using HearSongLib.DomainModelLayer.Factories;
using HearSongLib.DomainModelLayer.Models;
using HearSongLib.DomainModelLayer.Services;
using HearSongLib.InfrastructureLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace HearSongConsole
{
    public class SimpleTestContainer
    {
        public IUserService UserService { get; }
        public ISongService SongService { get; }
        public IHearService HearService { get; }

        public SimpleTestContainer()
        {
            var domainEventPublisher = new SimpleEventPublisher();

            var emaildispatcher = new EmailDispatcher();

            var userCreatedEventListener = new UserCreatedEventListener(emaildispatcher);
            domainEventPublisher.Subscribe<UserCreatedEvent>(userCreatedEventListener);

            var unitOfWork = new MemoryHearSongUnitOfWork(
                new MemoryRepository<User>(),
                new MemoryRepository<Song>(),
                new MemoryRepository<Hear>(),
                new MemoryCommentRepository());

            var hearFactory = new HearFactory(domainEventPublisher);

            var addCommentService = new AddCommentService(
                unitOfWork,
                domainEventPublisher);

            var songMapper = new SongMapper();
            var userMapper = new UserMapper();
            var commentMapper = new CommentMapper();
            var hearMapper = new HearMapper();

            this.SongService = new SongService(
                unitOfWork,
                addCommentService,
                songMapper,
                commentMapper,
                domainEventPublisher);

            this.UserService = new UserService(
                unitOfWork,
                userMapper,
                domainEventPublisher);

            this.HearService = new HearService(
                unitOfWork,
                hearFactory,
                hearMapper,
                domainEventPublisher);
        }
    }
}
