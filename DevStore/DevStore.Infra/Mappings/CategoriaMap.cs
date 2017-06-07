using DevStore.Domain;
using System;
using System.Collections.Generic;

using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStore.Infra.Mappings
{
   public class CategoryMap :EntityTypeConfiguration<Categoria>

    {
        public CategoryMap()
        {
            ToTable("Categoria");
            HasKey(x => x.CategoriaID);
            Property(x => x.Nome).HasMaxLength(60).IsRequired();
        

        }
    }
}
