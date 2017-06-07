using SpyUserControl.Domain.Contracts.Repository;
using SpyUserControl.Domain.Models;
using SpyUserControl.Infraestructure.Data.Repositories;
using System;

namespace SpyUserControl
{
    class Program
    {
        static void Main(string[] args)
        {

            User User = new User("ventura.tavares2@gmail.com", "Bruno");

            using (IUserRepository userRep = new UserRepository())
            {
                userRep.Create(User);
            }

            using (IUserRepository userRep = new UserRepository())
            {

             var user =   userRep.Get("ventura.tavares2@gmail.com");

                Console.WriteLine(user.Name);
            }
          
        }
    }
}
