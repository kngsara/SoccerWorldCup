using DataRepository.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WorldCupWPF
{
    /// <summary>
    /// Interaction logic for SettingsCard.xaml
    /// </summary>
    public partial class SettingsCard : Window
    {
        private AppSettings settings = new AppSettings();
        private AppSettingsRepo settingsRepo = new AppSettingsRepo();

        public SettingsCard()
        {
            InitializeComponent();

            try
            {
                settings = settingsRepo.Load();
            }
            catch
            {
                //default settings inace
            }

            rbMen.IsChecked = settings.Championship == "men";
            rbWomen.IsChecked = settings.Championship == "women";
            cbOffline.IsChecked = settings.OfflineMode;
            rbEnglish.IsChecked = settings.Language == "en";
            rbCroatian.IsChecked = settings.Language == "hr";

            rb800.IsChecked = settings.Resolution == "small";
            rb1024.IsChecked = settings.Resolution == "medium";
            rbFullScreen.IsChecked = settings.Resolution == "fullscreen";
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }


        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)rbMen.IsChecked) settings.Championship = "men";
            if ((bool)rbWomen.IsChecked) settings.Championship = "women";
            settings.OfflineMode = (bool)cbOffline.IsChecked;
            if ((bool)rbEnglish.IsChecked) settings.Language = "en";
            if ((bool)rbCroatian.IsChecked) settings.Language = "hr";

            if ((bool)rb800.IsChecked) settings.Resolution = "small";
            if ((bool)rb1024.IsChecked) settings.Resolution = "medium";
            if ((bool)rbFullScreen.IsChecked) settings.Resolution = "fullscreen";

            try
            {
                settingsRepo.Save(settings);
            }
            catch
            {
                MessageBox.Show("Greska u spremanju postavki.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

            DialogResult = true;
            this.Close();
        }
        private void ApplyLanguage(string language)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(language);

            lblChampionship.Content = WorldCupWPF.Localization.strings.lblChampionship;
            rbMen.Content = WorldCupWPF.Localization.strings.rbMen;
            rbWomen.Content = WorldCupWPF.Localization.strings.rbWomen;
            cbOffline.Content = WorldCupWPF.Localization.strings.cbOffline;
            lblLanguage.Content = WorldCupWPF.Localization.strings.lblLanguage;
            rbEnglish.Content = WorldCupWPF.Localization.strings.rbEnglish;
            rbCroatian.Content = WorldCupWPF.Localization.strings.rbCroatian;
            lblResolution.Content = WorldCupWPF.Localization.strings.lblResolution;
            rb800.Content = WorldCupWPF.Localization.strings.rb800;
            rb1024.Content = WorldCupWPF.Localization.strings.rb1024;
            rbFullScreen.Content = WorldCupWPF.Localization.strings.rbFullScreen;
            btnOK.Content = WorldCupWPF.Localization.strings.btnOK;
            btnCancel.Content = WorldCupWPF.Localization.strings.btnCancel;
        }

        private void rbEnglish_Checked(object sender, RoutedEventArgs e)
        {
            ApplyLanguage("en");
        }

        private void rbCroatian_Checked(object sender, RoutedEventArgs e)
        {
            ApplyLanguage("hr");
        }
    }
}
