using System;
using System.Collections.Generic;
using System.Text;

namespace HearSongConsole
{
    public class ScenarioTest
    {

        private ScenarioHelper _scenarioHelper;
        public ScenarioTest(ScenarioHelper scenarioHelper)
        {
            this._scenarioHelper = scenarioHelper;
        }

        public void Test()
        {

            Guid song1Id = _scenarioHelper.AddSong("Utwór muzyczny numer 1", 15m);
            Guid song2Id = _scenarioHelper.AddSong("Utwór muzyczny numer 2", 8m);
            Guid song3Id = _scenarioHelper.AddSong("Utwór muzyczny numer 3", 14m);
            _scenarioHelper.ShowSongs();

            Guid user1Id = _scenarioHelper.CreateUser("Sluchacz", "sluchacz@op.pl");
            Guid user2Id = _scenarioHelper.CreateUser("Jan Kontrabasista", "jankontr@domena.pl");
            Guid user3Id = _scenarioHelper.CreateUser("Eldorado", "eldorado@gmail.com");
            _scenarioHelper.ShowUsers();

            Guid hearId = _scenarioHelper.StartSong(song1Id, user1Id, DateTime.Now.AddHours(0).AddMinutes(0));

            Guid hear2Id = _scenarioHelper.StartSong(song3Id, user2Id, DateTime.Now.AddHours(0).AddMinutes(0));

            Guid hear3Id = _scenarioHelper.StartSong(song2Id, user3Id, DateTime.Now.AddHours(0).AddMinutes(0));


            _scenarioHelper.EndSong(hearId, song1Id, user1Id, DateTime.Now.AddHours(0).AddMinutes(10));
            _scenarioHelper.EndSong(hear2Id, song3Id, user2Id, DateTime.Now.AddHours(0).AddMinutes(15));
            _scenarioHelper.EndSong(hear3Id, song2Id, user3Id, DateTime.Now.AddHours(0).AddMinutes(8));

            _scenarioHelper.AddComment(song1Id, user1Id, DateTime.Now.AddHours(0).AddMinutes(15), 2, "Komentarz", "Zle skomponowany utwor");
            _scenarioHelper.AddComment(song1Id, user2Id, DateTime.Now.AddHours(0).AddMinutes(20), 5, "komentarz2", "Brawa dla artysty");

            _scenarioHelper.AddComment(song2Id, user2Id, DateTime.Now.AddHours(0).AddMinutes(10), 6, "Komentarz3", "Linia melodyczna mila dla ucha");
            _scenarioHelper.AddComment(song1Id, user1Id, DateTime.Now.AddHours(0).AddMinutes(15), 4, "Komentarz4", "Dobry utwor, ale za malo basu");
            _scenarioHelper.AddComment(song1Id, user1Id, DateTime.Now.AddHours(0).AddMinutes(15), 7, "Komentarz5", "Jakosciowy wokal");

            _scenarioHelper.ShowComments();


            _scenarioHelper.ShowSongs();
            _scenarioHelper.ShowHears();
        }
    }
}
