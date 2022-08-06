using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
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
using System.Windows.Threading;


namespace Bitchess
{
    internal class bot
    {
        public Side botside;
        public List<bot_fig> all;

        public bot(Side botside, List<bot_fig> all)
        {
            this.botside = botside;
            this.all = all;
        }

    }

    internal class Tah
    {
        public List<bot_fig> enfigs;
        public List<bot_fig> myfigs;

        public Side botside;

        public Tah(List<bot_fig> all, Side botside)
        {
            this.botside = botside;

            for (int i = all.Count - 1; i >= 0; i--)
            {
                if (all[i].side == botside)
                {
                    myfigs.Add(all[i]);
                }
                else
                {
                    enfigs.Add(all[i]);
                }
            }
         
        }
    }

   internal class bot_fig
   {
        public Side side;
   }

}