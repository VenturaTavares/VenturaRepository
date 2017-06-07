using DevStore.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStore.Infra.Mappings
{
   public class ProductsMap: EntityTypeConfiguration<Produto>
    {

        public ProductsMap()
        {
            ToTable("Produto");
            HasKey(x => x.IDProduto);

            Property(x => x.Nome).HasMaxLength(160).IsRequired();

            Property(x => x.Quantidade).IsRequired();

            Property(x => x.Valor).IsRequired();

            HasRequired(x => x.Categoria);

        }
    }
}
