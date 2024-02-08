using DataRepo.Models;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WorldCupWPF
{
    /// <summary>
    /// Interaction logic for PlayerIcon.xaml
    /// </summary>
    public partial class PlayerIcon : UserControl
    {
        private Player Player = new Player();

        public PlayerIcon(Player player)
        {
            InitializeComponent();
            this.Player = player;
        }

        public string Caption
        {
            get
            {
                return tbCaption.Text;
            }
            set
            {
                tbCaption.Text = value;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PlayerView window = new PlayerView(Player);
            window.Show();
            //transition animation, from to
            DoubleAnimation animation = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.3));

            window.BeginAnimation(UIElement.OpacityProperty, animation);
        }
    }
}
