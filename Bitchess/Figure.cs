using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Bitchess
{
    internal class Figure
    {
        public string Name { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public FigureType Type { get; set; }
        public Side side { get; set; }
        private MainWindow main;

        public Figure(FigureType type, Side side, int y, int x, string name, MainWindow main)
        {
            this.Type = type;
            this.x = x;
            this.y = y;
            this.Name = name;
            this.side = side;
            this.main = main;

            image.MouseDown += new System.Windows.Input.MouseButtonEventHandler(piece_click);

            switch (side)
            {
                case Side.black:
                    switch (type)
                    {
                        case FigureType.pawn:
                            image.Source = new BitmapImage(new Uri("Images/blackbishop.png", UriKind.Relative));
                            break;
                        case FigureType.knight:
                            image.Source = new BitmapImage(new Uri("Images/blackhorse.png", UriKind.Relative));
                            break;
                        case FigureType.bishop:
                            image.Source = new BitmapImage(new Uri("Images/blackbishop.png", UriKind.Relative));
                            break;
                        case FigureType.king:
                            image.Source = new BitmapImage(new Uri("Images/blackking.png", UriKind.Relative));
                            break;
                        case FigureType.queen:
                            image.Source = new BitmapImage(new Uri("Images/blackqueen.png", UriKind.Relative));
                            break;
                        case FigureType.tower:
                            image.Source = new BitmapImage(new Uri("Images/Blacktower.png", UriKind.Relative));
                            break;
                    }
                    break;
                case Side.white:
                    switch (type)
                    {
                        case FigureType.pawn:
                            image.Source = new BitmapImage(new Uri("Images/whitepawn.png", UriKind.Relative));
                            break;
                        case FigureType.knight:
                            image.Source = new BitmapImage(new Uri("Images/whitehorse.png", UriKind.Relative));
                            break;
                        case FigureType.bishop:
                            image.Source = new BitmapImage(new Uri("Images/whitebishop.png", UriKind.Relative));
                            break;
                        case FigureType.king:
                            image.Source = new BitmapImage(new Uri("Images/white king.png", UriKind.Relative));
                            break;
                        case FigureType.queen:
                            image.Source = new BitmapImage(new Uri("Images/whiteking.png", UriKind.Relative));
                            break;
                        case FigureType.tower:
                            image.Source = new BitmapImage(new Uri("Images/whitetower.png", UriKind.Relative));
                            break;
                    }
                    break;
            }
        }

        public Image image = new Image()
        {
            Height = 150,
            Width = 150,
        };

        public void piece_click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            main.repaint();
            Border highlith = new Border()
            {
                BorderThickness = new System.Windows.Thickness(5),
                BorderBrush = new SolidColorBrush(Colors.Green),
                Height = 1000/8,
                Width = 1000/8
            };

            main.field.Children.Add(highlith);
            Canvas.SetTop(highlith, y*(1000/8) +10);
            Canvas.SetLeft(highlith, x*(1000/8) +10);
            posible();
        }

        public void posible()
        {
            switch(Type)
            {
                case FigureType.pawn:
                    switch(side)
                    {
                        case Side.white:
                            if(y == 6)
                            {
                                Border highlith = new Border()
                                {
                                    BorderThickness = new System.Windows.Thickness(5),
                                    BorderBrush = new SolidColorBrush(Colors.Green),
                                    Height = 1000 / 8,
                                    Width = 1000 / 8,
                                    Tag = new int[] {y-2, x}
                                };
                                highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(move);

                                main.field.Children.Add(highlith);
                                Canvas.SetTop(highlith, (y - 2) * (1000 / 8) + 10);
                                Canvas.SetLeft(highlith, (x) * (1000 / 8) + 10);
                            }
                            if (((Controler)main.contr).board[y-1, x] == null)
                            {
                                Border highlith = new Border()
                                {
                                    BorderThickness = new System.Windows.Thickness(5),
                                    BorderBrush = new SolidColorBrush(Colors.Green),
                                    Height = 1000 / 8,
                                    Width = 1000 / 8,
                                    Tag = new int[] { y - 1, x }
                                };
                                highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(move);

                                main.field.Children.Add(highlith);
                                Canvas.SetTop(highlith, (y - 1) * (1000 / 8) + 10);
                                Canvas.SetLeft(highlith, (x) * (1000 / 8) + 10);
                                
                            }
                            try
                            {
                                if (((Controler)main.contr).board[y - 1, x + 1].side == Side.black)
                                {
                                    Border highlith = new Border()
                                    {
                                        BorderThickness = new System.Windows.Thickness(5),
                                        BorderBrush = new SolidColorBrush(Colors.Red),
                                        Height = 1000 / 8,
                                        Width = 1000 / 8,
                                        Tag = new int[] { y - 1, x + 1 }
                                    };
                                    highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(take);

                                    main.field.Children.Add(highlith);
                                    Canvas.SetTop(highlith, (y - 1) * (1000 / 8) + 10);
                                    Canvas.SetLeft(highlith, (x + 1) * (1000 / 8) + 10);
                                }
                            }
                            catch { }
                            break;
                        case Side.black:


                            break;
                    }
                    break;
                case FigureType.tower:


                    break;
            }
        }

        public void move(object sneder, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        public void take(object sneder, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
    }

    public enum FigureType
    {
        pawn,
        knight,
        tower,
        bishop,
        queen,
        king
    }

    public enum Side
    {
        black,
        white
    }
}
