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
            swithcero();
        }

        public void swithcero()
        {
            switch (side)
            {
                case Side.black:
                    switch (Type)
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
                    switch (Type)
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
                            try
                            {
                                if (((Controler)main.contr).board[y - 1, x] == null)
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
                            }
                            catch { }
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
                            try
                            {
                                if (((Controler)main.contr).board[y - 1, x - 1].side == Side.black)
                                {
                                    Border highlith = new Border()
                                    {
                                        BorderThickness = new System.Windows.Thickness(5),
                                        BorderBrush = new SolidColorBrush(Colors.Red),
                                        Height = 1000 / 8,
                                        Width = 1000 / 8,
                                        Tag = new int[] { y - 1, x - 1 }
                                    };
                                    highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(take);

                                    main.field.Children.Add(highlith);
                                    Canvas.SetTop(highlith, (y - 1) * (1000 / 8) + 10);
                                    Canvas.SetLeft(highlith, (x - 1) * (1000 / 8) + 10);
                                }
                            }
                            catch { }
                            break;
                        case Side.black:
                            if (y == 1)
                            {
                                Border highlith = new Border()
                                {
                                    BorderThickness = new System.Windows.Thickness(5),
                                    BorderBrush = new SolidColorBrush(Colors.Green),
                                    Height = 1000 / 8,
                                    Width = 1000 / 8,
                                    Tag = new int[] { y + 2, x }
                                };
                                highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(move);

                                main.field.Children.Add(highlith);
                                Canvas.SetTop(highlith, (y + 2) * (1000 / 8) + 10);
                                Canvas.SetLeft(highlith, (x) * (1000 / 8) + 10);
                            }
                            try
                            {
                                if (((Controler)main.contr).board[y + 1, x] == null)
                                {
                                    Border highlith = new Border()
                                    {
                                        BorderThickness = new System.Windows.Thickness(5),
                                        BorderBrush = new SolidColorBrush(Colors.Green),
                                        Height = 1000 / 8,
                                        Width = 1000 / 8,
                                        Tag = new int[] { y + 1, x }
                                    };
                                    highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(move);

                                    main.field.Children.Add(highlith);
                                    Canvas.SetTop(highlith, (y + 1) * (1000 / 8) + 10);
                                    Canvas.SetLeft(highlith, (x) * (1000 / 8) + 10);

                                }
                            }
                            catch { }
                            try
                            {
                                if (((Controler)main.contr).board[y + 1, x + 1].side == Side.white)
                                {
                                    Border highlith = new Border()
                                    {
                                        BorderThickness = new System.Windows.Thickness(5),
                                        BorderBrush = new SolidColorBrush(Colors.Red),
                                        Height = 1000 / 8,
                                        Width = 1000 / 8,
                                        Tag = new int[] { y + 1, x + 1 }
                                    };
                                    highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(take);

                                    main.field.Children.Add(highlith);
                                    Canvas.SetTop(highlith, (y + 1) * (1000 / 8) + 10);
                                    Canvas.SetLeft(highlith, (x + 1) * (1000 / 8) + 10);
                                }
                            }
                            catch { }
                            try
                            {
                                if (((Controler)main.contr).board[y + 1, x - 1].side == Side.white)
                                {
                                    Border highlith = new Border()
                                    {
                                        BorderThickness = new System.Windows.Thickness(5),
                                        BorderBrush = new SolidColorBrush(Colors.Red),
                                        Height = 1000 / 8,
                                        Width = 1000 / 8,
                                        Tag = new int[] { y + 1, x - 1 }
                                    };
                                    highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(take);

                                    main.field.Children.Add(highlith);
                                    Canvas.SetTop(highlith, (y + 1) * (1000 / 8) + 10);
                                    Canvas.SetLeft(highlith, (x - 1) * (1000 / 8) + 10);
                                }
                            }
                            catch { }
                            break;
                    }
                    break;
                case FigureType.tower:
                    //x+
                    for(int d = x +1; d < (8); d++)
                    {
                        if (((Controler)main.contr).board[y, d] == null)
                        {
                            Border highlith = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Green),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { y, d }
                            };
                            highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(move);

                            main.field.Children.Add(highlith);
                            Canvas.SetTop(highlith, (y) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlith, (d) * (1000 / 8) + 10);
                        }
                        else if(((Controler)main.contr).board[y, d].side != side)
                        {
                            Border highlith = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Red),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { y, d }
                            };
                            highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(take);

                            main.field.Children.Add(highlith);
                            Canvas.SetTop(highlith, (y) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlith, (d) * (1000 / 8) + 10);

                            d = 7;
                        }
                        else if(((Controler)main.contr).board[y, d].side == side)
                        {
                            d = 7;
                        }
                    }

                    //x-
                    for (int d = x -1; d > -1; d--)
                    {
                        if (((Controler)main.contr).board[y, d] == null)
                        {
                            Border highlith = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Green),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { y, d }
                            };
                            highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(move);
                   
                            main.field.Children.Add(highlith);
                            Canvas.SetTop(highlith, (y) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlith, (d) * (1000 / 8) + 10);
                        }
                        else if (((Controler)main.contr).board[y, d].side != side)
                        {
                            Border highlith = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Red),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { y, d }
                            };
                            highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(take);
                   
                            main.field.Children.Add(highlith);
                            Canvas.SetTop(highlith, (y) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlith, (d) * (1000 / 8) + 10);
                   
                            d = -2;
                        }
                        else if(((Controler)main.contr).board[y, d].side == side)
                        {
                            d = -2;
                        }
                    }

                    //y+
                    for (int d = y +1; d < 8; d++)
                    {
                        if (((Controler)main.contr).board[d, x] == null)
                        {
                            Border highlith = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Green),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { d, x }
                            };
                            highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(move);

                            main.field.Children.Add(highlith);
                            Canvas.SetTop(highlith, (d) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlith, (x) * (1000 / 8) + 10);
                        }
                        else if (((Controler)main.contr).board[d, x].side != side)
                        {
                            Border highlith = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Red),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { d, x }
                            };
                            highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(take);

                            main.field.Children.Add(highlith);
                            Canvas.SetTop(highlith, (d) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlith, (x) * (1000 / 8) + 10);

                            d = 7;
                        }
                        else if (((Controler)main.contr).board[d, x].side == side)
                        {
                            d = 7;
                        }
                    }

                    //y-
                    for (int d = y - 1; d > -1; d--)
                    {
                        if (((Controler)main.contr).board[d, x] == null)
                        {
                            Border highlith = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Green),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { d, x }
                            };
                            highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(move);

                            main.field.Children.Add(highlith);
                            Canvas.SetTop(highlith, (d) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlith, (x) * (1000 / 8) + 10);
                        }
                        else if (((Controler)main.contr).board[d, x].side != side)
                        {
                            Border highlith = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Red),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { d, x }
                            };
                            highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(take);

                            main.field.Children.Add(highlith);
                            Canvas.SetTop(highlith, (d) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlith, (x) * (1000 / 8) + 10);

                            d = -2;
                        }
                        else if (((Controler)main.contr).board[d, x].side == side)
                        {
                            d = -2;
                        }
                    }
                    break;
            }
        }

        public void move(object sneder, System.Windows.Input.MouseButtonEventArgs e)
        {
            Border nol = (Border)sneder;
            if ((((int[])nol.Tag)[0] < 8 && ((int[])nol.Tag)[0] > -1) && (((int[])nol.Tag)[1] < 8 && ((int[])nol.Tag)[1] > -1))
            {
                ((Controler)main.contr).board[y, x] = null;
                ((Controler)main.contr).board[((int[])nol.Tag)[0], ((int[])nol.Tag)[1]] = this;

                main.log.Text += y + "_" + x + " ---> " + ((int[])nol.Tag)[0] + "_" + ((int[])nol.Tag)[1];
                y = ((int[])nol.Tag)[0];
                x = ((int[])nol.Tag)[1];
                ((Controler)main.contr).paint();

                if (Type == FigureType.pawn && (y == 0 || y == 7))
                {
                    Pawnchooser chooser = new Pawnchooser(this);
                    chooser.Show();
                    main.log.Text += " type_switch\n";
                }
                else
                {
                    main.log.Text += "\n";
                }
            }              
        }

        public void take(object sneder, System.Windows.Input.MouseButtonEventArgs e)
        {
            Border nol = (Border)sneder;
            
            main.log.Text += y + "_" + x + " ---> " + ((int[])nol.Tag)[0] + "_" + ((int[])nol.Tag)[1] + " take out";

            Figure nols = ((Controler)main.contr).board[((int[])nol.Tag)[0], ((int[])nol.Tag)[1]];
            ((Controler)main.contr).Figurelist.RemoveAt(((Controler)main.contr).Figurelist.IndexOf(nols));

            ((Controler)main.contr).board[y, x] = null;

            y = ((int[])nol.Tag)[0];
            x = ((int[])nol.Tag)[1];

            ((Controler)main.contr).board[((int[])nol.Tag)[0], ((int[])nol.Tag)[1]] = this;
            ((Controler)main.contr).paint();

            if (Type == FigureType.pawn && (y == 0 || y == 7))
            {
                Pawnchooser chooser = new Pawnchooser(this);
                chooser.Show();
                main.log.Text += " type_switch\n";
            }
            else
            {
                main.log.Text += "\n";
            }
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
