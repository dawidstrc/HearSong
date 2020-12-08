using DDD.Base.DomainModelLayer.Interfaces;
using HearSongLib.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HearSongLib.DomainModelLayer.Interfaces
{
    public interface IHearSongUnitOfWork : IUnitOfWork, IDisposable
    {
        IRepository<User> UserRepository { get; }
        IRepository<Song> SongRepository { get; }
        IRepository<Hear> HearRepository { get; }
        ICommentRepository CommentRepository { get; }
    }
}
