using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStore.Domain.Models
{
    public class ItemPedido
    {
        public int IDItemPedido { get; set; }
        public int IDCarrinho { get; set; }
        public int IDProduto { get; set; }
        public double ValorUnitario { get; set; }
        public double ValorTotal
        {
            get { return (this.ValorUnitario * this.Quantidade); }
            set { }
        }
        public double Quantidade { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual Carrinho Carrinho { get; set; }
    }
}
