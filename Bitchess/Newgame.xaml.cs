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
using System.Windows.Shapes;

namespace Bitchess
{
    /// <summary>
    /// Interakční logika pro Newgame.xaml
    /// </summary>
    public partial class Newgame : Window
    {
        public Newgame(MainWindow main)
        {
            InitializeComponent();
            main.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.setline();
            Side lol = Side.white;

            if(_1 == true)
            {
                lol = Side.white;
            }

            if(_1 == false)
            {
                lol = Side.black;
            }

            Onlinemanager onlinemanager = new Onlinemanager(mainWindow, "_1", lol);

            mainWindow.Show();
            Close();
        }

        bool _1 = true;

        private void r1_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                r2.IsChecked = false;
                _1 = true;
            }
            catch { }
        }

        private void r2_Checked(object sender, RoutedEventArgs e)
        {
            r1.IsChecked = false;
            _1 = false;
        }
    }
}
