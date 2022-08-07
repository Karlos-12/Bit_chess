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
        public Side turn { get; set; }
        string fen;

        public Controler(MainWindow main)
        {
            turn = Side.black;
            this.main = main;
            Figurelist = new List<Figure>();
            board = new Figure[8, 8];

            if (main.fen == null)
            {
                basic();
            }
            else
            {
                fen = main.fen;
                fenset(fen);
            }

            paint();
            turnchange();
        }

        public void basic()
        {
            Figurelist.Clear();
            board = new Figure[8, 8];
            //Pawn
            {
                for (int i = 7; i >= 0; i--)
                {
                    Figure non1 = new Figure(FigureType.pawn, Side.black, 1, i, "Black_pawn_" + i, main);
                    Figurelist.Add(non1);
                    board[1, i] = non1;
                }

                for (int i = 7; i >= 0; i--)
                {
                    Figure non2 = new Figure(FigureType.pawn, Side.white, 6, i, "White_pawn_" + i, main);
                    Figurelist.Add(non2);
                    board[6, i] = non2;
                }
            }

            //Towers
            {
                Figure non3 = new Figure(FigureType.tower, Side.black, 0, 0, "Black_tower_" + 0, main);
                Figurelist.Add(non3);
                board[0, 0] = non3;

                Figure non4 = new Figure(FigureType.tower, Side.black, 0, 7, "Black_tower_" + 1, main);
                Figurelist.Add(non4);
                board[0, 7] = non4;

                Figure non6 = new Figure(FigureType.tower, Side.white, 7, 0, "White_tower_" + 0, main);
                Figurelist.Add(non6);
                board[7, 0] = non6;

                Figure non5 = new Figure(FigureType.tower, Side.white, 7, 7, "White_tower_" + 1, main);
                Figurelist.Add(non5);
                board[7, 7] = non5;
            }

            //Bishops
            {

                Figure non6 = new Figure(FigureType.bishop, Side.black, 0, 2, "Black_Bishop_" + 0, main);
                Figurelist.Add(non6);
                board[0, 2] = non6;

                Figure non7 = new Figure(FigureType.bishop, Side.black, 0, 5, "Black_Bishop_" + 1, main);
                Figurelist.Add(non7);
                board[0, 5] = non7;

                Figure non8 = new Figure(FigureType.bishop, Side.white, 7, 2, "White_Bishop_" + 0, main);
                Figurelist.Add(non8);
                board[7, 2] = non8;

                Figure non9 = new Figure(FigureType.bishop, Side.white, 7, 5, "White_Bishop_" + 1, main);
                Figurelist.Add(non9);
                board[7, 5] = non9;
            }

            //Quens
            {
                Figure non10 = new Figure(FigureType.queen, Side.white, 7, 3, "White_queen_" + 0, main);
                Figurelist.Add(non10);
                board[7, 3] = non10;

                Figure non11 = new Figure(FigureType.queen, Side.black, 0, 3, "Black_queen_" + 0, main);
                Figurelist.Add(non11);
                board[0, 3] = non11;
            }

            //Kings
            {
                Figure non12 = new Figure(FigureType.king, Side.white, 7, 4, "White_king_" + 0, main);
                Figurelist.Add(non12);
                board[7, 4] = non12;

                Figure non13 = new Figure(FigureType.king, Side.black, 0, 4, "Black_king_" + 0, main);
                Figurelist.Add(non13);
                board[0, 4] = non13;
            }

            //Horses
            {
                Figure non14 = new Figure(FigureType.knight, Side.black, 0, 1, "Black_Knight_" + 0, main);
                Figurelist.Add(non14);
                board[0, 1] = non14;

                Figure non15 = new Figure(FigureType.knight, Side.black, 0, 6, "Black_Knight_" + 1, main);
                Figurelist.Add(non15);
                board[0, 6] = non15;

                Figure non16 = new Figure(FigureType.knight, Side.white, 7, 1, "White_Knight_" + 0, main);
                Figurelist.Add(non16);
                board[7, 1] = non16;

                Figure non17 = new Figure(FigureType.knight, Side.white, 7, 6, "White_Knight_" + 1, main);
                Figurelist.Add(non17);
                board[7, 6] = non17;
            }
        }

        public void fenset(string f)
        {
            Figurelist.Clear();
            board = new Figure[8, 8];
            fen = f;
            int y = 0;
            int x = 0;
            for (int u = 0; u < fen.Length; u++)
            {
                
                if (y == 7 && x == 8)
                {
                    string tump = fen.Substring(u +1);
                    if(tump == "w" || tump == "W")
                    {
                        turnchange();
                        turnchange();
                    }
                    else if (tump == "b" || tump == "B")
                    {
                        turnchange();
                    }
                }
                else
                {
                    string temp = fen.Substring(u, 1);
                    if(temp == "/")
                    {
                        y++;
                        x = 0;
                    }
                    else
                    {
                        try
                        {
                            int tomp = int.Parse(temp);
                            x += tomp;
                      
                        }
                        catch
                        {
                            switch (temp)
                            {
                                case "P":
                                    Figure non1 = new Figure(FigureType.pawn, Side.white, y, x, "White_pawn_" + u, main);
                                    Figurelist.Add(non1);
                                    board[y, x] = non1;
                                    break;

                                case "R":
                                    Figure non2 = new Figure(FigureType.tower, Side.white, y, x, "White_tower_" + u, main);
                                    Figurelist.Add(non2);
                                    board[y, x] = non2;
                                    break;

                                case "B":
                                    Figure non3 = new Figure(FigureType.bishop, Side.white, y, x, "White_tower_" + u, main);
                                    Figurelist.Add(non3);
                                    board[y, x] = non3;
                                    break;

                                case "Q":
                                    Figure non4 = new Figure(FigureType.queen, Side.white, y, x, "White_queen_" + u, main);
                                    Figurelist.Add(non4);
                                    board[y, x] = non4;
                                    break;

                                case "K":
                                    Figure non5 = new Figure(FigureType.king, Side.white, y, x, "White_king_" + u, main);
                                    Figurelist.Add(non5);
                                    board[y, x] = non5;
                                    break;

                                case "N":
                                    Figure non6 = new Figure(FigureType.knight, Side.white, y, x, "White_horse_" + u, main);
                                    Figurelist.Add(non6);
                                    board[y, x] = non6;
                                    break;


                                case "p":
                                    Figure non11 = new Figure(FigureType.pawn, Side.black, y, x, "Black_pawn_" + u, main);
                                    Figurelist.Add(non11);
                                    board[y, x] = non11;
                                    break;

                                case "r":
                                    Figure non12 = new Figure(FigureType.tower, Side.black, y, x, "Black_tower_" + u, main);
                                    Figurelist.Add(non12);
                                    board[y, x] = non12;
                                    break;

                                case "b":
                                    Figure non13 = new Figure(FigureType.bishop, Side.black, y, x, "Black_bishop_" + u, main);
                                    Figurelist.Add(non13);
                                    board[y, x] = non13;
                                    break;

                                case "q":
                                    Figure non14 = new Figure(FigureType.queen, Side.black, y, x, "Black_queen_" + u, main);
                                    Figurelist.Add(non14);
                                    board[y, x] = non14;
                                    break;

                                case "k":
                                    Figure non15 = new Figure(FigureType.king, Side.black, y, x, "Black_king_" + u, main);
                                    Figurelist.Add(non15);
                                    board[y, x] = non15;
                                    break;

                                case "n":
                                    Figure non16 = new Figure(FigureType.knight, Side.black, y, x, "Black_knight_" + u, main);
                                    Figurelist.Add(non16);
                                    board[y, x] = non16;
                                    break;
                            }
                            x++;
                        }
                        
                    }
                }
            }

            paint();
        }

        public void turnchange()
        {
            if(turn == Side.white)
            {
                turn = Side.black;
                List<Figure> nul = Figurelist.FindAll(iswite);
                foreach (var item in nul)
                {
                    item.image.IsEnabled = false;
                }
                List<Figure> nuls = Figurelist.FindAll(isblack);
                foreach (var item in nuls)
                {
                    item.image.IsEnabled = true;
                }
            }
            else
            {
                turn = Side.white;
                List<Figure> nul = Figurelist.FindAll(isblack);
                foreach (var item in nul)
                {
                    item.image.IsEnabled = false;
                }
                List<Figure> nuls = Figurelist.FindAll(iswite);
                foreach (var item in nuls)
                {
                    item.image.IsEnabled = true;
                }
            }

            if(fgf == true)
            {
                if(inds == Side.white)
                {
                    List<Figure> nuls = Figurelist.FindAll(isblack);
                    foreach (var item in nuls)
                    {
                        item.image.IsEnabled = false;
                    }
                }
                else if (inds == Side.black)
                {
                    List<Figure> nuls = Figurelist.FindAll(iswite);
                    foreach (var item in nuls)
                    {
                        item.image.IsEnabled = false;
                    }
                }
            }

            main.indc.Content = turn.ToString();
            paint();
        }

        public bool fgf = false;
        Side inds = Side.white;
        public void setlln(Side s)
        {
            fgf = true;
            inds = s;
        }

        private static bool iswite(Figure f)
        {
            if(f.side == Side.white)
            {
                return true;
            }
            return false;
        }

        private static bool isblack(Figure f)
        {
            if (f.side != Side.white)
            {
                return true;
            }
            return false;
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

        public void ende(Figure figure)
        {
            foreach (var item in Figurelist)
            {
                item.image.IsEnabled = false;
            }
            main.log.Text += " \n __Game has ended__";
            main.indc.Content = "Game has ended";

            Task.Delay(10000);
            main.resert();

            

            resultscreen res = new resultscreen(figure.side);
            res.Show();
            Newgame ne = new Newgame(null);
            ne.Show();
            main.Close();
        }
    }
}
