using DataRepository.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldCupScore_OOP.Properties;

namespace WorldCupScore_OOP
{
    public partial class SettingsForm : Form
    {
        //public HomePage HomePage { get; set; }
        //private const string cro = "cro";
        //private const string eng = "eng";
        //private const string women = "women";
        //private const string men = "men";
        public AppSettings settings;

        public SettingsForm(AppSettings settings)
        {
            InitializeComponent();
            this.settings = settings;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public void Settings_Load(object sender, EventArgs e)
        {
            rbMen.Checked = settings.Championship == "men";
            rbWomen.Checked = settings.Championship == "women";
            cbOffline.Checked = settings.OfflineMode;
            rbEnglish.Checked = settings.Language == "en-US";
            rbCroatian.Checked = settings.Language == "hr-HR";

            ChangeLanguage(settings.Language);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (rbMen.Checked) settings.Championship = "men";
            if (rbWomen.Checked) settings.Championship = "women";
            settings.OfflineMode = cbOffline.Checked;
            if (rbEnglish.Checked) settings.Language = "en-US";
            if (rbCroatian.Checked) settings.Language = "hr-HR";

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ChangeLanguageRecursive(Control parent, string lang)
        {
            foreach (Control control in parent.Controls)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(HomePage));
                resources.ApplyResources(control, control.Name, new CultureInfo(lang));
                ChangeLanguageRecursive(control, lang);
            }
        }

        private void ChangeLanguage(string lang)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
            ChangeLanguageRecursive(this, lang);
        }
    }
}
