using System;

namespace DevStore.Domain
{
    public class Produto
    {
        public Produto()
        {

        }

        public int IDProduto { get; set; }

        public string Nome { get; set; }

        public double Valor { get; set; }

        public int Quantidade { get; set; }

        public int CategoriaID { get; set; }

        public virtual Categoria Categoria { get; set; }

        public override string ToString()
        {
            return this.Nome;
        }
    }
}
