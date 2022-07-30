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

namespace Bitchess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        Controler maincotr;
        Onlinemanager onlineman;
        public object contr;
        public bool online;

#pragma warning disable CS8618 // Pole, které nemůže být null, musí při ukončování konstruktoru obsahovat hodnotu, která není null. Zvažte možnost deklarovat ho jako pole s možnou hodnotou null.
        public MainWindow(bool online = false)
#pragma warning restore CS8618 // Pole, které nemůže být null, musí při ukončování konstruktoru obsahovat hodnotu, která není null. Zvažte možnost deklarovat ho jako pole s možnou hodnotou null.
        {
            InitializeComponent();
            maincotr = new Controler(this);
            contr = maincotr;
            repaint();
            this.online = online;
        }

        public void send_up(int ind, int ys, int xs, bool mv)
        {
            onlineman.tmov(ind, ys, xs, mv);
        }

        public void assing(object o)
        {
            onlineman = (Onlinemanager)o;
        }

        public void repaint()
        {
            maincotr.paint();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Newgame newgame = new Newgame();
            newgame.Show();
        }
    }
}
