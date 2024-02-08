using DataRepo.DAO;
using DataRepo.Models;
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
    public partial class HomePage : Form
    {
        //hardcoded u pocetku da vidim kako cu
        //string championship = "men";
        IDataRepo repo = new ApiRepo();
        private ISet<Matches> matches;
        private ISet<Results> results;
        private HashSet<Player> players = new HashSet<Player>();
        private HashSet<TeamEvent> teamEvents = new HashSet<TeamEvent>();
        private AppSettingsRepo settingsRepository = new AppSettingsRepo();
        private AppSettings settings = new AppSettings();




        public HomePage()
        {

            InitializeComponent();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            fetchData();
            
        }

        private void fetchData()
        {
            try
            {
                settings = settingsRepository.Load();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to load data! - " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ChangeLanguage(settings.Language);

            matches = repo.GetAllMatches(settings.Championship);
            results = repo.GetAllResults(settings.Championship);
            foreach (Results r in results)
            {
                //kodovi drzava skraceno
                toolStripRepresentations.Items.Add(r.Fifa_code);
            }

            try
            {
                if (settings.OfflineMode)

                {
                    repo = new FileRepository();
                }
                else
                {
                    repo = new ApiRepo();
                }
                matches = (ISet<Matches>)repo.GetAllMatches(settings.Championship);
                results = (ISet<Results>)repo.GetAllResults(settings.Championship);

                toolStripRepresentations.Items.Clear();
                dataGridAllPlayers.Rows.Clear();
                dataGridFilter.Rows.Clear();
                dataGridFavorite.Rows.Clear();

                foreach (Results r in results)
                {
                    toolStripRepresentations.Items.Add(r.Fifa_code);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data! - " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripRepresentations_TextChanged(object sender, EventArgs e)
        {
            string fifaCode = toolStripRepresentations.Text;
            dataGridAllPlayers.Rows.Clear();
            dataGridFilter.Rows.Clear();
            players.Clear();
            foreach (var match in matches)
            {
                if (match.HomeTeam.Code == fifaCode)
                {
                    players.UnionWith(match.HomeTeamStatistics.StartingEleven);
                    players.UnionWith(match.HomeTeamStatistics.Substitutes);
                }
                else if (match.AwayTeam.Code == fifaCode)
                {
                    players.UnionWith(match.AwayTeamStatistics.StartingEleven);
                    players.UnionWith(match.AwayTeamStatistics.Substitutes);
                }

                //textBox1.Text += match.HomeTeam.Code + " - " + match.AwayTeam.Code + "\t";
                //textBox1.Text += players.Count + "\r\n";
            }


            //foreach za zute kartone i golove
            foreach (var match in matches)
            {
                if (match.HomeTeam.Code == fifaCode)
                {
                    players.UnionWith(match.HomeTeamStatistics.StartingEleven);
                    players.UnionWith(match.HomeTeamStatistics.Substitutes);
                }
                else if (match.AwayTeam.Code == fifaCode)
                {
                    players.UnionWith(match.AwayTeamStatistics.StartingEleven);
                    players.UnionWith(match.AwayTeamStatistics.Substitutes);
                }

                // gol po igracu
                foreach (var teamEvent in match.HomeTeamEvents.Concat(match.AwayTeamEvents))
                {
                    if (teamEvent.TypeOfEvent == "goal" && teamEvent.Player != null)
                    {
                        var player = players.FirstOrDefault(p => p.Name == teamEvent.Player);
                        if (player != null)
                        {
                            player.Goals++;
                        }
                    }
                }
                // Count cards for each player POPRAVLJENO
                foreach (var evt in teamEvents.Concat(match.AwayTeamEvents))
                {
                    if (evt.TypeOfEvent == "yellow-card" && evt.Player != null)
                    {
                        var player = players.FirstOrDefault(p => p.Name == evt.Player);
                        if (player != null)
                        {
                            player.YellowCards++;
                        }
                    }
                }
            }


            foreach (var player in players)
            {
                dataGridAllPlayers.Rows.Add(null, player.Name, player.ShirtNumber, player.Position, player.Captain);
                dataGridFilter.Rows.Add(null, player.Name, player.Goals, player.YellowCards);
            }
            dataGridAllPlayers.Refresh();
            dataGridFilter.Refresh();

        }


        private void btnAddToFavorites_Click(object sender, EventArgs e)
        {
            // Check if any row is selected in dataGridAllPlayers
            if (dataGridAllPlayers.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridAllPlayers.SelectedRows[0];

                // Check if the player is already in dataGridFavorites
                bool isDuplicate = false;
                foreach (DataGridViewRow row in dataGridFavorite.Rows)
                {
                    bool duplicateFound = true;
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        if (!row.Cells[i].Value.Equals(selectedRow.Cells[i].Value))
                        {
                            duplicateFound = false;
                            break;
                        }
                    }
                    if (duplicateFound)
                    {
                        isDuplicate = true;
                        break;
                    }
                }

                if (!isDuplicate)
                {
                    // Clone the row to add it to the other DataGridView
                    DataGridViewRow newRow = (DataGridViewRow)selectedRow.Clone();

                    for (int i = 0; i < selectedRow.Cells.Count; i++)
                    {
                        newRow.Cells[i].Value = selectedRow.Cells[i].Value;
                    }

                    
                    dataGridFavorite.Rows.Add(newRow);

                    if (dataGridFavorite.Rows.Count > 3)
                    {
                        btnAddToFavorites.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("This player is already in favorites.");
                }
            }
            else
            {
                MessageBox.Show("Please select a row in dataGridAllPlayers to add to favorites.");
            }
        }

        private void btnRemoveFavorite_Click(object sender, EventArgs e)
        {
            if (dataGridFavorite.SelectedRows.Count > 0)
            {
                // Remove the selected row from dataGridFavorite
                dataGridFavorite.Rows.Remove(dataGridFavorite.SelectedRows[0]);

                if (dataGridFavorite.Rows.Count <= 3)
                {
                    btnAddToFavorites.Enabled = true; // Enable button

                }
            }
            else
            {
                MessageBox.Show("Please select a row in dataGridFavorite to remove from favorites.");
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm(settings);
            settingsForm.ShowDialog();

            if (settingsForm.DialogResult == DialogResult.OK)
            {
                settings = settingsForm.settings;
                saveSettings();
                fetchData();
                

            }

        }

        private void saveSettings()
        {
            try
            {
                settingsRepository.Save(settings);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HomePage_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("Do you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            e.Cancel = (res == DialogResult.No);
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
