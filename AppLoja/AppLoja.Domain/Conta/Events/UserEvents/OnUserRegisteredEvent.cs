
using AppLoja.Domain.Conta.Entidades;
using AppLoja.SharedKernel.Resources;
using DomainNotificationHelper.Events.Contracts;
using System;

namespace AppLoja.Domain.Conta.Events.UserEvents
{
    public class OnUserRegisteredEvent : IDomainEvent
    {

        public OnUserRegisteredEvent(User user)
        {
            User = user;
            Date = DateTime.Now;
            EmaiTitle = EmailTemplate.WelcomeEmailTitle;
            EmailBody = EmailTemplate.WelcomeEmailTitle; 
        }

        public User User { get; private set; }

        public string EmailBody { get; private set; }

        public string EmaiTitle { get; private set; }

        public DateTime Date { get; private set; }
    }
}
