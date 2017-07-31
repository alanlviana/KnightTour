using System;
using System.Collections.Generic;
using System.Text;

namespace KnightTour.Model
{
    class Cavalo
    {
        public Posicao Posicao { get; private set; }
        public List<Posicao> Movimentos { get; private set; }


        public Cavalo(Posicao posicao)
        {
            this.Posicao = posicao;

            Movimentos = new List<Posicao>();
            CalculaMovimentos();
        }
        
        private void CalculaMovimentos()
        {
            Movimentos.Clear();

            int coordenadaLinha = Posicao.CoordenadaLinha;
            int coordenadaColuna = Posicao.CoordenadaColuna;

            // Três Linhas para Cima
            adicionarMovimentoSeValido(coordenadaColuna+1, coordenadaLinha+2);
            adicionarMovimentoSeValido(coordenadaColuna-1, coordenadaLinha+2);

            // Uma Linha Para Cima
            adicionarMovimentoSeValido(coordenadaColuna + 2, coordenadaLinha + 1);
            adicionarMovimentoSeValido(coordenadaColuna - 2, coordenadaLinha + 1);

            // Três Linhas para Baixo
            adicionarMovimentoSeValido(coordenadaColuna + 1, coordenadaLinha - 2);
            adicionarMovimentoSeValido(coordenadaColuna - 1, coordenadaLinha - 2);

            // Uma Linha Para Baixo
            adicionarMovimentoSeValido(coordenadaColuna + 2, coordenadaLinha - 1);
            adicionarMovimentoSeValido(coordenadaColuna - 2, coordenadaLinha - 1);


        }

        private bool adicionarMovimentoSeValido(int coordenadaColuna, int coordenadaLinha)
        {
            try
            {
                Posicao posicaoParaAdicionar = Posicao.DaCoordenada(coordenadaColuna, coordenadaLinha);
                Movimentos.Add(posicaoParaAdicionar);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
