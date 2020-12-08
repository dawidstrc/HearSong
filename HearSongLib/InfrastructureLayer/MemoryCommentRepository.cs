using HearSongLib.DomainModelLayer.Interfaces;
using HearSongLib.DomainModelLayer.Models;
using System;
using System.Linq;

namespace HearSongLib.InfrastructureLayer
{
    public class MemoryCommentRepository : MemoryRepository<Comment>, ICommentRepository
    {
        public double GetSumOfRating(Guid id)
        {
            return _entities
                .Where(x => x.Id == id)
                .Sum(x => x.Rating);
        }

        public long GetNumOfRating(Guid id)
        {
            return _entities
                .Where(x => x.Id == id)
                .Count();
        }
    }
}
