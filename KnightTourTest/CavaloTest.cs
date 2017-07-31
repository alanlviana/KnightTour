using KnightTour.Model;
using KnightTourTest.TestUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace KnightTourTest
{
    [TestClass]
    public class CavaloTest
    {
        [TestMethod]
        public void deveManterPosicaoDaPeca()
        {
            Posicao posicao = new Posicao("A", 1);
            Cavalo cavalo = new Cavalo(posicao);

            Assert.AreEqual(posicao, cavalo.Posicao);
        }

        [TestMethod]
        public void deveEmA1DeveRetornarC2eB3()
        {

            Cavalo cavalo = new Cavalo(Posicoes.A1);

            Assert.AreEqual(2, cavalo.Movimentos.Count);
            Assert.AreNotEqual(-1, cavalo.Movimentos.IndexOf(Posicoes.C2));
            Assert.AreNotEqual(-1, cavalo.Movimentos.IndexOf(Posicoes.B3));

        }

        [TestMethod]
        public void deveEmA2RetornarB4C3C1()
        {
            Cavalo cavalo = new Cavalo(Posicoes.A2);

            Assert.AreEqual(3, cavalo.Movimentos.Count);
            Assert.AreNotEqual(-1, cavalo.Movimentos.IndexOf(Posicoes.B4));
            Assert.AreNotEqual(-1, cavalo.Movimentos.IndexOf(Posicoes.C3));
            Assert.AreNotEqual(-1, cavalo.Movimentos.IndexOf(Posicoes.C1));

        }

        [TestMethod]
        public void deveEmE4RetornarG5G3F6F2D6D2C3C5()
        {
            Cavalo cavalo = new Cavalo(Posicoes.E4);

            Assert.AreEqual(8, cavalo.Movimentos.Count);

            Assert.AreNotEqual(-1, cavalo.Movimentos.IndexOf(Posicoes.G5));
            Assert.AreNotEqual(-1, cavalo.Movimentos.IndexOf(Posicoes.G3));

            Assert.AreNotEqual(-1, cavalo.Movimentos.IndexOf(Posicoes.F6));
            Assert.AreNotEqual(-1, cavalo.Movimentos.IndexOf(Posicoes.F2));

            Assert.AreNotEqual(-1, cavalo.Movimentos.IndexOf(Posicoes.D6));
            Assert.AreNotEqual(-1, cavalo.Movimentos.IndexOf(Posicoes.D2));

            Assert.AreNotEqual(-1, cavalo.Movimentos.IndexOf(Posicoes.C3));
            Assert.AreNotEqual(-1, cavalo.Movimentos.IndexOf(Posicoes.C5));

        }

        [TestMethod]
        public void deveEmH8RetornarF6G7()
        {
            Cavalo cavalo = new Cavalo(Posicoes.H8);

            Assert.AreEqual(2, cavalo.Movimentos.Count);

            Assert.AreNotEqual(-1, cavalo.Movimentos.IndexOf(Posicoes.F7));
            Assert.AreNotEqual(-1, cavalo.Movimentos.IndexOf(Posicoes.G6));

        }

        [TestMethod]
        public void deveEmA8RetornarB6C7()
        {
            Cavalo cavalo = new Cavalo(Posicoes.A8);

            Assert.AreEqual(2, cavalo.Movimentos.Count);

            Assert.AreNotEqual(-1, cavalo.Movimentos.IndexOf(Posicoes.B6));
            Assert.AreNotEqual(-1, cavalo.Movimentos.IndexOf(Posicoes.C7));

        }

        [TestMethod]
        public void deveEmH1RetornaG3F2()
        {
            Cavalo cavalo = new Cavalo(Posicoes.H1);

            Assert.AreEqual(2, cavalo.Movimentos.Count);

            Assert.AreNotEqual(-1, cavalo.Movimentos.IndexOf(Posicoes.G3));
            Assert.AreNotEqual(-1, cavalo.Movimentos.IndexOf(Posicoes.F2));

        }
    }


}
