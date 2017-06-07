using DevStore.Domain;
using DevStore.Domain.Models;
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
            Configuration.LazyLoadingEnabled = true;
           //
            //Database.SetInitializer(new DevStoreDataContextInitializer());
        }

        public IDbSet<Produto> Produtos { get; set; }
        public IDbSet<Categoria> Categorias { get; set; }
        public IDbSet<ItemPedido> ItensPedido { get; set; }
        public IDbSet<Carrinho> Carrinhos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductsMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new CarrinhoMap());
            modelBuilder.Configurations.Add(new ItemPedidoMap());
            base.OnModelCreating(modelBuilder);
        }
    }

    public class DevStoreDataContextInitializer : DropCreateDatabaseIfModelChanges<DevStoreDataContext>
    {

        protected override void Seed(DevStoreDataContext context)
        {

        }

    }
}
