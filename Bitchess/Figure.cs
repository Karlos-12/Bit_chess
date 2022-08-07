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
        System.Media.SoundPlayer soundPlayer;

        public Figure(FigureType type, Side side, int y, int x, string name, MainWindow main)
        {
            this.Type = type;
            this.x = x;
            this.y = y;
            this.Name = name;
            this.side = side;
            this.main = main;

             soundPlayer = new System.Media.SoundPlayer();

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
                            image.Source = new BitmapImage(new Uri("Images/blackpawn.png", UriKind.Relative));
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
                            image.Source = new BitmapImage(new Uri("Images/whiteking.png", UriKind.Relative));
                            break;
                        case FigureType.queen:
                            image.Source = new BitmapImage(new Uri("Images/whitequeen.png", UriKind.Relative));
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
            soundPlayer.SoundLocation = @"Sounds\figure select.wav";
            soundPlayer.Play();
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
                                if (((Controler)main.contr).board[y - 1, x] == null)
                                {
                                    Border highlith = new Border()
                                    {
                                        BorderThickness = new System.Windows.Thickness(5),
                                        BorderBrush = new SolidColorBrush(Colors.Green),
                                        Height = 1000 / 8,
                                        Width = 1000 / 8,
                                        Tag = new int[] { y - 2, x },
                                        Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                                    };
                                    highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(move);

                                    main.field.Children.Add(highlith);
                                    Canvas.SetTop(highlith, (y - 2) * (1000 / 8) + 10);
                                    Canvas.SetLeft(highlith, (x) * (1000 / 8) + 10);
                                }
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
                                        Tag = new int[] { y - 1, x },
                                        Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
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
                                        Tag = new int[] { y - 1, x + 1 },
                                        Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
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
                                        Tag = new int[] { y - 1, x - 1 },
                                        Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
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
                                if (((Controler)main.contr).board[y + 1, x] == null)
                                {
                                    Border highlith = new Border()
                                    {
                                        BorderThickness = new System.Windows.Thickness(5),
                                        BorderBrush = new SolidColorBrush(Colors.Green),
                                        Height = 1000 / 8,
                                        Width = 1000 / 8,
                                        Tag = new int[] { y + 2, x },
                                        Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                                    };
                                    highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(move);

                                    main.field.Children.Add(highlith);
                                    Canvas.SetTop(highlith, (y + 2) * (1000 / 8) + 10);
                                    Canvas.SetLeft(highlith, (x) * (1000 / 8) + 10);
                                }
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
                                        Tag = new int[] { y + 1, x },
                                        Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
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
                                        Tag = new int[] { y + 1, x + 1 },
                                        Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
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
                                        Tag = new int[] { y + 1, x - 1 },
                                        Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
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
                                Tag = new int[] { y, d },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
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
                                Tag = new int[] { y, d },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
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
                                Tag = new int[] { y, d },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
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
                                Tag = new int[] { y, d },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
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
                                Tag = new int[] { d, x },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
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
                                Tag = new int[] { d, x },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
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
                                Tag = new int[] { d, x },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
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
                                Tag = new int[] { d, x },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
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
                case FigureType.bishop:
                    //++
                    int _1 = y +1;
                    for (int d = x + 1; d < (8); d++)
                    {
                        if (_1 < 8 && _1 > -1)
                        {
                            
                            if (((Controler)main.contr).board[_1, d] == null)
                            {
                                Border highlith = new Border()
                                {
                                    BorderThickness = new System.Windows.Thickness(5),
                                    BorderBrush = new SolidColorBrush(Colors.Green),
                                    Height = 1000 / 8,
                                    Width = 1000 / 8,
                                    Tag = new int[] { _1, d },
                                    Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                                };
                                highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(move);

                                main.field.Children.Add(highlith);
                                Canvas.SetTop(highlith, (_1) * (1000 / 8) + 10);
                                Canvas.SetLeft(highlith, (d) * (1000 / 8) + 10);
                            }
                            else if (((Controler)main.contr).board[_1, d].side != side)
                            {
                                Border highlith = new Border()
                                {
                                    BorderThickness = new System.Windows.Thickness(5),
                                    BorderBrush = new SolidColorBrush(Colors.Red),
                                    Height = 1000 / 8,
                                    Width = 1000 / 8,
                                    Tag = new int[] { _1, d },
                                    Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                                };
                                highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(take);

                                main.field.Children.Add(highlith);
                                Canvas.SetTop(highlith, (_1) * (1000 / 8) + 10);
                                Canvas.SetLeft(highlith, (d) * (1000 / 8) + 10);

                                d = 7;
                            }
                            else if (((Controler)main.contr).board[_1, d].side == side)
                            {
                                d = 7;
                            }
                            _1++;
                        }
                        else d= 7;
                    }

                    //-+
                    int _4 = y -1;
                    for (int d = x + 1; d < 8; d++)
                    {
                        if (_4 > -1)
                        {

                            if (((Controler)main.contr).board[_4, d] == null)
                            {
                                Border highlith = new Border()
                                {
                                    BorderThickness = new System.Windows.Thickness(5),
                                    BorderBrush = new SolidColorBrush(Colors.Green),
                                    Height = 1000 / 8,
                                    Width = 1000 / 8,
                                    Tag = new int[] { _4, d },
                                    Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                                };
                                highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(move);

                                main.field.Children.Add(highlith);
                                Canvas.SetTop(highlith, (_4) * (1000 / 8) + 10);
                                Canvas.SetLeft(highlith, (d) * (1000 / 8) + 10);
                            }
                            else if (((Controler)main.contr).board[_4, d].side != side)
                            {
                                Border highlith = new Border()
                                {
                                    BorderThickness = new System.Windows.Thickness(5),
                                    BorderBrush = new SolidColorBrush(Colors.Red),
                                    Height = 1000 / 8,
                                    Width = 1000 / 8,
                                    Tag = new int[] { _4, d },
                                    Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                                };
                                highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(take);

                                main.field.Children.Add(highlith);
                                Canvas.SetTop(highlith, (_4) * (1000 / 8) + 10);
                                Canvas.SetLeft(highlith, (d) * (1000 / 8) + 10);

                                d = 8;
                            }
                            else if (((Controler)main.contr).board[_4, d].side == side)
                            {
                                d = 8;
                            }
                        }
                        else d = 8;
                        _4--;
                    }

                    //+-
                    int _3 = y +1;
                    for (int d = x - 1; d > -1; d--)
                    {
                        if (_3 < 8)
                        {
                            
                            if (((Controler)main.contr).board[_3, d] == null)
                            {
                                Border highlith = new Border()
                                {
                                    BorderThickness = new System.Windows.Thickness(5),
                                    BorderBrush = new SolidColorBrush(Colors.Green),
                                    Height = 1000 / 8,
                                    Width = 1000 / 8,
                                    Tag = new int[] { _3, d },
                                    Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                                };
                                highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(move);

                                main.field.Children.Add(highlith);
                                Canvas.SetTop(highlith, (_3) * (1000 / 8) + 10);
                                Canvas.SetLeft(highlith, (d) * (1000 / 8) + 10);
                            }
                            else if (((Controler)main.contr).board[_3, d].side != side)
                            {
                                Border highlith = new Border()
                                {
                                    BorderThickness = new System.Windows.Thickness(5),
                                    BorderBrush = new SolidColorBrush(Colors.Red),
                                    Height = 1000 / 8,
                                    Width = 1000 / 8,
                                    Tag = new int[] { _3, d },
                                    Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                                };
                                highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(take);

                                main.field.Children.Add(highlith);
                                Canvas.SetTop(highlith, (_3) * (1000 / 8) + 10);
                                Canvas.SetLeft(highlith, (d) * (1000 / 8) + 10);

                                d = -2;
                            }
                            else if (((Controler)main.contr).board[_3, d].side == side)
                            {
                                d = -2;
                            }
                        }
                        else d = -2;
                        _3++;
                    }

                    //--
                    int _2 = y -1;
                    for (int d = x - 1; d > -1; d--)
                    {
                        if (_2 > -1)
                        {

                            if (((Controler)main.contr).board[_2, d] == null)
                            {
                                Border highlith = new Border()
                                {
                                    BorderThickness = new System.Windows.Thickness(5),
                                    BorderBrush = new SolidColorBrush(Colors.Green),
                                    Height = 1000 / 8,
                                    Width = 1000 / 8,
                                    Tag = new int[] { _2, d },
                                    Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                                };
                                highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(move);

                                main.field.Children.Add(highlith);
                                Canvas.SetTop(highlith, (_2) * (1000 / 8) + 10);
                                Canvas.SetLeft(highlith, (d) * (1000 / 8) + 10);
                            }
                            else if (((Controler)main.contr).board[_2, d].side != side)
                            {
                                Border highlith = new Border()
                                {
                                    BorderThickness = new System.Windows.Thickness(5),
                                    BorderBrush = new SolidColorBrush(Colors.Red),
                                    Height = 1000 / 8,
                                    Width = 1000 / 8,
                                    Tag = new int[] { _2, d },
                                    Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                                };
                                highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(take);

                                main.field.Children.Add(highlith);
                                Canvas.SetTop(highlith, (_2) * (1000 / 8) + 10);
                                Canvas.SetLeft(highlith, (d) * (1000 / 8) + 10);

                                d = -2;
                            }
                            else if (((Controler)main.contr).board[_2, d].side == side)
                            {
                                d = -2;
                            }
                        }
                        else d = -2;
                        _2--;
                    }
                    break;
                case FigureType.queen:
                    //x+
                    for (int d = x + 1; d < (8); d++)
                    {
                        if (((Controler)main.contr).board[y, d] == null)
                        {
                            Border highlith = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Green),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { y, d },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
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
                                Tag = new int[] { y, d },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                            };
                            highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(take);

                            main.field.Children.Add(highlith);
                            Canvas.SetTop(highlith, (y) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlith, (d) * (1000 / 8) + 10);

                            d = 7;
                        }
                        else if (((Controler)main.contr).board[y, d].side == side)
                        {
                            d = 7;
                        }
                    }

                    //x-
                    for (int d = x - 1; d > -1; d--)
                    {
                        if (((Controler)main.contr).board[y, d] == null)
                        {
                            Border highlith = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Green),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { y, d },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
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
                                Tag = new int[] { y, d },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                            };
                            highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(take);

                            main.field.Children.Add(highlith);
                            Canvas.SetTop(highlith, (y) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlith, (d) * (1000 / 8) + 10);

                            d = -2;
                        }
                        else if (((Controler)main.contr).board[y, d].side == side)
                        {
                            d = -2;
                        }
                    }

                    //y+
                    for (int d = y + 1; d < 8; d++)
                    {
                        if (((Controler)main.contr).board[d, x] == null)
                        {
                            Border highlith = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Green),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { d, x },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
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
                                Tag = new int[] { d, x },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
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
                                Tag = new int[] { d, x },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
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
                                Tag = new int[] { d, x },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
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

                    //++
                    int _a = y + 1;
                    for (int d = x + 1; d < (8); d++)
                    {
                        if (_a < 8 && _a > -1)
                        {

                            if (((Controler)main.contr).board[_a, d] == null)
                            {
                                Border highlith = new Border()
                                {
                                    BorderThickness = new System.Windows.Thickness(5),
                                    BorderBrush = new SolidColorBrush(Colors.Green),
                                    Height = 1000 / 8,
                                    Width = 1000 / 8,
                                    Tag = new int[] { _a, d },
                                    Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                                };
                                highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(move);

                                main.field.Children.Add(highlith);
                                Canvas.SetTop(highlith, (_a) * (1000 / 8) + 10);
                                Canvas.SetLeft(highlith, (d) * (1000 / 8) + 10);
                            }
                            else if (((Controler)main.contr).board[_a, d].side != side)
                            {
                                Border highlith = new Border()
                                {
                                    BorderThickness = new System.Windows.Thickness(5),
                                    BorderBrush = new SolidColorBrush(Colors.Red),
                                    Height = 1000 / 8,
                                    Width = 1000 / 8,
                                    Tag = new int[] { _a, d },
                                    Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                                };
                                highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(take);

                                main.field.Children.Add(highlith);
                                Canvas.SetTop(highlith, (_a) * (1000 / 8) + 10);
                                Canvas.SetLeft(highlith, (d) * (1000 / 8) + 10);

                                d = 7;
                            }
                            else if (((Controler)main.contr).board[_a, d].side == side)
                            {
                                d = 7;
                            }
                            _a++;
                        }
                        else d = 7;
                    }

                    //-+
                    int _b = y - 1;
                    for (int d = x + 1; d < 8; d++)
                    {
                        if (_b > -1)
                        {

                            if (((Controler)main.contr).board[_b, d] == null)
                            {
                                Border highlith = new Border()
                                {
                                    BorderThickness = new System.Windows.Thickness(5),
                                    BorderBrush = new SolidColorBrush(Colors.Green),
                                    Height = 1000 / 8,
                                    Width = 1000 / 8,
                                    Tag = new int[] { _b, d },
                                    Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                                };
                                highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(move);

                                main.field.Children.Add(highlith);
                                Canvas.SetTop(highlith, (_b) * (1000 / 8) + 10);
                                Canvas.SetLeft(highlith, (d) * (1000 / 8) + 10);
                            }
                            else if (((Controler)main.contr).board[_b, d].side != side)
                            {
                                Border highlith = new Border()
                                {
                                    BorderThickness = new System.Windows.Thickness(5),
                                    BorderBrush = new SolidColorBrush(Colors.Red),
                                    Height = 1000 / 8,
                                    Width = 1000 / 8,
                                    Tag = new int[] { _b, d },
                                    Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                                };
                                highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(take);

                                main.field.Children.Add(highlith);
                                Canvas.SetTop(highlith, (_b) * (1000 / 8) + 10);
                                Canvas.SetLeft(highlith, (d) * (1000 / 8) + 10);

                                d = 8;
                            }
                            else if (((Controler)main.contr).board[_b, d].side == side)
                            {
                                d = 8;
                            }
                        }
                        else d = 8;
                        _b--;
                    }

                    //+-
                    int _c = y + 1;
                    for (int d = x - 1; d > -1; d--)
                    {
                        if (_c < 8)
                        {

                            if (((Controler)main.contr).board[_c, d] == null)
                            {
                                Border highlith = new Border()
                                {
                                    BorderThickness = new System.Windows.Thickness(5),
                                    BorderBrush = new SolidColorBrush(Colors.Green),
                                    Height = 1000 / 8,
                                    Width = 1000 / 8,
                                    Tag = new int[] { _c, d },
                                    Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                                };
                                highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(move);

                                main.field.Children.Add(highlith);
                                Canvas.SetTop(highlith, (_c) * (1000 / 8) + 10);
                                Canvas.SetLeft(highlith, (d) * (1000 / 8) + 10);
                            }
                            else if (((Controler)main.contr).board[_c, d].side != side)
                            {
                                Border highlith = new Border()
                                {
                                    BorderThickness = new System.Windows.Thickness(5),
                                    BorderBrush = new SolidColorBrush(Colors.Red),
                                    Height = 1000 / 8,
                                    Width = 1000 / 8,
                                    Tag = new int[] { _c, d },
                                    Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                                };
                                highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(take);

                                main.field.Children.Add(highlith);
                                Canvas.SetTop(highlith, (_c) * (1000 / 8) + 10);
                                Canvas.SetLeft(highlith, (d) * (1000 / 8) + 10);

                                d = -2;
                            }
                            else if (((Controler)main.contr).board[_c, d].side == side)
                            {
                                d = -2;
                            }
                        }
                        else d = -2;
                        _c++;
                    }

                    //--
                    int _d = y - 1;
                    for (int d = x - 1; d > -1; d--)
                    {
                        if (_d > -1)
                        {

                            if (((Controler)main.contr).board[_d, d] == null)
                            {
                                Border highlith = new Border()
                                {
                                    BorderThickness = new System.Windows.Thickness(5),
                                    BorderBrush = new SolidColorBrush(Colors.Green),
                                    Height = 1000 / 8,
                                    Width = 1000 / 8,
                                    Tag = new int[] { _d, d },
                                    Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                                };
                                highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(move);

                                main.field.Children.Add(highlith);
                                Canvas.SetTop(highlith, (_d) * (1000 / 8) + 10);
                                Canvas.SetLeft(highlith, (d) * (1000 / 8) + 10);
                            }
                            else if (((Controler)main.contr).board[_d, d].side != side)
                            {
                                Border highlith = new Border()
                                {
                                    BorderThickness = new System.Windows.Thickness(5),
                                    BorderBrush = new SolidColorBrush(Colors.Red),
                                    Height = 1000 / 8,
                                    Width = 1000 / 8,
                                    Tag = new int[] { _d, d },
                                    Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                                };
                                highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(take);

                                main.field.Children.Add(highlith);
                                Canvas.SetTop(highlith, (_d) * (1000 / 8) + 10);
                                Canvas.SetLeft(highlith, (d) * (1000 / 8) + 10);

                                d = -2;
                            }
                            else if (((Controler)main.contr).board[_d, d].side == side)
                            {
                                d = -2;
                            }
                        }
                        else d = -2;
                        _d--;
                    }
                    break;
                case FigureType.king:
                    //y-
                    try
                    {
                        int d = y - 1;
                        if (((Controler)main.contr).board[d, x] == null)
                        {
                            Border highlith = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Green),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { d, x },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                            };
                            highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(move);

                            main.field.Children.Add(highlith);
                            Canvas.SetTop(highlith, (d) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlith, (x) * (1000 / 8) + 10);
                        }

                        if (((Controler)main.contr).board[d, x ].side != side)
                        {
                            Border highlithh = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Red),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { d, x },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                            };
                            highlithh.MouseDown += new System.Windows.Input.MouseButtonEventHandler(take);

                            main.field.Children.Add(highlithh);
                            Canvas.SetTop(highlithh, (d) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlithh, (x) * (1000 / 8) + 10);
                        }                                    
                    }
                    catch { }

                    //y+
                    try
                    {
                        int d = y + 1;
                        if (((Controler)main.contr).board[d, x] == null)
                        {
                            Border highlith = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Green),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { d, x },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                            };
                            highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(move);

                            main.field.Children.Add(highlith);
                            Canvas.SetTop(highlith, (d) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlith, (x) * (1000 / 8) + 10);
                        }

                        if (((Controler)main.contr).board[d, x].side != side)
                        {
                            Border highlithh = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Red),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { d, x },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                            };
                            highlithh.MouseDown += new System.Windows.Input.MouseButtonEventHandler(take);

                            main.field.Children.Add(highlithh);
                            Canvas.SetTop(highlithh, (d) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlithh, (x) * (1000 / 8) + 10);
                        }
                    }
                    catch { }

                    //x-
                    try
                    {
                        int d = x -1;
                        if (((Controler)main.contr).board[y, d] == null)
                        {
                            Border highlith = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Green),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { y, d },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                            };
                            highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(move);

                            main.field.Children.Add(highlith);
                            Canvas.SetTop(highlith, (y) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlith, (d) * (1000 / 8) + 10);
                        }

                        if (((Controler)main.contr).board[y, d].side != side)
                        {
                            Border highlithh = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Red),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { y, d },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                            };
                            highlithh.MouseDown += new System.Windows.Input.MouseButtonEventHandler(take);

                            main.field.Children.Add(highlithh);
                            Canvas.SetTop(highlithh, (y) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlithh, (d) * (1000 / 8) + 10);
                        }
                    }
                    catch { }

                    //x+
                    try
                    {
                        int d = x + 1;
                        if (((Controler)main.contr).board[y, d] == null)
                        {
                            Border highlith = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Green),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { y, d },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                            };
                            highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(move);

                            main.field.Children.Add(highlith);
                            Canvas.SetTop(highlith, (y) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlith, (d) * (1000 / 8) + 10);
                        }

                        if (((Controler)main.contr).board[y, d].side != side)
                        {
                            Border highlithh = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Red),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { y, d },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                            };
                            highlithh.MouseDown += new System.Windows.Input.MouseButtonEventHandler(take);

                            main.field.Children.Add(highlithh);
                            Canvas.SetTop(highlithh, (y) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlithh, (d) * (1000 / 8) + 10);
                        }
                    }
                    catch { }

                    //x+ y+
                    try
                    {
                        int d = x + 1;
                        int s = y + 1;
                        if (((Controler)main.contr).board[s, d] == null)
                        {
                            Border highlith = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Green),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { s, d },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                            };
                            highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(move);

                            main.field.Children.Add(highlith);
                            Canvas.SetTop(highlith, (s) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlith, (d) * (1000 / 8) + 10);
                        }

                        if (((Controler)main.contr).board[s, d].side != side)
                        {
                            Border highlithh = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Red),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { s, d },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                            };
                            highlithh.MouseDown += new System.Windows.Input.MouseButtonEventHandler(take);

                            main.field.Children.Add(highlithh);
                            Canvas.SetTop(highlithh, (s) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlithh, (d) * (1000 / 8) + 10);
                        }
                    }
                    catch { }

                    //x- y-
                    try
                    {
                        int d = x - 1;
                        int s = y - 1;
                        if (((Controler)main.contr).board[s, d] == null)
                        {
                            Border highlith = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Green),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { s, d },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                            };
                            highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(move);

                            main.field.Children.Add(highlith);
                            Canvas.SetTop(highlith, (s) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlith, (d) * (1000 / 8) + 10);
                        }

                        if (((Controler)main.contr).board[s, d].side != side)
                        {
                            Border highlithh = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Red),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { s, d },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                            };
                            highlithh.MouseDown += new System.Windows.Input.MouseButtonEventHandler(take);

                            main.field.Children.Add(highlithh);
                            Canvas.SetTop(highlithh, (s) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlithh, (d) * (1000 / 8) + 10);
                        }
                    }
                    catch { }

                    //x+ y-
                    try
                    {
                        int d = x + 1;
                        int s = y - 1;
                        if (((Controler)main.contr).board[s, d] == null)
                        {
                            Border highlith = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Green),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { s, d },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                            };
                            highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(move);

                            main.field.Children.Add(highlith);
                            Canvas.SetTop(highlith, (s) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlith, (d) * (1000 / 8) + 10);
                        }

                        if (((Controler)main.contr).board[s, d].side != side)
                        {
                            Border highlithh = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Red),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { s, d },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                            };
                            highlithh.MouseDown += new System.Windows.Input.MouseButtonEventHandler(take);

                            main.field.Children.Add(highlithh);
                            Canvas.SetTop(highlithh, (s) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlithh, (d) * (1000 / 8) + 10);
                        }
                    }
                    catch { }

                    //x- y+
                    try
                    {
                        int d = x - 1;
                        int s = y + 1;
                        if (((Controler)main.contr).board[s, d] == null)
                        {
                            Border highlith = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Green),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { s, d },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                            };
                            highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(move);

                            main.field.Children.Add(highlith);
                            Canvas.SetTop(highlith, (s) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlith, (d) * (1000 / 8) + 10);
                        }

                        if (((Controler)main.contr).board[s, d].side != side)
                        {
                            Border highlithh = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Red),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { s, d },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                            };
                            highlithh.MouseDown += new System.Windows.Input.MouseButtonEventHandler(take);

                            main.field.Children.Add(highlithh);
                            Canvas.SetTop(highlithh, (s) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlithh, (d) * (1000 / 8) + 10);
                        }
                    }
                    catch { }
                    break;
                case FigureType.knight:
                    //x++ y+
                    try
                    {
                        int d = x + 2;
                        int s = y + 1;
                        if (((Controler)main.contr).board[s, d] == null)
                        {
                            Border highlith = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Green),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { s, d },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                            };
                            highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(move);

                            main.field.Children.Add(highlith);
                            Canvas.SetTop(highlith, (s) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlith, (d) * (1000 / 8) + 10);
                        }

                        if (((Controler)main.contr).board[s, d].side != side)
                        {
                            Border highlithh = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Red),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { s, d },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                            };
                            highlithh.MouseDown += new System.Windows.Input.MouseButtonEventHandler(take);

                            main.field.Children.Add(highlithh);
                            Canvas.SetTop(highlithh, (s) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlithh, (d) * (1000 / 8) + 10);
                        }
                    }
                    catch { }

                    //x++ y-
                    try
                    {
                        int d = x +2;
                        int s = y -1;
                        if (((Controler)main.contr).board[s, d] == null)
                        {
                            Border highlith = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Green),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { s, d },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                            };
                            highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(move);

                            main.field.Children.Add(highlith);
                            Canvas.SetTop(highlith, (s) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlith, (d) * (1000 / 8) + 10);
                        }

                        if (((Controler)main.contr).board[s, d].side != side)
                        {
                            Border highlithh = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Red),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { s, d },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                            };
                            highlithh.MouseDown += new System.Windows.Input.MouseButtonEventHandler(take);

                            main.field.Children.Add(highlithh);
                            Canvas.SetTop(highlithh, (s) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlithh, (d) * (1000 / 8) + 10);
                        }
                    }
                    catch { }

                    //x+ y++
                    try
                    {
                        int d = x + 1;
                        int s = y + 2;
                        if (((Controler)main.contr).board[s, d] == null)
                        {
                            Border highlith = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Green),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { s, d },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                            };
                            highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(move);

                            main.field.Children.Add(highlith);
                            Canvas.SetTop(highlith, (s) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlith, (d) * (1000 / 8) + 10);
                        }

                        if (((Controler)main.contr).board[s, d].side != side)
                        {
                            Border highlithh = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Red),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { s, d },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                            };
                            highlithh.MouseDown += new System.Windows.Input.MouseButtonEventHandler(take);

                            main.field.Children.Add(highlithh);
                            Canvas.SetTop(highlithh, (s) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlithh, (d) * (1000 / 8) + 10);
                        }
                    }
                    catch { }

                    //x+ y--
                    try
                    {
                        int d = x + 1;
                        int s = y - 2;
                        if (((Controler)main.contr).board[s, d] == null)
                        {
                            Border highlith = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Green),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { s, d },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                            };
                            highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(move);

                            main.field.Children.Add(highlith);
                            Canvas.SetTop(highlith, (s) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlith, (d) * (1000 / 8) + 10);
                        }

                        if (((Controler)main.contr).board[s, d].side != side)
                        {
                            Border highlithh = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Red),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { s, d },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                            };
                            highlithh.MouseDown += new System.Windows.Input.MouseButtonEventHandler(take);

                            main.field.Children.Add(highlithh);
                            Canvas.SetTop(highlithh, (s) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlithh, (d) * (1000 / 8) + 10);
                        }
                    }
                    catch { }

                    //x- y++
                    try
                    {
                        int d = x - 1;
                        int s = y + 2;
                        if (((Controler)main.contr).board[s, d] == null)
                        {
                            Border highlith = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Green),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { s, d },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                            };
                            highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(move);

                            main.field.Children.Add(highlith);
                            Canvas.SetTop(highlith, (s) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlith, (d) * (1000 / 8) + 10);
                        }

                        if (((Controler)main.contr).board[s, d].side != side)
                        {
                            Border highlithh = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Red),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { s, d },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                            };
                            highlithh.MouseDown += new System.Windows.Input.MouseButtonEventHandler(take);

                            main.field.Children.Add(highlithh);
                            Canvas.SetTop(highlithh, (s) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlithh, (d) * (1000 / 8) + 10);
                        }
                    }
                    catch { }

                    //x-- y+
                    try
                    {
                        int d = x - 2;
                        int s = y + 1;
                        if (((Controler)main.contr).board[s, d] == null)
                        {
                            Border highlith = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Green),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { s, d },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                            };
                            highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(move);

                            main.field.Children.Add(highlith);
                            Canvas.SetTop(highlith, (s) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlith, (d) * (1000 / 8) + 10);
                        }

                        if (((Controler)main.contr).board[s, d].side != side)
                        {
                            Border highlithh = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Red),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { s, d },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                            };
                            highlithh.MouseDown += new System.Windows.Input.MouseButtonEventHandler(take);

                            main.field.Children.Add(highlithh);
                            Canvas.SetTop(highlithh, (s) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlithh, (d) * (1000 / 8) + 10);
                        }
                    }
                    catch { }

                    //x- y--
                    try
                    {
                        int d = x - 1;
                        int s = y - 2;
                        if (((Controler)main.contr).board[s, d] == null)
                        {
                            Border highlith = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Green),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { s, d },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                            };
                            highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(move);

                            main.field.Children.Add(highlith);
                            Canvas.SetTop(highlith, (s) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlith, (d) * (1000 / 8) + 10);
                        }

                        if (((Controler)main.contr).board[s, d].side != side)
                        {
                            Border highlithh = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Red),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { s, d },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                            };
                            highlithh.MouseDown += new System.Windows.Input.MouseButtonEventHandler(take);

                            main.field.Children.Add(highlithh);
                            Canvas.SetTop(highlithh, (s) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlithh, (d) * (1000 / 8) + 10);
                        }
                    }
                    catch { }

                    //x-- y-
                    try
                    {
                        int d = x - 2;
                        int s = y - 1;
                        if (((Controler)main.contr).board[s, d] == null)
                        {
                            Border highlith = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Green),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { s, d },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                            };
                            highlith.MouseDown += new System.Windows.Input.MouseButtonEventHandler(move);

                            main.field.Children.Add(highlith);
                            Canvas.SetTop(highlith, (s) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlith, (d) * (1000 / 8) + 10);
                        }

                        if (((Controler)main.contr).board[s, d].side != side)
                        {
                            Border highlithh = new Border()
                            {
                                BorderThickness = new System.Windows.Thickness(5),
                                BorderBrush = new SolidColorBrush(Colors.Red),
                                Height = 1000 / 8,
                                Width = 1000 / 8,
                                Tag = new int[] { s, d },
                                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))
                            };
                            highlithh.MouseDown += new System.Windows.Input.MouseButtonEventHandler(take);

                            main.field.Children.Add(highlithh);
                            Canvas.SetTop(highlithh, (s) * (1000 / 8) + 10);
                            Canvas.SetLeft(highlithh, (d) * (1000 / 8) + 10);
                        }
                    }
                    catch { }

                    break;
            }
        }

        public bool look(Figure f)
        {
            if(f.y == y && f.x == x)
            {
                return true;
            }
            return false;
        }

        public void move(object sneder, System.Windows.Input.MouseButtonEventArgs e)
        {
            soundPlayer.SoundLocation = @"Sounds\moves.wav";
            soundPlayer.Play();
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

            ((Controler)main.contr).turnchange();

            if (main.online == true && e != null)
            {
                main.send_up(((Controler)main.contr).Figurelist.IndexOf(this), y, x, true);
            }
        }

        public void take(object sneder, System.Windows.Input.MouseButtonEventArgs e)
        {
            soundPlayer.SoundLocation = @"Sounds\take.wav";
            soundPlayer.Play();
            int bae = ((Controler)main.contr).Figurelist.IndexOf(this);

            Border nol = (Border)sneder;
            
            main.log.Text += y + "_" + x + " ---> " + ((int[])nol.Tag)[0] + "_" + ((int[])nol.Tag)[1] + " take out";

            Figure nols = ((Controler)main.contr).board[((int[])nol.Tag)[0], ((int[])nol.Tag)[1]];

            int jentak = ((Controler)main.contr).Figurelist.IndexOf(nols);
            ((Controler)main.contr).Figurelist.RemoveAt(jentak);


            if ((((Controler)main.contr).board[((int[])nol.Tag)[0], ((int[])nol.Tag)[1]]).Type == FigureType.king)
            {
                ((Controler)main.contr).ende((((Controler)main.contr).board[((int[])nol.Tag)[0], ((int[])nol.Tag)[1]]));
            }

            if ((Type == FigureType.pawn && (y == 0 || y == 7)) && ((Controler)main.contr).board[((int[])nol.Tag)[0], ((int[])nol.Tag)[1]].Type != FigureType.king)
            {
                Pawnchooser chooser = new Pawnchooser(this);
                chooser.Show();
                main.log.Text += " type_switch\n";
            }
            else
            {
                main.log.Text += "\n";
            }

            ((Controler)main.contr).board[y, x] = null;

            y = ((int[])nol.Tag)[0];
            x = ((int[])nol.Tag)[1];

            ((Controler)main.contr).board[((int[])nol.Tag)[0], ((int[])nol.Tag)[1]] = this;
            ((Controler)main.contr).paint();
          
            ((Controler)main.contr).turnchange();

            if(main.online == true && e != null)
            {
                main.send_up(bae, y, x, false);
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
