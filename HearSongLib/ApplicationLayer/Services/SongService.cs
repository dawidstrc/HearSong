using DDD.Base.DomainModelLayer.Events;
using DDD.Base.DomainModelLayer.Models;
using HearSongLib.ApplicationLayer.DTOs;
using HearSongLib.ApplicationLayer.Interfaces;
using HearSongLib.ApplicationLayer.Mappers;
using HearSongLib.DomainModelLayer.Interfaces;
using HearSongLib.DomainModelLayer.Models;
using HearSongLib.DomainModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HearSongLib.ApplicationLayer.Services
{
    public class SongService: ISongService
    {
        private IHearSongUnitOfWork _unitOfWork;
        private AddCommentService _addCommentService;
        private SongMapper _songMapper;
        private CommentMapper _commentMapper;
        private IDomainEventPublisher _domainEventPublisher;

        public SongService(IHearSongUnitOfWork unitOfWork,
            AddCommentService addCommentService,
            SongMapper songMapper,
            CommentMapper commentMapper,
            IDomainEventPublisher domainEventPublisher)
        {
            this._unitOfWork = unitOfWork;
            this._addCommentService = addCommentService;
            this._songMapper = songMapper;
            this._commentMapper = commentMapper;
            this._domainEventPublisher = domainEventPublisher;
        }

        public void AddSong(SongDto songDto)
        {
            Expression<Func<Song, bool>> expressionPredicate = x => x.Title == songDto.Title;
            Song song = this._unitOfWork.SongRepository.Find(expressionPredicate).FirstOrDefault();
            if (song != null)
                throw new Exception($"Song '{songDto.Title}' already exists.");

            song = new Song(songDto.Id, songDto.Title, new Money(songDto.UnitPrice), this._domainEventPublisher);

            this._unitOfWork.SongRepository.Insert(song);
            this._unitOfWork.Commit();
        }

        public List<SongDto> GetAllSongs()
        {
            IList<Song> songs = this._unitOfWork.SongRepository.GetAll()
                ?? throw new Exception($"Could not find songs");

            List<SongDto> result = this._songMapper.Map(songs);

            return result;
        }

        public void AddComment(CommentDto commentDto, Guid songId, Guid userId)
        {

            Song song = this._unitOfWork.SongRepository.Get(songId)
                ?? throw new Exception($"Could not find song '{songId}'.");
            User user = this._unitOfWork.UserRepository.Get(userId)
                ?? throw new Exception($"Could not find user '{userId}'.");

            this._addCommentService.AddComment(commentDto.Id, commentDto.Title, commentDto.Text, commentDto.Rating, commentDto.Created, song, user);
        }

        public List<CommentDto> GetAllComments()
        {
            IList<Comment> comments = this._unitOfWork.CommentRepository.GetAll();

            List<CommentDto> result = this._commentMapper.Map(comments);
            return result;
        }
    }
}
