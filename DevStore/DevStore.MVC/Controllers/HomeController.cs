using DevStore.Domain;
using DevStore.Domain.Models;
using DevStore.Service;
using DevStore.Service.DTO;
using DevStore.Service.Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevStore.MVC.Controllers
{
    public class HomeController : Controller
    {


        // GET: Home
        public ActionResult Index(int? CarrinhoID)
        {
            CompraDTO Compra = new CompraDTO();

            if (CarrinhoID.HasValue)
            {
                var carrinho = this.ObterCarrinho(CarrinhoID.Value);

                if (carrinho.IDCarrinho == 0)
                {
                    return View(Compra);
                }

                var listaProdutos = this.ObterProdutos();
                Compra.Carrinho = carrinho;
                Compra.ListaProdutos = listaProdutos;
                Compra.ItensPedido = this.ObterItemPedido(CarrinhoID.Value);
            }

            return View(Compra);
        }

        [HttpPost]
        public ActionResult IncluirCarrinho(Carrinho carrinho)
        {
            try
            {

                var Produtoservice = new ProdutoRepositorio();
                var CarrinhoService = new CarrinhoRepositorio();
                CompraDTO Compra = new CompraDTO();

                CarrinhoService.Adicionar(carrinho);

                CarrinhoService.Commit();

                List<Produto> listaProdutos = ObterProdutos();

                Compra.Carrinho = carrinho;
                Compra.ItensPedido = new List<ItemPedido>();
                Compra.ListaProdutos = listaProdutos;

                return RedirectToAction("Index", new { CarrinhoID = carrinho.IDCarrinho });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private List<Produto> ObterProdutos()
        {

            var Produtoservice = new ProdutoRepositorio();

            var listaProdutos = Produtoservice.ObteTodos().ToList().Distinct().ToList();


            return listaProdutos;
        }

        private Carrinho ObterCarrinho(int IDCarrinho)
        {

            Carrinho Carrinho = new Carrinho();
            var CarrinhoService = new CarrinhoRepositorio();

            Carrinho = CarrinhoService.Obter(s => s.IDCarrinho == IDCarrinho).Where(s => s.CompraEfetuada == false).FirstOrDefault();

            return Carrinho;
        }

        private List<ItemPedido> ObterItemPedido(int IDCarrinho)
        {

            var ItemPedidoService = new ItemPedidoRepositorio();

            List<ItemPedido> ListaItemPedidos = ItemPedidoService.Obter(s => s.IDCarrinho == IDCarrinho).ToList();

            return ListaItemPedidos;
        }

        // GET: Home/Details/5
        [HttpGet]
        public JsonResult IncluirItemPedido(int IDProduto, int IDCarrinho)
        {

            try
            {
                var serviceItemPedido = new ItemPedidoRepositorio();

                var ProdutoService = new ProdutoRepositorio();
                var Produto = ProdutoService.Obter(s => s.IDProduto == IDProduto).FirstOrDefault();
                ProdutoService.Dispose();

                List<ItemPedido> ListaItemPedido;
                var ItemPedido = new ItemPedido();
                ItemPedido.IDProduto = Produto.IDProduto;
                ItemPedido.ValorTotal = Produto.Valor;
                ItemPedido.ValorUnitario = Produto.Valor;
                ItemPedido.IDCarrinho = IDCarrinho;
                serviceItemPedido.Adicionar(ItemPedido);
                serviceItemPedido.Commit();
                serviceItemPedido.Dispose();

                ListaItemPedido = this.ObterItemPedido(IDCarrinho);

                return Json(ListaItemPedido, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
        public ActionResult EfetuarCompraBoleto(int IDCarrinho)
        {

            try
            {

                var Calculo = new CalculoBussiness();
                var Carrinho = Calculo.EfetuarCompra(IDCarrinho, 1);
                if (Carrinho.IDCarrinho > 0)
                {
                    return View("DetalheCompra", Carrinho);
                }
                else
                {
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [HttpGet]
        public ActionResult EfetuarCompraCartao(int IDCarrinho)
        {

            try
            {
                var Calculo = new CalculoBussiness();
                var Carrinho = Calculo.EfetuarCompra(IDCarrinho, 2);
                if (Carrinho.IDCarrinho > 0)
                {
                    return View("DetalheCompra", Carrinho);
                }
                else
                {
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
        public JsonResult ExcluirItemPedido(int IDitemPedido, int IDCarrinho)
        {

            try
            {
                var serviceItemPedido = new ItemPedidoRepositorio();

                serviceItemPedido.Remover(IDitemPedido);

                serviceItemPedido.Commit();

                var ListaItemPedidos = this.ObterItemPedido(IDCarrinho);

                return Json(ListaItemPedidos, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
