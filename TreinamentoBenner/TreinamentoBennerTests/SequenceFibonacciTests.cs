using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TreinamentoBennerTests
{
    [TestClass]
    public class SequenceFibonacciTests
    {
        [TestMethod]
        public void OPrimeiroElementoDaSequenciaDeveSer0()
        {
            Assert.AreEqual(0, Fibonacci.Elemento(0));
        }

        [TestMethod]
        public void OSegundoElementoDaSequenciaDeveSer1()
        {
            Assert.AreEqual(1, Fibonacci.Elemento(1));
        }

        [TestMethod]
        public void OTerceiroElementoDaSequenciaDeveSer1()
        {
            Assert.AreEqual(1, Fibonacci.Elemento(2));
        }

        [TestMethod]
        public void OQuartoElementoDaSequenciaDeveSer2()
        {
            Assert.AreEqual(2, Fibonacci.Elemento(3));
        }
    }

    public static class Fibonacci
    {
        public static int Elemento(int posicao)
        {
            if (posicao == 0) return 0;
            if (posicao == 1) return 1;
            return Elemento(posicao - 2) + Elemento(posicao - 1);
        }
    }
}
