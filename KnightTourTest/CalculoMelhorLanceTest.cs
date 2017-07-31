using KnightTour.Model;
using KnightTourTest.TestUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace KnightTourTest
{
    [TestClass]
    public class CalculoMelhorLanceTest
    {
        [TestMethod]
        public void deveReceberPrimeiraPosicaoPorParametro()
        {
            CalculoMelhorLance calculadora = new CalculoMelhorLance(Posicoes.B4);
        }

        [TestMethod]
        public void paraPrimeiroLanceE4DeveRetornarA2()
        {
            CalculoMelhorLance calculadora = new CalculoMelhorLance(Posicoes.B4);
            
            Assert.AreEqual(Posicoes.A2, calculadora.RetonarMelhorLance());
           
        }
        [TestMethod]
        public void paraPrimeiroLanceE4DeveRetornarA2C1()
        {
            CalculoMelhorLance calculadora = new CalculoMelhorLance(Posicoes.B4);

            Assert.AreEqual(Posicoes.A2, calculadora.RetonarMelhorLance());
            calculadora.RealizarLance(Posicoes.A2);
            Assert.AreEqual(Posicoes.C1, calculadora.RetonarMelhorLance());
        }

    }
}
