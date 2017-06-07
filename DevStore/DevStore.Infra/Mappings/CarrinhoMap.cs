using DevStore.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace DevStore.Infra.Mappings
{
    public class CarrinhoMap : EntityTypeConfiguration<Carrinho>
    {
        public CarrinhoMap()
        {
            ToTable("Carrinho");

            HasKey(x => x.IDCarrinho);

            Property(x => x.NomeCliente).IsRequired().HasMaxLength(80);

            Property(x => x.ValorCompra).IsRequired();

            Property(x => x.DataCompra).IsRequired();

        }

    }
}
