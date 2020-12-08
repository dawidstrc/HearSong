using DDD.Base.DomainModelLayer.Events;
using DDD.Base.DomainModelLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace HearSongLib.DomainModelLayer.Events.Listeners
{
    public class UserCreatedEventListener: IEventListener<UserCreatedEvent>
    {
        private IEmailDispatcher _emailDispatcher;
        public UserCreatedEventListener(IEmailDispatcher emailDispatcher)
        {
            this._emailDispatcher = emailDispatcher;
        }

        public void Handle(UserCreatedEvent eventData)
        {
            string from = "HearSong@gmail.com";
            string to = eventData.Email;
            string subject = "New user created...";
            string body = "Activate user...";
            MailMessage mailMessage = new MailMessage(from, to, subject, body);

            this._emailDispatcher.Send(mailMessage);
        }
    }
}
