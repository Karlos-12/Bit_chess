using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Bitchess
{
    internal class Controler
    {
        public List<Figure> Figurelist { get; set; }
        public Figure[,] board { get; set; }
        private MainWindow main;

        public Controler(MainWindow main)
        {
            this.main = main;
            Figurelist = new List<Figure>();
            board = new Figure[8,8];

            for (int i = 7; i >= 0; i--)
            {
                Figure non1 = new Figure(FigureType.pawn, Side.black, 1, i, "Black_pawn_" + i, main);
                Figurelist.Add(non1);
                board[0, i] = non1;
            }

            for (int i = 7; i >= 0; i--)
            {
                Figure non2 = new Figure(FigureType.pawn, Side.white, 6, i, "White_pawn_" + i, main);
                Figurelist.Add(non2);
                board[7, i] = non2;
            }

            paint();
        }

        public void paint()
        {
            main.field.Children.Clear();
            for(int c = Figurelist.Count - 1; c >= 0; c--)
            {
                main.field.Children.Add(Figurelist[c].image);
                Canvas.SetTop(Figurelist[c].image, Figurelist[c].y * (1000/8));
                Canvas.SetLeft(Figurelist[c].image, Figurelist[c].x * (1000/8));
            }
        }
    }
}
