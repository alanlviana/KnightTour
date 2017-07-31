using System;
using System.Collections.Generic;
using System.Text;

namespace KnightTour.Model
{
    public class Posicao
    {
        private readonly int LINHA_MAXIMA = 8;
        private readonly int LINHA_MINIMA = 1;
        private static string[] COLUNAS_PERMITIDAS = new string[8] { "A", "B", "C", "D", "E", "F", "G", "H" };
        
        public string Coluna { get; internal set; }
        public int Linha { get; internal set; }
        public int CoordenadaLinha { get {
                return Linha;
            }
        }
        public int CoordenadaColuna { get {
                return Array.IndexOf(COLUNAS_PERMITIDAS, Coluna) + 1;
            }
        }

        public Posicao(string coluna, int linha)
        { 

            if (linha > LINHA_MAXIMA)
            {
                throw new ArgumentException("A posição da linha não pode ser maior que " + LINHA_MAXIMA + ".");
            }

            if (linha < LINHA_MINIMA)
            {
                throw new ArgumentException("A posição da linha não pode ser menor que " + LINHA_MINIMA + ".");
            }

            if (string.IsNullOrWhiteSpace(coluna))
            {
                throw new ArgumentException("A coluna deve ser informada.");
            }

            coluna = coluna.ToUpper();

            if (Array.IndexOf(COLUNAS_PERMITIDAS,coluna) == -1)
            {
                throw new ArgumentException("Coluna Inválida.");
            }

            this.Coluna = coluna;
            this.Linha = linha;
        }

        public override string ToString()
        {
            return Coluna + Linha;
        }

        public override bool Equals(object obj)
        {
            if (obj is Posicao && obj != null)
            {
                return this.ToString().Equals((obj as Posicao).ToString());
            }

            return false ;
        }

        public static Posicao DaCoordenada(int coordenadaColuna, int coordenadaLinha)
        {
            string letraColuna = COLUNAS_PERMITIDAS[coordenadaColuna - 1];
            return new Posicao(letraColuna, coordenadaLinha);
        }
    }
}
