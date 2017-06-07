using SpyUserControl.Domain.Models;
using SpyUserControl.Infraestructure.Data.Map;
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
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
    
        }
    }
}
