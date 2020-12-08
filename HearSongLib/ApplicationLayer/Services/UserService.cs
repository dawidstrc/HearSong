using DDD.Base.DomainModelLayer.Events;
using HearSongLib.ApplicationLayer.DTOs;
using HearSongLib.ApplicationLayer.Interfaces;
using HearSongLib.ApplicationLayer.Mappers;
using HearSongLib.DomainModelLayer.Interfaces;
using HearSongLib.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HearSongLib.ApplicationLayer.Services
{
    public class UserService: IUserService
    {
        private IHearSongUnitOfWork _unitOfWork;
        private UserMapper _userMapper;
        private IDomainEventPublisher _domainEventPublisher;

        public UserService(IHearSongUnitOfWork unitOfWork,
            UserMapper _userMapper,
            IDomainEventPublisher domainEventPublisher)
        {
            this._unitOfWork = unitOfWork;
            this._userMapper = _userMapper;
            this._domainEventPublisher = domainEventPublisher;
        }

        public void CreateUser(UserDto userDto)
        {
            Expression<Func<User, bool>> expressionPredicate = x => x.Name == userDto.Name;
            User user = this._unitOfWork.UserRepository.Find(expressionPredicate).FirstOrDefault();
            if (user != null)
                throw new Exception($"User '{userDto.Name}' already exists.");

            user = new User(userDto.Id, userDto.Name, userDto.Email, this._domainEventPublisher);

            this._unitOfWork.UserRepository.Insert(user);
            this._unitOfWork.Commit();
        }

        public List<UserDto> GetAllPlayers()
        {
            IList<User> users = this._unitOfWork.UserRepository.GetAll();

            List<UserDto> result = this._userMapper.Map(users);
            return result;
        }
    }
}
