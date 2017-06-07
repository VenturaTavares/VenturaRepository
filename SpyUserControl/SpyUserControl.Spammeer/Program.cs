using Microsoft.Practices.Unity;
using SpyUser.StartUp;
using SpyUserControl.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpyUserControl.Spammeer
{
    class Program
    {
        static void Main(string[] args)
        {

            CultureInfo ci = new CultureInfo("pt-BR");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            var container = new UnityContainer();
            DependencyResolver.Resolve(container);
            var service = container.Resolve<IUserService>();
            try
            {
                service.Register("bozo", "bozo@gmail.com", "bozo321", "bozo321");
                Console.WriteLine("Usuário Cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
