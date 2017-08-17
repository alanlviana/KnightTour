using KnightTour.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KnightTourWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private CalculoMelhorLance calculadora;

        

        private Rectangle[,] retangulos = new Rectangle[8, 8];

        public MainWindow()
        {
            InitializeComponent();

            preencherTabuleiro();


        }


        private void preencherTabuleiro()
        {
            for (int linha = 0; linha < 8; linha++)
            {
                for (int coluna = 0; coluna < 8; coluna++)
                {

                    Rectangle retangulo = new Rectangle();
                    Border borda = new Border();
                    borda.BorderThickness = new Thickness(1); ;
                    borda.BorderBrush = new SolidColorBrush(Colors.White);
                    borda.Child = retangulo;
                    retangulo.MouseLeftButtonDown += (s, e) =>
                    {
                        int Column = Grid.GetColumn(s as Rectangle);
                        int Row = Grid.GetRow(s as Rectangle);

                        processaClick(Row, Column);

                    };
                    Grid.SetRow(borda, linha);
                    Grid.SetColumn(borda, coluna);
                    Grid.SetRow(retangulo, linha);
                    Grid.SetColumn(retangulo, coluna);

                    board.Children.Add(borda);
                    retangulo.Fill = new SolidColorBrush(retornarCor(linha, coluna));

                    retangulos[linha, coluna] = retangulo;
                }
            }
        }

        private Color retornarCor(int linha, int coluna)
        {
            bool linhaPar = linha % 2 == 0;
            bool colunaPar = coluna % 2 == 0;
            if ((linhaPar & !colunaPar) || (!linhaPar & colunaPar))
            {
                return Colors.Gray;
            }
            else
            {
                return Colors.White;
            }
        }

        private void processaClick(int Row, int Column)
        {
            Posicao posicao = convertePosicaoXadrez(Row, Column);
    
            if (calculadora == null)
            {
                calculadora = new CalculoMelhorLance(posicao);
            }
            else
            {
                Posicao posicaoLance = calculadora.RetonarMelhorLance();
                
                if (posicaoLance == null)
                {
                    MessageBox.Show("Fim de jogo");
                    return;
                }

                calculadora.RealizarLance(posicaoLance);

                PosicaoGrid posicaoGrid  = new PosicaoGrid(posicaoLance);
                Row = posicaoGrid.Row;
                Column = posicaoGrid.Column;
            }

            retangulos[Row, Column].Fill = new SolidColorBrush(Colors.Red);



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

        private class PosicaoGrid{
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
