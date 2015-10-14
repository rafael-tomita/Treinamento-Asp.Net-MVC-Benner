using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TreinamentoBenner.Controllers;
using TreinamentoBenner.Core.Model;
using TreinamentoBenner.Core.Service.Interfaces;
using TreinamentoBennerTests.Factories;
using TreinamentoBennerTests.Services;

namespace TreinamentoBennerTests.Controllers
{
    [TestClass]
    public class PessoaControllerTests
    {
        private PessoaController controller;
        private IServicePessoa servicePessoa;

        [TestInitialize]
        public void Setup()
        {
            //HttpContext.Current = SessionFactory.Create();
            servicePessoa = new InMemoryServicePessoa();
            controller = new PessoaController(servicePessoa, new InMemoryServiceCidade());
            controller.ControllerContext = new ControllerContext(new RequestContext(), controller);
        }

        [TestMethod]
        public void Create_Get_Pessoa()
        {
            var result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(Pessoa));
        }
    }
}
