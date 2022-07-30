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
        public object contr;

        public MainWindow()
        {
            InitializeComponent();
            maincotr = new Controler(this);
            contr = maincotr;
            repaint();
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
