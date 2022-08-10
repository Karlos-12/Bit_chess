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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        Controler maincotr;
        Onlinemanager onlineman;
        public object ommm;
        public object contr;
        public bool online = false;
        public string fen;

        public MainWindow()
        {
            InitializeComponent();
            var soundPlayer = new System.Media.SoundPlayer();
            soundPlayer.SoundLocation = @"Sounds\POL-cyber-factory-short.wav";
          //  soundPlayer.PlayLooping();
            maincotr = new Controler(this);
            contr = maincotr;
            ommm = onlineman;
            repaint();
        }

        public void lol()
        {
            if (fen == "Fen..." || fen == "" || fen == null)
            {

            }
            else
            {
                maincotr.fenset(fen);
            }
        }

        public void setline()
        {
            online = true;
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
            if(online == true)
            {
                onlineman.resert();
            }
            Newgame newgame = new Newgame(this);
            newgame.Show();
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://www.wikihow.com/Play-Chess-for-Beginners",
                UseShellExecute = true
            });
        }

        public void resert()
        {
            try
            {
                onlineman.resert();
            }
            catch
            { }
        }
    }
}
