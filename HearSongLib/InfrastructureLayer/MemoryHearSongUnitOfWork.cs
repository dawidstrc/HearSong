using DDD.Base.DomainModelLayer.Interfaces;
using HearSongLib.DomainModelLayer.Interfaces;
using HearSongLib.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HearSongLib.InfrastructureLayer
{
    public class MemoryHearSongUnitOfWork : IHearSongUnitOfWork
    {
        public IRepository<User> UserRepository { get; protected set; }
        public IRepository<Song> SongRepository { get; protected set; }
        public IRepository<Hear> HearRepository { get; protected set; }
        public ICommentRepository CommentRepository { get; protected set; }

        public MemoryHearSongUnitOfWork(
            IRepository<User> userRepository,
            IRepository<Song> songRepository,
            IRepository<Hear> hearRepository,
            ICommentRepository commentRepository)
        {
            UserRepository = userRepository;
            SongRepository = songRepository;
            HearRepository = hearRepository;
            CommentRepository = commentRepository;
        }

        public MemoryHearSongUnitOfWork()
        {
            UserRepository = new MemoryRepository<User>();
            SongRepository = new MemoryRepository<Song>();
            HearRepository = new MemoryRepository<Hear>();
            CommentRepository = new MemoryCommentRepository();
        }

        public void Commit()
        { }
        public void Dispose()
        { }
        public void RejectChanges()
        { }
    }

}
