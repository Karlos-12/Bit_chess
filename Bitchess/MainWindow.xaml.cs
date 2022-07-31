﻿using FireSharp;
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

#pragma warning disable CS8618 // Pole, které nemůže být null, musí při ukončování konstruktoru obsahovat hodnotu, která není null. Zvažte možnost deklarovat ho jako pole s možnou hodnotou null.
        public MainWindow()
#pragma warning restore CS8618 // Pole, které nemůže být null, musí při ukončování konstruktoru obsahovat hodnotu, která není null. Zvažte možnost deklarovat ho jako pole s možnou hodnotou null.
        {
            InitializeComponent();
            maincotr = new Controler(this);
            contr = maincotr;
            ommm = onlineman;
            repaint();
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
            onlineman.resert();
        }
    }
}
