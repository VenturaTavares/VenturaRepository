using DevStore.Domain.Models;
using DevStore.Service.Interfaces.Entidades;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DevStore.Service.Repositorio.Entidades
{
    public class ItemPedidoRepositorio : Repositorio<ItemPedido>, ItemPedidoRepository
    {
        public override void Adicionar(ItemPedido entity)
        {

            var ProdutoService = new ProdutoRepositorio();
            var QuantidadeEstoque = ProdutoService.Obter(s => s.IDProduto == entity.IDProduto).FirstOrDefault().Quantidade;
            ProdutoService.Dispose();


            var ItensPedido = base.Obter(s => s.IDCarrinho == entity.IDCarrinho && s.IDProduto == entity.IDProduto).ToList();

            if (QuantidadeEstoque == 0)
            {
                return;
            }

            if (ItensPedido.Any())
            {
                ItemPedido ItemPedidoUpdate = ItensPedido.First();
                ItemPedidoUpdate.Quantidade++;
                base.Atualizar(ItemPedidoUpdate);
            }
            else
            {
                entity.Quantidade++;

                base.Adicionar(entity);
            }


        }

        public void Remover(int IDitemPedido)
        {

            var ItemPedido = base.Obter(s => s.IDItemPedido == IDitemPedido).FirstOrDefault();

            if (ItemPedido != null && ItemPedido.Quantidade > 1)
            {

                ItemPedido.Quantidade--;
                base.Atualizar(ItemPedido);
                base.Commit();
            }
            else
            {
                base.Deletar(s => s.IDItemPedido == IDitemPedido);
                base.Commit();
            }

        }



    }
}
