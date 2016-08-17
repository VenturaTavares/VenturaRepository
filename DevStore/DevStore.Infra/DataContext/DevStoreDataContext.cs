using DevStore.Domain;
using DevStore.Infra.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStore.Infra.DataContext
{
    public class DevStoreDataContext : DbContext
    {
        public DevStoreDataContext()
            : base("DevStoreConnectionString")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
           //Database.SetInitializer(new DevStoreDataContextInitializer());
        }

        public IDbSet<Product> Products { get; set; }
        public IDbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductsMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            base.OnModelCreating(modelBuilder);
        }
    }

    public class DevStoreDataContextInitializer : DropCreateDatabaseIfModelChanges<DevStoreDataContext>
    {

        protected override void Seed(DevStoreDataContext context)
        {
            context.Categories.Add(new Category { Id = 1, Title = "Informática" });
            context.Categories.Add(new Category { Id = 2, Title = "Games" });
            context.Categories.Add(new Category { Id = 3, Title = "Papelaria" });
            context.SaveChanges();

            context.Products.Add(new Product { Id = 1, CategoryId = 1, IsActive = true, AcquireDate = DateTime.Now, Price = 12, Title = ".NET BOOK" });
            context.Products.Add(new Product { Id = 2, CategoryId = 1, IsActive = true, AcquireDate = DateTime.Now, Price = 2 , Title = "JAVA BOOK" });
            context.Products.Add(new Product { Id = 3, CategoryId = 1, IsActive = true, AcquireDate = DateTime.Now, Price = 1, Title = "RUBY BOOK" });

            context.Products.Add(new Product { Id = 4, CategoryId = 2, IsActive = true, AcquireDate = DateTime.Now, Price = 2000, Title = "PS4 " });
            context.Products.Add(new Product { Id = 5, CategoryId = 2, IsActive = true, AcquireDate = DateTime.Now, Price = 1500, Title = "XBOX ONE " });
            context.Products.Add(new Product { Id = 6, CategoryId = 2, IsActive = true, AcquireDate = DateTime.Now, Price = 800, Title = "WII U " });

            context.Products.Add(new Product { Id = 6, CategoryId = 3, IsActive = true, AcquireDate = DateTime.Now, Price = 12, Title = "CALCULADORA" });
            context.Products.Add(new Product { Id = 7, CategoryId = 3, IsActive = true, AcquireDate = DateTime.Now, Price = 2, Title = "CANETA" });
            context.Products.Add(new Product { Id = 8, CategoryId = 3, IsActive = true, AcquireDate = DateTime.Now, Price = 1, Title = "LÁPIS" });
            context.SaveChanges();
        }

    }
}
