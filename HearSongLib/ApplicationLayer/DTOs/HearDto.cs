using System;
using System.Collections.Generic;
using System.Text;

namespace HearSongLib.ApplicationLayer.DTOs
{
    public class HearDto
    {
        public Guid Id { get; set; }
        public DateTime Started { get; set; }
        public DateTime? Finished { get; set; }
        public int Time { get; set; }
        public decimal Total { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public Guid SongId { get; set; }
        public string SongTitle { get; set; }
    }
}
