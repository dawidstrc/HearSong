using System;
using System.Collections.Generic;
using System.Text;

namespace HearSongLib.ApplicationLayer.DTOs
{
    public class SongDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal UnitPrice { get; set; }
        public double AverageRating { get; set; }
        public List<OutcomeDto> Outcomes { get; set; }
    }
}
