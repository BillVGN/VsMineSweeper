using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;

namespace MyMineSweeper
{
    public partial class Configuration : Form
    {

        private readonly Dictionary<string, string> configNames = new Dictionary<string, string>();

        private NameValueCollection AllSets;

        public Configuration()
        {
            InitializeComponent();
            SetConfigDictionary();
            InitConfigs();
        }

        private void SetConfigDictionary()
        {
            configNames["numMinesQty"]  = "MINES_QTY";
            configNames["numRows"]      = "NUM_ROWS";
            configNames["numCols"]      = "NUM_COLS";
            configNames["numCellSize"]  = "CELL_SIZE";
            configNames["numCoinsTip"]  = "COINS_TIP";
        }

        private void InitConfigs()
        {
            AllSets = ConfigurationManager.AppSettings;
            NumericUpDown numericUpDown;
            try
            {
                foreach(KeyValuePair<string, string> kvp in configNames)
                {
                    numericUpDown = (NumericUpDown)Controls[kvp.Key];
                    numericUpDown.Value = Decimal.Parse(AllSets[kvp.Value]);
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void SaveConfigs()
        {
            NumericUpDown numUpDown;

            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;

                foreach (KeyValuePair<string, string> kvp in configNames)
                {
                    numUpDown = (NumericUpDown)Controls[kvp.Key];
                    settings[kvp.Value].Value = numUpDown.Value.ToString();
                }

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
                AllSets = ConfigurationManager.AppSettings;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            SaveConfigs();
            Visible = false;
        }

        public string GetSetting(string configName)
        {
            return AllSets[configName];
        }
    }

    public static class SettingsName
    {
        public static string MINESQTY  = "MINES_QTY";
        public static string ROWS      = "NUM_ROWS";
        public static string COLS      = "NUM_COLS";
        public static string CELLSIZE  = "CELL_SIZE";
        public static string COINSTIP  = "COINS_TIP";
    }
}
