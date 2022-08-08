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
    /// Interakční logika pro Pawnchooser.xaml
    /// </summary>
    public partial class Pawnchooser : Window
    {
        Figure f;
        bool choosen = false;
        public Pawnchooser(object f)
        {
            InitializeComponent();
            this.f = f as Figure;
            var soundPlayer = new System.Media.SoundPlayer();
            soundPlayer.SoundLocation = @"Sounds\evolve.wav";
            soundPlayer.Play();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            switch(((Image)sender).Tag)
            {
                case "0":
                    f.Type = FigureType.queen;
                    break;
                case "1":
                    f.Type = FigureType.bishop;
                    break;
                case "2":
                    f.Type = FigureType.knight;
                    break;
                case "3":
                    f.Type = FigureType.tower;
                    break;
                case "4":
                    f.Type = FigureType.king;
                    break;
            }
            f.swithcero();
            choosen = true;
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (choosen == false)
            {
                f.Type = FigureType.tower;
                f.swithcero();
            }
        }
    }
}
