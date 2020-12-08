using HearSongLib.ApplicationLayer.DTOs;
using HearSongLib.ApplicationLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HearSongConsole
{
    public class ScenarioHelper
    {
        private IUserService _userService;
        private ISongService _songService;
        private IHearService _hearService;

        public ScenarioHelper(IUserService userService, ISongService songService, IHearService hearService)
        {
            this._userService = userService;
            this._songService = songService;
            this._hearService = hearService;
        }

        public void ShowSongs()
        {
            // list all songs
            Console.WriteLine("\nSongs");
            Console.WriteLine("--------------------------------------\n");
            List<SongDto> songs = this._songService.GetAllSongs();
            foreach (SongDto song in songs)
            {
                Console.WriteLine($"Id:         '{song.Id}'");
                Console.WriteLine($"Title:       '{song.Title}'");
                Console.WriteLine($"Price:      '{song.UnitPrice}'");
                Console.WriteLine($"Average:    '{song.AverageRating}'");
                Console.WriteLine("--------------------------------------");
                foreach (OutcomeDto bonus in song.Outcomes)
                {
                    Console.WriteLine($"        Player:    '{bonus.User}'");
                    Console.WriteLine($"        Time:      '{bonus.Time}'");
                    Console.WriteLine($"       ------------------------------------");
                }
            }
        }

        public void ShowComments()
        {
            // list all songs
            Console.WriteLine("\nComments");
            Console.WriteLine("--------------------------------------\n");
            List<CommentDto> songs = this._songService.GetAllComments();
            foreach (CommentDto song in songs)
            {
                Console.WriteLine($"Id:         '{song.Id}'");
                Console.WriteLine($"Title:      '{song.Title}'");
                Console.WriteLine($"Text:       '{song.Text}'");
                Console.WriteLine($"Rating:     '{song.Rating}'");
                Console.WriteLine($"UserId:   '{song.UserId}'");
                Console.WriteLine($"SongId      '{song.SongId}'");
                Console.WriteLine("--------------------------------------");
            }
        }

        public void ShowUsers()
        {
            // list all users
            Console.WriteLine("\nUsers");
            Console.WriteLine("--------------------------------------\n");
            List<UserDto> users = this._userService.GetAllPlayers();
            foreach (UserDto user in users)
            {
                Console.WriteLine($"Id:     '{user.Id}'");
                Console.WriteLine($"Name:   '{user.Name}'");
                Console.WriteLine("--------------------------------------");
            }
        }

        public void ShowHears()
        {
            Console.WriteLine("\nHears");
            Console.WriteLine("**************************************");
            List<HearDto> hears = this._hearService.GetAllHears();
            foreach (HearDto hear in hears)
            {
                Console.WriteLine($"HearId:                '{hear.Id}'");
                Console.WriteLine($"UserId:               '{hear.UserId}'");
                Console.WriteLine("**************************************");
                Console.WriteLine($"UserName:             '{hear.UserName}'");
                Console.WriteLine("**************************************");
                Console.WriteLine($"SongId:                 '{hear.SongId}'");
                Console.WriteLine($"SongTitle:               '{hear.SongTitle}'");
                Console.WriteLine($"Total:                  '{hear.Total}'");
                Console.WriteLine($"Started:                '{hear.Started}'");
                Console.WriteLine($"Finished:               '{hear.Finished}'");
                Console.WriteLine($"Time: ->>>>>> '{hear.Time}'");
                Console.WriteLine("\n\n\n");
            }
        }

        public Guid AddSong(string title, decimal unitPrice)
        {
            Guid songId = Guid.NewGuid();
            SongDto songDto = new SongDto()
            {
                Id = songId,
                Title = title,
                UnitPrice = unitPrice,
            };
            this._songService.AddSong(songDto);
            return songId;
        }

        public Guid CreateUser(string name, string email)
        {
            Guid userId = Guid.NewGuid();
            UserDto userDto = new UserDto()
            {
                Id = userId,
                Name = name,
                Email = email,
            };
            this._userService.CreateUser(userDto);
            return userId;
        }

        public Guid StartSong(Guid songId, Guid userId, DateTime started)
        {
            Guid hearId = Guid.NewGuid();
            this._hearService.StartHear(hearId, songId, userId, started);

            return hearId;
        }

        public void EndSong(Guid hearId, Guid songId, Guid userId, DateTime finished)
        {
            this._hearService.StopHear(hearId, songId, userId, finished);
        }

        public void AddComment(Guid songId, Guid userId, DateTime created, int rating, string title, string text)
        {
            Guid id = Guid.NewGuid();
            CommentDto commentDto = new CommentDto()
            {
                Created = created,
                Id = id,
                Rating = rating,
                Title = title,
                Text = text,
            };
            this._songService.AddComment(commentDto, songId, userId);
        }

    }
}
