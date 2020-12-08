using DDD.Base.ApplicationLayer.Services;
using HearSongLib.ApplicationLayer.DTOs;
using System;
using System.Collections.Generic;

namespace HearSongLib.ApplicationLayer.Interfaces
{
    public interface IHearService: IApplicationService
    {
        void StartHear(Guid hearId, Guid songId, Guid userId, DateTime started);
        void StopHear(Guid hearId, Guid songId, Guid userId, DateTime finished);
        List<HearDto> GetAllHears();
    
    }
}
