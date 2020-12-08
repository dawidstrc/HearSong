using DDD.Base.DomainModelLayer.Interfaces;
using HearSongLib.DomainModelLayer.Models;
using System;

namespace HearSongLib.DomainModelLayer.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
        double GetSumOfRating(Guid id);
        long GetNumOfRating(Guid id);
    }
}
