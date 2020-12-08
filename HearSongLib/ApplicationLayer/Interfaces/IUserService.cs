using DDD.Base.ApplicationLayer.Services;
using HearSongLib.ApplicationLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace HearSongLib.ApplicationLayer.Interfaces
{
    public interface IUserService : IApplicationService
    {
        void CreateUser(UserDto userDto);
        List<UserDto> GetAllPlayers();
    }
}
