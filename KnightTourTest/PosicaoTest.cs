using KnightTour.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace KnightTourTest
{
    [TestClass]
    public class PosicaoTest
    {
        [TestMethod]
        public void deveManterAPosicaoConstrutor()
        {
            string coluna = "A";
            int linha = 1;

            Posicao posicao = new Posicao(coluna,linha);
            Assert.AreEqual("A", posicao.Coluna);
            Assert.AreEqual(1, posicao.Linha);
        }

        [TestMethod]
        public void deveFalharComLinhaMaiorQue8()
        {
            
            Assert.ThrowsException<ArgumentException>(() => { new Posicao("A", 9); });
        }
        [TestMethod]
        public void deveFalharComLinhaMenorQue1()
        {

            Assert.ThrowsException<ArgumentException>(() => { new Posicao("A", 0); });
        }

        [TestMethod]
        public void deveFalharComColunaNula()
        {
            Assert.ThrowsException<ArgumentException>(() => { new Posicao(null, 1); });
        }

        [TestMethod]
        public void deveFalharComColunaVazia()
        {
            Assert.ThrowsException<ArgumentException>(() => { new Posicao("", 1); });
        }

        [TestMethod]
        public void deveRetonarPosicaoLegivel()
        {
            Posicao posicao = new Posicao("A", 1);
            Assert.AreEqual("A1", posicao.ToString());
        }

        [TestMethod]
        public void deveAceitarColunaMinuscula()
        {
            Posicao posicao = new Posicao("a", 1);
        }

        [TestMethod]
        public void deveFalharComColunasDiferentesDeABCDEFGH()
        {
            Assert.ThrowsException<ArgumentException>(() => { new Posicao("8", 1); });
            Assert.ThrowsException<ArgumentException>(() => { new Posicao("Z", 1); });
            Assert.ThrowsException<ArgumentException>(() => { new Posicao("P", 1); });
            Assert.ThrowsException<ArgumentException>(() => { new Posicao("V", 1); });
            Assert.ThrowsException<ArgumentException>(() => { new Posicao("S", 1); });
            Assert.ThrowsException<ArgumentException>(() => { new Posicao("J", 1); });
            Assert.ThrowsException<ArgumentException>(() => { new Posicao("T", 1); });
        }

        [TestMethod]
        public void instanciasDiferentesDaMesmaPosicaoSaoAMesmaPosicao()
        {
            Posicao posicao1 = new Posicao("A", 1);
            Posicao posicao2 = new Posicao("A", 1);

            Assert.AreEqual(posicao1, posicao2);
        }

        [TestMethod]
        public void deveGerarA1AtravesDaCoordenada11()
        {
            Posicao posicaoA1 = Posicao.DaCoordenada(1,1);
            Assert.AreEqual("A1", posicaoA1.ToString());
        }

        public void deveRetornarCoordenada11ParaA1()
        {
            Posicao posicaoA1 = new Posicao("A", 1);
            Assert.AreEqual(1, posicaoA1.CoordenadaLinha);
            Assert.AreEqual(1, posicaoA1.CoordenadaColuna);
        }

    }
}
