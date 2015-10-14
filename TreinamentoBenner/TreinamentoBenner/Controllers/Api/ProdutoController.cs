using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using TreinamentoBenner.Core.Model;
using TreinamentoBenner.Core.Service.Interfaces;

namespace TreinamentoBenner.Controllers.Api
{
    public class ProdutoController : ApiController
    {
        private readonly IServiceProduto serviceProduto;

        public ProdutoController(IServiceProduto serviceProduto)
        {
            this.serviceProduto = serviceProduto;
        }

        // GET: api/Produto
        public IQueryable<Produto> Get()
        {
            return serviceProduto.All(true);
        }

        // GET: api/Produto/5
        [ResponseType(typeof(Produto))]
        public IHttpActionResult Get(int id)
        {
            var produto = serviceProduto.Find(id);
            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        // POST: api/Produto
        public IHttpActionResult Put(Produto produto)
        {
            serviceProduto.Save(produto);

            return Ok(produto);
        }

        public void Post(Produto produto)
        {
            serviceProduto.Save(produto);
        }

        public void Delete(int id)
        {
            serviceProduto.Delete(id);
        }
    }
}
