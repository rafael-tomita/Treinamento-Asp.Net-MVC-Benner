using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TreinamentoBenner.Controllers;
using TreinamentoBenner.Core.Model;
using TreinamentoBenner.Core.Service.Interfaces;
using TreinamentoBennerTests.Services;
using TreinamentoBennerTests.Stub;

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

        [TestMethod]
        public void Create_PostPutsValidPessoaIntoRepository()
        {
            var pessoa = PessoaStub.Valido();
            var result = controller.Create(pessoa) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, pessoa.Id);
        }

        [TestMethod]
        public void CreatePostPutsInvalidPessoaIntoRepository()
        {
            var pessoa = PessoaStub.Invalido();
            controller.ModelState.AddModelError("", "");

            var result = controller.Create(pessoa) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsFalse(controller.ModelState.IsValid);
            Assert.AreEqual(0, pessoa.Id);
        }

        [TestMethod]
        public void Create_Post_EditPessoaWithId1()
        {
            servicePessoa.Save(PessoaStub.Valido());

            const int idPessoa = 1;
            var result = controller.Create(idPessoa) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(idPessoa, ((Pessoa)result.Model).Id);
        }

        [TestMethod]
        public void OIndexDeveRetornarUmaViewComAModelDoTipoPessoa()
        {
            servicePessoa.Save(PessoaStub.Valido());

            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(IEnumerable<Pessoa>));
        }

        [TestMethod]
        public void ODeleteDoControllerDeveDeletarMesmo()
        {
            var pessoa = PessoaStub.Valido();
            servicePessoa.Save(pessoa);

            var result = controller.DeleteConfirmed(pessoa.Id) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestCleanup]
        public void CleanUp()
        {
            HttpContext.Current = null;
        }
    }
}
