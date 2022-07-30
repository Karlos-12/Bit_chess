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
        public Newgame()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(false);
            mainWindow.Show();
            Close();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(true);
            
            Onlinemanager onlinemanager = new Onlinemanager(mainWindow, "_1");

            mainWindow.Show();
            Close();
        }
    }
}
