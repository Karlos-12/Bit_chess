using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;

namespace Bitchess
{
    internal class Onlinemanager
    {
        private MainWindow main;
        public string path;

        public Onlinemanager(MainWindow m, string path)
        {
            main = m;
            this.path = path;
            config.BasePath += path;
        }

        IFirebaseClient client;
        IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "",
             BasePath = "https://bitchess-6cf4b-default-rtdb.europe-west1.firebasedatabase.app/"
        };

        public void Tick_tack()
        {

            //data format: list_index//bool_moveortake//move_cordinates x tyke_cordinates//
        }
    }
}
