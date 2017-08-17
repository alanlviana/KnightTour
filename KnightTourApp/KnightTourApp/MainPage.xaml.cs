using KnightTour.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KnightTourApp
{
    public partial class MainPage : ContentPage
    {
        private ItemTabuleiro[,] itensTabuleiro = new ItemTabuleiro[8, 8];

        private CalculoMelhorLance calculadora;
        private bool SelecionarJogada = false;


        public MainPage()
        {
            InitializeComponent();
            preencherTabuleiro();
            btnComando.Clicked += BtnComando_Clicked;
        }

        private void BtnComando_Clicked(object sender, EventArgs e)
        {
            if (calculadora != null)
            {
                Posicao melhorLance = calculadora.RetonarMelhorLance();

                if (melhorLance == null)
                {
                    FinalizarJogo();
                    return;
                }

                PosicaoGrid posicaoGrid = new PosicaoGrid(melhorLance);
                itensTabuleiro[posicaoGrid.Row, posicaoGrid.Column].ImagemCavalo.IsVisible = true;
                calculadora.RealizarLance(melhorLance);


            }

            if (!SelecionarJogada && calculadora == null)
            {
                SelecionarJogada = true;
                btnComando.Text = "Selecione a Casa Inicial";
                btnComando.IsEnabled = false;
                return;
            }
        }

        private void FinalizarJogo()
        {
            DisplayAlert("Alerta!","Fim de Jogo","OK");
            calculadora = null;
            SelecionarJogada = false;
            btnComando.Text = "Reiniciar Jogo";
            btnComando.IsEnabled = true;
            foreach (ItemTabuleiro itemTabuleiro in itensTabuleiro)
            {
                itemTabuleiro.ImagemCavalo.IsVisible = false;
            }

        }

        public void preencherTabuleiro()
        {
            for (int linha = 0; linha < 8; linha++)
            {
                for (int coluna = 0; coluna < 8; coluna++)
                {

                    StackLayout fundoCelula = new StackLayout();
                    Grid.SetRow(fundoCelula, linha);
                    Grid.SetColumn(fundoCelula, coluna);

                    TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += (s, e) =>
                    {
                        StackLayout item = (StackLayout)s;
                        int row = Grid.GetRow(item);
                        int column = Grid.GetColumn(item);
                        processarClick(row,column);
                    };

                    fundoCelula.GestureRecognizers.Add(tapGestureRecognizer);

                    fundoCelula.BackgroundColor = retornarCor(linha,coluna);
                    fundoCelula.VerticalOptions = LayoutOptions.FillAndExpand;
                    fundoCelula.HorizontalOptions = LayoutOptions.FillAndExpand;

                    Image knightImg = new Image();
                    knightImg.Source = ImageSource.FromFile("knight.png");
                    knightImg.Margin = new Thickness(0, 5, 0, 0);
                    knightImg.VerticalOptions = LayoutOptions.Center;
                    knightImg.HorizontalOptions = LayoutOptions.Center;
                    knightImg.WidthRequest = 30;
                    knightImg.HeightRequest = 30;
                    knightImg.IsVisible = false;

                    fundoCelula.Children.Add(knightImg);
                    
                    board.Children.Add(fundoCelula);


                    itensTabuleiro[linha, coluna] = new ItemTabuleiro(fundoCelula,knightImg);
                }
            }
        }

        
        private void processarClick(int linha, int coluna)
        {
            if (SelecionarJogada)
            {
                Posicao posicao = convertePosicaoXadrez(linha, coluna);
                calculadora = new CalculoMelhorLance(posicao);

                itensTabuleiro[linha, coluna].ImagemCavalo.IsVisible = true;
                btnComando.Text = "Proxima Jogada";
                btnComando.IsEnabled = true;
                SelecionarJogada = false;
            }
        }

        private Color retornarCor(int linha, int coluna)
        {
            bool linhaPar = linha % 2 == 0;
            bool colunaPar = coluna % 2 == 0;
            if ((linhaPar & !colunaPar) || (!linhaPar & colunaPar))
            {
                return Color.Gray;
            }
            else
            {
                return Color.White;
            }
        }

        private class ItemTabuleiro
        {
            public StackLayout Fundo { get; private set; }
            public Image ImagemCavalo { get; private set; }

            public ItemTabuleiro(StackLayout fundo, Image imagemCavalo)
            {
                Fundo = fundo;
                ImagemCavalo = imagemCavalo;
            }
        }

        private Posicao convertePosicaoXadrez(int linha, int coluna)
        {
            string letraColuna = null;
            switch (coluna)
            {
                case 0:
                    letraColuna = "A";
                    break;
                case 1:
                    letraColuna = "B";
                    break;
                case 2:
                    letraColuna = "C";
                    break;
                case 3:
                    letraColuna = "D";
                    break;
                case 4:
                    letraColuna = "E";
                    break;
                case 5:
                    letraColuna = "F";
                    break;
                case 6:
                    letraColuna = "G";
                    break;
                case 7:
                    letraColuna = "H";
                    break;
                default:
                    throw new IndexOutOfRangeException("Tabuleiro Inválido");
            }
            linha = Math.Abs(linha - 8);

            return new Posicao(letraColuna, linha);
        }

        private class PosicaoGrid
        {
            public int Row { get; private set; }
            public int Column { get; private set; }

            public PosicaoGrid(Posicao posicaoXadrez)
            {
                Row = Math.Abs(posicaoXadrez.CoordenadaLinha - 8);
                Column = posicaoXadrez.CoordenadaColuna - 1;
            }
        }

    }
}
