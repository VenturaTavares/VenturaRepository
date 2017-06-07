using DevStore.Domain;
using DevStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStore.Service.DTO
{
    public class CompraDTO
    {
        public CompraDTO()
        {
            Carrinho = new Carrinho();
        }

        public Carrinho Carrinho { get; set; }
        public IEnumerable<Produto> ListaProdutos { get; set; }
        public IEnumerable<ItemPedido> ItensPedido { get; set; }
    }
}
