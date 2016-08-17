using SpyUserControl.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyUserControl.Infraestructure.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext() 
            : base("AppConectionString")
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
