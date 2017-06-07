using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStore.Domain.Models
{
    public class Carrinho
    {

        public Carrinho()
        {
            DataCompra = DateTime.Now;
        }

        public int IDCarrinho { get; set; }
        public string NomeCliente { get; set; }
        public DateTime DataCompra { get; set; }
        public bool CompraEfetuada { get; set; }

        //1 - Boleto 2- Cartão
        public int TipoCompra { get; set; }

        public double ValorCompra { get; set; }
        public virtual ICollection<ItemPedido> ItensPedido { get; set; }

    }


}
