using HearSongLib.ApplicationLayer.DTOs;
using HearSongLib.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HearSongLib.ApplicationLayer.Mappers
{
    public class SongMapper
    {
        public List<SongDto> Map(IEnumerable<Song> songs)
        {
            return songs.Select(s => Map(s)).ToList();
        }

        public SongDto Map(Song song)
        {
            return new SongDto()
            {
                Id = song.Id,
                Title = song.Title,
                AverageRating = song.AverageRating,
                UnitPrice = song.UnitPrice.Amount,
                Outcomes = song.Outcomes.Select(o => Map(o)).ToList(),
            };
        }
        public OutcomeDto Map(Outcome o)
        {
            return new OutcomeDto()
            {
                Created = o.Created,
                Time = o.Time,
                User = o.User,
            };
        }

    }
}
