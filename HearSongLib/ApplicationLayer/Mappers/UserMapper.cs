using HearSongLib.ApplicationLayer.DTOs;
using HearSongLib.DomainModelLayer.Models;
using System.Linq;
using System.Collections.Generic;


namespace HearSongLib.ApplicationLayer.Mappers
{
    public class UserMapper
    {
        public List<UserDto> Map(IEnumerable<User> songs)
        {
            return songs.Select(s => Map(s)).ToList();
        }

        public UserDto Map(User u)
        {
            return new UserDto()
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email.Value,
            };
        }
    }
}
