using DDD.Base.DomainModelLayer.Events;
using DDD.Base.DomainModelLayer.Services;
using HearSongLib.DomainModelLayer.Interfaces;
using HearSongLib.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HearSongLib.DomainModelLayer.Services
{
    public class AddCommentService : IDomainService
    {
        private IHearSongUnitOfWork _unitOfWork;
        private IDomainEventPublisher _domainEventPublisher;


        public AddCommentService(IHearSongUnitOfWork unitOfWork,
            IDomainEventPublisher domainEventPublisher)
        {
            this._unitOfWork = unitOfWork;
            this._domainEventPublisher = domainEventPublisher;
        }


        public void AddComment(Guid id, string title, string text, int rating, DateTime created, Song song, User user)
        {
            Comment comment = new Comment(id, title, text, rating, created, song.Id, user.Id, this._domainEventPublisher);

            double sum = this._unitOfWork.CommentRepository.GetSumOfRating(song.Id);
            long count = this._unitOfWork.CommentRepository.GetNumOfRating(song.Id);

            double avg = (sum + comment.Rating) / (count + 1);
            song.UpdateRating(avg);

            this._unitOfWork.CommentRepository.Insert(comment);
            this._unitOfWork.Commit();
        }
    }
}
