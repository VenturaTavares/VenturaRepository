using DevStore.Domain;
using DevStore.Infra.DataContext;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DevStoreApi.Controllers
{
    [EnableCors(origins:"*",headers:"*",methods:"*")]
    [RoutePrefix("api/v1/public")]
    public class ProductsController : ApiController
    {
        private DevStoreDataContext db = new DevStoreDataContext();


        [Route("products")]
        public HttpResponseMessage GetProducts()
        {
            var result = db.Produtos.Include("Category").ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("categories")]
        public HttpResponseMessage GetCategories()
        {
            var result = db.Categorias.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("categories/{categoryId}/products")]
        public HttpResponseMessage GetProductsByCategories(int categoryId)
        {
            var result = db.Produtos.Include("Category").ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("products")]
        public HttpResponseMessage PostProduct(Produto product)
        {

            if (product == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Produtos.Add(product);
                db.SaveChanges();

                var result = product;

                return Request.CreateResponse(HttpStatusCode.OK, result);

            }
            catch (Exception)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }


        }

        [HttpPut]
        [Route("products")]
        public HttpResponseMessage PutProduct(Produto product)
        {

            if (product == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                db.Entry<Produto>(product).State = EntityState.Modified;
                db.SaveChanges();
                var result = product;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar o produto");
            }
        }

        [HttpPatch]
        [Route("products")]
        public HttpResponseMessage PatchProduct(Produto product)
        {

            if (product == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                db.Entry<Produto>(product).State = EntityState.Modified;
                db.SaveChanges();
                var result = product;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar o produto");
            }
        }
        [HttpDelete]
        [Route("products")]
        public HttpResponseMessage DeleteProduct(int ProductId)
        {

            if (ProductId <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "falha ao excluir produto");
            }

            try
            {
                db.Produtos.Remove(db.Produtos.Find(ProductId));
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Produto Excluído");
            }
            catch 
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "falha ao excluir produto");
            }
        }







        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}