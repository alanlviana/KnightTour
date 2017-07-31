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
        private StackLayout[,] layoutsStack = new StackLayout[8, 8];

        public MainPage()
        {
            InitializeComponent();
            preencherTabuleiro();
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
                    fundoCelula.BackgroundColor = retornarCor(linha,coluna);
                    fundoCelula.VerticalOptions = LayoutOptions.FillAndExpand;
                    fundoCelula.HorizontalOptions = LayoutOptions.FillAndExpand;
                    
                    board.Children.Add(fundoCelula);
                    layoutsStack[linha, coluna] = fundoCelula;
                }
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

    }
}
