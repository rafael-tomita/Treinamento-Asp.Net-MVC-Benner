using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TreinamentoBennerTests
{
    [TestClass]
    public class StringHelperTests
    {
        [TestMethod]
        public void RegraPadrao()
        {
            Assert.AreEqual("bolas", "bola".ToPlural());
        }

        [TestMethod]
        public void QuandoTemTrocarParaTemComAcento()
        {
            Assert.AreEqual("têm", "tem".ToPlural());
        }

        [TestMethod]
        public void QuandoFinalELTrocarPorEis()
        {
            Assert.AreEqual("carteis", "cartel".ToPlural());
        }

        [TestMethod]
        public void QuandoDoisTresSeisOuDezNaoFazNada()
        {
            Assert.AreEqual("três", "três".ToPlural());
            Assert.AreEqual("dois", "dois".ToPlural());
            Assert.AreEqual("seis", "seis".ToPlural());
            Assert.AreEqual("dez", "dez".ToPlural());
        }

        [TestMethod]
        public void QuandoTerminadoEmEsTrocarPorEses()
        {
            Assert.AreEqual("meses", "mês".ToPlural());
        }

        [TestMethod]
        public void QuandoPalavraForExisteAdicionarM()
        {
            Assert.AreEqual("existem", "existe".ToPlural());
        }

        [TestMethod]
        public void QuandoTerminadoEmAoTrocarPorOes()
        {
            Assert.AreEqual("piões", "pião".ToPlural());
        }

        [TestMethod]
        public void QuandoTerminadoEmRZOuCanonAdicionarEs()
        {
            Assert.AreEqual("vorazes", "voraz".ToPlural());
            Assert.AreEqual("mares", "mar".ToPlural());
            Assert.AreEqual("canones", "canon".ToPlural());
        }

        [TestMethod]
        public void QuandoTerminadoEmOuTrocarPorOis()
        {
            Assert.AreEqual("sóis", "sol".ToPlural());
            Assert.AreEqual("anzóis", "anzol".ToPlural());
        }
    }
}
