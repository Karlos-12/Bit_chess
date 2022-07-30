using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;

namespace Bitchess
{
    internal class Onlinemanager
    {
        private MainWindow main { get; set; }
        public string path { get; set; }
        private int countec { get; set; }

        public Onlinemanager(MainWindow m, string path)
        {
            main = m;
            this.path = path;
            config.BasePath += path;
            countec = 0;
            DispatcherTimer dispatcher = new DispatcherTimer();
            dispatcher.Interval = new TimeSpan(0,0,1);
            dispatcher.Tick += new EventHandler(Tick_tack);
            dispatcher.Start();
        }

        IFirebaseClient client;
        IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "",
             BasePath = "https://bitchess-6cf4b-default-rtdb.europe-west1.firebasedatabase.app/"
        };

        public void Tick_tack(object sender, EventArgs e)
        {
            int cntp = client.Get("count").ResultAs<int>();
            if(cntp != countec)
            {
                countec++;
                movetake move = client.Get(countec.ToString()).ResultAs<movetake>();

                if(move.move == true)
                {
                    Figure f = ((Controler)main.contr).Figurelist[move.indx];
                    Border b = new Border();
                    b.Tag = new int[] {move.ny, move.nx};
                    f.move(b, null);
                }
                else if(move.move == false)
                {
                    Figure f = ((Controler)main.contr).Figurelist[move.indx];
                    Border b = new Border();
                    b.Tag = new int[] { move.ny, move.nx };
                    f.take(b, null);
                }
            }

            //data format: list_index//bool_moveortake//move_cordinates x take_cordinates//
        }

        public void tmov(int ind, int ys, int xs, bool mv)
        {
            movetake mov = new movetake(ind, xs, ys, mv);
        }
    }
}
