using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KnightTour.Model;

namespace KnightTourTest
{
    [TestClass]
    public class TabuleiroTest
    {
        [TestMethod]
        public void deveCriarTabuleiroOitoPorOito()
        {
            Tabuleiro tabuleiro = new Tabuleiro(8, 8);


            Assert.AreEqual(8, tabuleiro.QuantidadeLinhas);
            Assert.AreEqual(8, tabuleiro.QuantidadeColunas);
        }
    }
}
