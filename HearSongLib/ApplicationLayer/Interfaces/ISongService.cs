using DDD.Base.ApplicationLayer.Services;
using HearSongLib.ApplicationLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace HearSongLib.ApplicationLayer.Interfaces
{
    public interface ISongService: IApplicationService
    {
        void AddSong(SongDto songDto);
        List<SongDto> GetAllSongs();
        void AddComment(CommentDto commentDto, Guid songId, Guid userId);
        List<CommentDto> GetAllComments();
    }
}
