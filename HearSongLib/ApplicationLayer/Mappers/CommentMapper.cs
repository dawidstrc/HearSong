using HearSongLib.ApplicationLayer.DTOs;
using HearSongLib.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HearSongLib.ApplicationLayer.Mappers
{
    public class CommentMapper
    {
        public List<CommentDto> Map(IEnumerable<Comment> comments)
        {
            return comments.Select(c => Map(c)).ToList();
        }

        public CommentDto Map(Comment comment)
        {
            return new CommentDto()
            {
                Id = comment.Id,
                Created = comment.Created,
                Rating = comment.Rating,
                Text = comment.Text,
                Title = comment.Title,
                SongId = comment.SongId,
                UserId = comment.UserId,
            };
        }
    }

}
