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
    /// Interakční logika pro resultscreen.xaml
    /// </summary>
    public partial class resultscreen : Window
    {
        public resultscreen(Side s)
        {
            InitializeComponent();

            if(s == Side.black)
            {
                splash.Content = "White have won!";
            }
            else
            {
                splash.Content = "Black have won!";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
