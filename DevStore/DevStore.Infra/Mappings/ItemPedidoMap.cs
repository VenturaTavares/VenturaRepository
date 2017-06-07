using DevStore.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace DevStore.Infra.Mappings
{
    public class ItemPedidoMap : EntityTypeConfiguration<ItemPedido>
    {
        public ItemPedidoMap()
        {
            ToTable("ItemPedido");
            HasKey(x => x.IDItemPedido);

            Property(x => x.ValorTotal).IsRequired();

            Property(x => x.ValorUnitario).IsRequired();

            Property(x => x.Quantidade).IsRequired();

            //relacionamentos N Produtos
            HasRequired(x => x.Produto)
                .WithMany()
                   .HasForeignKey(x => x.IDProduto);


            //relacionamentos N Carrinho
            HasRequired(x => x.Carrinho)
                .WithMany()
                .HasForeignKey(x => x.IDCarrinho);
               


        }

    }
}
