using DevStore.Domain.Models;
using DevStore.Service.Repositorio.Entidades;
using System.Transactions;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using DevStore.Domain;

namespace DevStore.Service
{
    public class CalculoBussiness
    {

        public Carrinho EfetuarCompra(int IDcarrinho,int TipoCompra)
        {


            Carrinho carrinho = new Carrinho();

            var CarrinhoService = new CarrinhoRepositorio();

            carrinho = CarrinhoService.ObteTodos().Where(s => s.IDCarrinho == IDcarrinho).First();

            carrinho.TipoCompra = TipoCompra;

            List<ItemPedido> ListaItemPedidos = new List<ItemPedido>();

            var ItemPedidoService = new ItemPedidoRepositorio();

            ListaItemPedidos = ItemPedidoService.Obter(s => s.IDCarrinho == IDcarrinho).ToList();

            carrinho.ValorCompra = this.ValorDaCompra(ListaItemPedidos.ToList());

            this.EfetuarBaixaNoEstoque(ListaItemPedidos);

            //CarrinhoService = new CarrinhoRepositorio();
            carrinho.CompraEfetuada = true;

            CarrinhoService.Atualizar(carrinho);

            CarrinhoService.Commit();

            carrinho.ItensPedido = ListaItemPedidos;

            return carrinho;
        }

        private double ValorDaCompra(List<ItemPedido> ItensPedidos)
        {

            double valorTotal = 0;

            foreach (var item in ItensPedidos)
            {
                valorTotal += item.ValorTotal;
            }

            return valorTotal;
        }

        private void EfetuarBaixaNoEstoque(List<ItemPedido> ItensPedidos)
        {

            var ProdutoService = new ProdutoRepositorio();

            var Produtos = ProdutoService.ObteTodos();
            foreach (var item in ItensPedidos)
            {
                var ProdutoBaixaEstoque = Produtos.Where(s => s.IDProduto == item.IDProduto).FirstOrDefault();
                ProdutoBaixaEstoque.Quantidade--;
                ProdutoService.Atualizar(ProdutoBaixaEstoque);
                ProdutoService.Commit();
            }
            ProdutoService.Dispose();
        }



        private List<ItemPedido> ObterItemPedido(int IDCarrinho)
        {

            List<ItemPedido> ListaItemPedidos = new List<ItemPedido>();

            using (var ItemPedidoService = new ItemPedidoRepositorio())
            {
                ListaItemPedidos = ItemPedidoService.Obter(s => s.IDCarrinho == IDCarrinho).ToList();
            }

            return ListaItemPedidos;
        }
    }
}
