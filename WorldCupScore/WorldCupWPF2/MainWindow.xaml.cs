using DataRepo.DAO;
using DataRepo.Models;
using DataRepository.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private IDataRepo repo;
        private HashSet<Matches> matches;
        private HashSet<Matches> filteredMatches = new HashSet<Matches>();
        private HashSet<Results> results;
        private AppSettingsRepo settingsRepo = new AppSettingsRepo();
        private AppSettings settings = new AppSettings();

        public MainWindow()
        {
            InitializeComponent();
            LoadSettings();
            FetchData();
            FilterMatches();
        }

        private void LoadSettings()
        {
            try
            {
                settings = settingsRepo.Load();
            }
            catch (Exception)
            {

                SettingsCard settingsCard = new SettingsCard();
                bool res = (bool)settingsCard.ShowDialog();
                if (res)
                {
                    LoadSettings();
                    FetchData();
                }
            }
            ApplyResolution(settings.Resolution);
            ApplyLanguage(settings.Language);
        }


        private void FetchData()
        {
            try
            {
                if (settings.OfflineMode) repo = new FileRepository();
                else repo = new ApiRepo();

                matches = (HashSet<Matches>)repo.GetAllMatches(settings.Championship);
                results = (HashSet<Results>)repo.GetAllResults(settings.Championship);

                foreach (Results r in results)
                {
                    cbFavoriteTeam.Items.Add(r.Fifa_code);
                }

                cbFavoriteTeam.SelectedValue = settings.FavoriteTeam;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska u ucitavanju" + ex.Message, "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void ApplyLanguage(string language)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(language);

            this.Title = WorldCupWPF.Localization.strings.MainWindow;

            lblFavoriteTeam.Content = WorldCupWPF.Localization.strings.lblFavoriteTeam;
            lblRivalTeam.Content = WorldCupWPF.Localization.strings.lblRivalTeam;
            lblResult.Content = WorldCupWPF.Localization.strings.lblResult;
            btnSettings.Content = WorldCupWPF.Localization.strings.btnSettings;
            btnFavorite.Content = WorldCupWPF.Localization.strings.btnFavorite;
            btnFavoriteTeamOverview.Content = WorldCupWPF.Localization.strings.btnOverview;
            btnRivalTeamOverview.Content = WorldCupWPF.Localization.strings.btnOverview;
        }

        private void ApplyResolution(string resolution)
        {
            switch (resolution)
            {
                case "small":
                    this.WindowState = WindowState.Normal;
                    this.Width = 800;
                    this.Height = 600;
                    break;
                case "medium":
                    this.WindowState = WindowState.Normal;
                    this.Width = 1024;
                    this.Height = 768;
                    break;
                case "fullscreen":
                    this.WindowState = WindowState.Maximized;
                    break;
            }
        }

        private void SaveSettings()
        {
            try
            {
                settingsRepo.Save(settings);
            }
            catch
            {
                MessageBox.Show("Failed to save settings!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void OpenScoreOverviewBoard(string fifaCode)
        {
            Results result = null;
            foreach (var r in results)
            {
                if (r.Fifa_code == fifaCode)
                {
                    result = r;
                    break;
                }
            }

            if (result == null) return;

            ScoreOverviewBoard window = new ScoreOverviewBoard(result);
            window.Show();

            DoubleAnimation animation = new DoubleAnimation(400, 0, TimeSpan.FromSeconds(0.5));
            TranslateTransform translateTransform = new TranslateTransform();

            window.RenderTransform = translateTransform;

            translateTransform.BeginAnimation(TranslateTransform.YProperty, animation);
        }

        private void FilterMatches()
        {
            try
            {
                if (cbFavoriteTeam.SelectedItem == null) return;

                string fifaCode = cbFavoriteTeam.SelectedItem.ToString();
                filteredMatches.Clear();
                cbRivalTeam.Items.Clear();
                foreach (var match in matches)
                {
                    if (match.HomeTeam.Code == fifaCode || match.AwayTeam.Code == fifaCode)
                    {
                        filteredMatches.Add(match);
                    }
                }

                foreach (var match in filteredMatches)
                {
                    if (match.HomeTeam.Code == fifaCode) cbRivalTeam.Items.Add(match.AwayTeam.Code);
                    if (match.AwayTeam.Code == fifaCode) cbRivalTeam.Items.Add(match.HomeTeam.Code);
                }
            }
            catch
            {
                //default
            }
        }

        private void DisplayMatch(Matches match, bool flip)
        {
            ClearField();

            foreach (var player in match.HomeTeamStatistics.StartingEleven)
            {
                PlayerIcon icon = new PlayerIcon(player);
                icon.Caption = player.Name;
                switch (player.Position)
                {
                    case "Goalie":
                        if (!flip) stpFavoriteGoalie.Children.Add(icon);
                        if (flip) stpRivalGoalie.Children.Add(icon);
                        break;
                    case "Defender":
                        if (!flip) stpFavoriteDefender.Children.Add(icon);
                        if (flip) stpRivalDefender.Children.Add(icon);
                        break;
                    case "Midfield":
                        if (!flip) stpFavoriteMidfield.Children.Add(icon);
                        if (flip) stpRivalMidfield.Children.Add(icon);
                        break;
                    case "Forward":
                        if (!flip) stpFavoriteForward.Children.Add(icon);
                        if (flip) stpRivalForward.Children.Add(icon);
                        break;
                }
            }

            foreach (var player in match.AwayTeamStatistics.StartingEleven)
            {
                PlayerIcon icon = new PlayerIcon(player);
                icon.Caption = player.Name;
                switch (player.Position)
                {
                    case "Goalie":
                        if (flip) stpFavoriteGoalie.Children.Add(icon);
                        if (!flip) stpRivalGoalie.Children.Add(icon);
                        break;
                    case "Defender":
                        if (flip) stpFavoriteDefender.Children.Add(icon);
                        if (!flip) stpRivalDefender.Children.Add(icon);
                        break;
                    case "Midfield":
                        if (flip) stpFavoriteMidfield.Children.Add(icon);
                        if (!flip) stpRivalMidfield.Children.Add(icon);
                        break;
                    case "Forward":
                        if (flip) stpFavoriteForward.Children.Add(icon);
                        if (!flip) stpRivalForward.Children.Add(icon);
                        break;
                }
            }

            int homeScore = 0, awayScore = 0;

            foreach (var e in match.HomeTeamEvents)
            {
                if (e.TypeOfEvent == "goal") homeScore++;
                if (e.TypeOfEvent == "goal-own") awayScore++;
            }

            foreach (var e in match.AwayTeamEvents)
            {
                if (e.TypeOfEvent == "goal") awayScore++;
                if (e.TypeOfEvent == "goal-own") homeScore++;
            }

            lblFavoriteTeamScore.Content = flip ? awayScore : homeScore;
            lblRivalTeamScore.Content = flip ? homeScore : awayScore;
        }

        private void ClearField()
        {
            stpFavoriteGoalie.Children.Clear();
            stpFavoriteDefender.Children.Clear();
            stpFavoriteMidfield.Children.Clear();
            stpFavoriteForward.Children.Clear();

            stpRivalGoalie.Children.Clear();
            stpRivalDefender.Children.Clear();
            stpRivalMidfield.Children.Clear();
            stpRivalForward.Children.Clear();
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Jeste li sigurni?", "Izlaz iz aplikacije", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No) e.Cancel = true;
        }
        private void OpenOverview(string fifaCode)
        {
            Results result = null;
            foreach (var r in results)
            {
                if (r.Fifa_code == fifaCode)
                {
                    result = r;
                    break;
                }
            }

            if (result == null) return;

            ScoreOverviewBoard window = new ScoreOverviewBoard(result);
            window.Show();

            DoubleAnimation animation = new DoubleAnimation(400, 0, TimeSpan.FromSeconds(0.5));
            TranslateTransform translateTransform = new TranslateTransform();

            window.RenderTransform = translateTransform;

            translateTransform.BeginAnimation(TranslateTransform.YProperty, animation);
        }

        private void cmbRivalTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string favoriteCode = cbFavoriteTeam.SelectedItem.ToString();
                string rivalCode = cbRivalTeam.SelectedItem.ToString();

                foreach (var match in filteredMatches)
                {
                    if (match.HomeTeam.Code == favoriteCode && match.AwayTeam.Code == rivalCode)
                    {
                        DisplayMatch(match, false);
                        break;
                    }

                    if (match.HomeTeam.Code == rivalCode && match.AwayTeam.Code == favoriteCode)
                    {
                        DisplayMatch(match, true);
                        break;
                    }
                }
            }
            catch
            {
                
            }
        }

        private void cmbFavoriteTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearField();
            FilterMatches();
        }

        private void btnRivalTeamOverview_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenOverview(cbRivalTeam.SelectedItem.ToString());
            }
            catch
            {
                MessageBox.Show("Please select a team.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnFavoriteTeamOverview_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenOverview(cbFavoriteTeam.SelectedItem.ToString());
            }
            catch
            {
                MessageBox.Show("Please select a team.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            SettingsCard settingsWindow = new SettingsCard();
            settingsWindow.Owner = this;
            bool result = (bool)settingsWindow.ShowDialog();

            if (result)
            {
                LoadSettings();
                FetchData();
            }
        }

        private void btnFavorite_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                settings.FavoriteTeam = cbFavoriteTeam.SelectedItem.ToString();
                SaveSettings();
                MessageBox.Show("Postavljen omiljen tim", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Odaberite tim", "Warning", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
        }
    }
}