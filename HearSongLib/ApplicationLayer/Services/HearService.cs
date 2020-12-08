using DDD.Base.DomainModelLayer.Events;
using HearSongLib.ApplicationLayer.DTOs;
using HearSongLib.ApplicationLayer.Interfaces;
using HearSongLib.ApplicationLayer.Mappers;
using HearSongLib.DomainModelLayer.Factories;
using HearSongLib.DomainModelLayer.Interfaces;
using HearSongLib.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HearSongLib.ApplicationLayer.Services
{
    public class HearService: IHearService
    {
        private IHearSongUnitOfWork _unitOfWork;
        private HearFactory _hearFactory;
        private HearMapper _hearMapper;
        private IDomainEventPublisher _domainEventPublisher;

        public HearService(IHearSongUnitOfWork unitOfWork,
            HearFactory hearFactory,
            HearMapper hearMapper,
            IDomainEventPublisher domainEventPublisher)
        {
            this._unitOfWork = unitOfWork;
            this._hearFactory = hearFactory;
            this._hearMapper = hearMapper;
            this._domainEventPublisher = domainEventPublisher;
        }

        public void StartHear(Guid hearId, Guid songId, Guid userId, DateTime started)
        {
            Song song = this._unitOfWork.SongRepository.Get(songId)
                ?? throw new Exception($"Could not find room '{songId}'.");
            User user = this._unitOfWork.UserRepository.Get(userId)
                ?? throw new Exception($"Could not find player '{userId}'.");

            Hear hear = this._hearFactory.Create(hearId, started, song, user);

            this._unitOfWork.HearRepository.Insert(hear);
            this._unitOfWork.Commit();
        }

        public void StopHear(Guid hearId, Guid songId, Guid userId, DateTime finished)
        {
            Song song = this._unitOfWork.SongRepository.Get(songId)
                ?? throw new Exception($"Could not find song '{songId}'.");
            User user = this._unitOfWork.UserRepository.Get(userId)
                ?? throw new Exception($"Could not find user '{userId}'.");
            Hear hear = this._unitOfWork.HearRepository.Get(hearId)
                ?? throw new Exception($"Could not find hear '{hearId}'.");

            hear.StopHear(finished, song.UnitPrice);

            song.ListenToASong(user.Id, user.Name, hear.GetTimeInMinutes(), hear.Finished.Value);

            this._unitOfWork.Commit();

        }

        public List<HearDto> GetAllHears()
        {
            IList<Hear> hears = this._unitOfWork.HearRepository.GetAll();

            List<HearDto> result = this._hearMapper.Map(hears);

            foreach (HearDto h in result)
            {
                var user = this._unitOfWork.UserRepository.Get(h.UserId);
                var song = this._unitOfWork.SongRepository.Get(h.SongId);
                h.UserName = user.Name;
                h.SongTitle = song.Title;
                if (h.Finished.HasValue) h.Time = (h.Finished.Value - h.Started).Minutes;
            }

            return result;

        }
    }
}
