using System;
using System.Collections.Generic;
using System.Text;

namespace HearSongLib.ApplicationLayer.DTOs
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public DateTime Created { get; set; }

        public Guid SongId { get; set; }
        public Guid UserId { get; set; }

    }
}
