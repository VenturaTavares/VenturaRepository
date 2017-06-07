using Microsoft.Practices.Unity;
using SpyUserControl.Bussiness.Service;
using SpyUserControl.Domain.Contracts.Repository;
using SpyUserControl.Domain.Contracts.Services;
using SpyUserControl.Domain.Models;
using SpyUserControl.Infraestructure.Data;
using SpyUserControl.Infraestructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyUser.StartUp
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            container.RegisterType<AppDataContext, AppDataContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserService, UserService>(new HierarchicalLifetimeManager());
            container.RegisterType<User, User>(new HierarchicalLifetimeManager());
        }
    }
}
