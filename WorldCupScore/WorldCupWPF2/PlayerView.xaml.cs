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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WorldCupWPF
{
    /// <summary>
    /// Interaction logic for PlayerView.xaml
    /// </summary>
    public partial class PlayerView : Window
    {
        private Player player;
        public PlayerView(Player player)
        {
            InitializeComponent();
            ApplyLanguage();
            this.player = player;


            lblNameScore.Content = player.Name;
            lblShirtScore.Content = player.ShirtNumber;
            lblCaptainScore.Content = player.Captain;
            lblGoalsScore.Content = player.Goals;
            lblYellowCardsScore.Content = player.YellowCards;

            if (player.Captain)
            {
                lblCaptainScore.Content = "yes";
                lblCaptainScore.FontWeight = FontWeights.Bold;
            }
            else
            {
                lblCaptainScore.Content = "no";
            }

        }

        private void ApplyLanguage()
        {
            this.Title = WorldCupWPF.Localization.strings.PlayerViewTitle;

           
            lblShirtNumber.Content = WorldCupWPF.Localization.strings.lblShirtNumber;
            lblCaptain.Content = WorldCupWPF.Localization.strings.lblCaptain;
            lblGoals.Content = WorldCupWPF.Localization.strings.lblGoals;
            lblYellowCards.Content = WorldCupWPF.Localization.strings.lblYellowCards;
        }
    }
}
