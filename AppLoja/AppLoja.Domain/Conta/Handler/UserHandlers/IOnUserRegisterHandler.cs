using AppLoja.Domain.Conta.Events.UserEvents;
using DomainNotificationHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLoja.Domain.Conta.Handler.UserHandlers
{
    public interface IOnUserRegisterHandler : IHandler<OnUserRegisteredEvent>
    {

    }
}
