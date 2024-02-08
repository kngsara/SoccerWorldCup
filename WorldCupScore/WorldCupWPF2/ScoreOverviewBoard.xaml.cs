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
    /// Interaction logic for ScoreOverviewBoard.xaml
    /// </summary>
    public partial class ScoreOverviewBoard : Window
    {
        private Results result;
        public ScoreOverviewBoard(Results result)
        {
            InitializeComponent();
            this.result = result;
            ApplyLanguage();
            lblCountryCode.Content = result.Country + ": " + result.Fifa_code;
            lblTeamWinsScore.Content = result.Wins;
            lblDrawsScore.Content = result.Draws;
            lblGamesPlayedScore.Content = result.Games_played;
            lblPointsScore.Content = result.Points;
            lblGoalsAgainstScore.Content = result.Goals_against;
            lblGoalsForScore.Content = result.Goals_for;
        }

        private void ApplyLanguage()
        {
            this.Title = WorldCupWPF.Localization.strings.ScoreOverviewBoard;

            lblOverview.Content = WorldCupWPF.Localization.strings.lblOverview;
            lblWins.Content = WorldCupWPF.Localization.strings.lblWins;
            lblDraws.Content = WorldCupWPF.Localization.strings.lblDraws;
            lblLosses.Content = WorldCupWPF.Localization.strings.lblLosses;
            lblGamesPlayed.Content = WorldCupWPF.Localization.strings.lblGamesPlayed;
            lblPoints.Content = WorldCupWPF.Localization.strings.lblPoints;
            lblGoalsFor.Content = WorldCupWPF.Localization.strings.lblGoalsFor;
            lblGoalsAgainst.Content = WorldCupWPF.Localization.strings.lblGoalsAgainst;
            
        }
    }
}
