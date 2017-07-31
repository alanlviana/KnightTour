using System;
using System.Collections.Generic;
using System.Text;

namespace KnightTour.Model
{
    public class Tabuleiro
    {
        public int QuantidadeLinhas { get; private set; }
        public int QuantidadeColunas { get; private set; }
        
        public Tabuleiro(int quantidadeLinhas, int quantidadeColunas)
        {
            this.QuantidadeLinhas = quantidadeLinhas;
            this.QuantidadeColunas = quantidadeColunas;
        }

        
    }
}
