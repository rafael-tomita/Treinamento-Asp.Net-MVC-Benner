using System.Collections.Generic;
using System.Linq;
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
    public class CidadeControllerTests
    {
        private static CidadeController GetCidadeController(IServiceCidade serviceCidade)
        {
            var controller = new CidadeController(serviceCidade);
            controller.ControllerContext = new ControllerContext(new RequestContext(), controller);
            return controller;
        }

        [TestMethod]
        public void Index_Get_AsksForIndexView()
        {
            var controller = GetCidadeController(new InMemoryServiceCidade());

            var result = (ViewResult)controller.Index();

            Assert.IsNotNull(result.ViewName);
        }

        [TestMethod]
        public void Index_Get_RetrieveAllCidadeFromRepository()
        {
            var cidade1 = CidadeFactory.Create(1, "Maringá", "PR");
            var cidade2 = CidadeFactory.Create(2, "Anta Gorda", "RS");

            var repository = new InMemoryServiceCidade();
            repository.Save(cidade1);
            repository.Save(cidade2);

            var controller = GetCidadeController(new InMemoryServiceCidade());

            var result = controller.AjaxList();

            var model = ((IEnumerable<Cidade>) result.Data).ToList();
            CollectionAssert.Contains(model, cidade1);
            CollectionAssert.Contains(model, cidade2);
        }

        [TestMethod]
        public void Create_Post_PutsValidCidadeIntoRepository()
        {
            var service = new InMemoryServiceCidade();
            var controller = GetCidadeController(service);
            var cidade = CidadeFactory.Create(1, "Maringá", "PR");

            controller.AjaxAdd(cidade);

            var cidades = service.All();
            Assert.IsTrue(cidades.Contains(cidade));
        }
    }
}
