using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace KnightTour.Model
{
    public class CalculoMelhorLance
    {
        private List<Posicao> lancesFeitos;

        public Posicao PosicaoAtual { get {
                return lancesFeitos[lancesFeitos.Count - 1]; 
            }
        }


        public CalculoMelhorLance(Posicao lance)
        {
            lancesFeitos = new List<Posicao>();
            lancesFeitos.Add(lance);
        }

        public Posicao RetonarMelhorLance()
        {
            Posicao lanceCalculado = CalcularMelhorPosicao();
            
            return lanceCalculado;
        }

        public void RealizarLance(Posicao posicao)
        {
            lancesFeitos.Add(posicao);
        }

        private Posicao CalcularMelhorPosicao()
        {
            List<Posicao> lancesPossiveis = LancesPossiveisNaPosicao(PosicaoAtual);

            List<PosicaoPossibilidades> rankingLances = new List<PosicaoPossibilidades>();

            foreach(Posicao posicao in lancesPossiveis)
            {
                PosicaoPossibilidades pp = new PosicaoPossibilidades();
                pp.Posicao = posicao;
                pp.QuantidadeMovimentos = LancesPossiveisNaPosicao(posicao).Count - 1;

                rankingLances.Add(pp);
            }

            PosicaoPossibilidades melhorPosicao = rankingLances.OrderBy(p => { return p.QuantidadeMovimentos; }).FirstOrDefault();

            if (melhorPosicao == null)
            {
                return null;
            }

            return melhorPosicao.Posicao;


        }

        private List<Posicao> LancesPossiveisNaPosicao(Posicao posicao)
        {
            List<Posicao> lancesPossiveis = new Cavalo(posicao).Movimentos;
            lancesPossiveis.RemoveAll((p) => { return lancesFeitos.IndexOf(p) != -1; });
            return lancesPossiveis;
        }


        private class PosicaoPossibilidades {
            public Posicao Posicao;
            public int QuantidadeMovimentos;
        }

    }



}

