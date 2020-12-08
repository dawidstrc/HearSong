using HearSongLib.ApplicationLayer.DTOs;
using HearSongLib.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HearSongLib.ApplicationLayer.Mappers
{
    public class HearMapper
    {
        public List<HearDto> Map(IEnumerable<Hear> hears)
        {
            return hears.Select(h => Map(h)).ToList();
        }

        public HearDto Map(Hear hear)
        {
            return new HearDto()
            {
                Id = hear.Id,
                Started = hear.Started,
                Finished = hear.Finished,
                Total = hear.Total.Amount,
                UserId = hear.UserId,
                SongId = hear.SongId,
            };
        }
    }
}
