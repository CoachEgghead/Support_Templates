using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupportTemplates
{
    public partial class UserSettings : Form
    {
        public UserSettings()
        {
            InitializeComponent();

            // Pull the default template setting
            int defaultTemplate = Properties.Settings.Default.DefaultTemplate;

            // Set Autobackup value
            int AutoBackupVal = Properties.Settings.Default.AutoBackup;
            backupTkb.Value = AutoBackupVal;

            // Set the Autobackup frequency value
            var ABFrequencyVal = Properties.Settings.Default.ABFrequency;
            // Gather information for combobox list of template types
            List<string> ABDays = GetItemsDefaultAutoBackupDays();
            //Add them to the ComboBox
            backupFreqCb.Items.AddRange(ABDays.ToArray());
            backupFreqCb.SelectedItem = ABFrequencyVal;

            // Set the Autobackup location value
            var ABLocationVal = Properties.Settings.Default.ABLocation;
            backupLocTb.Text = ABLocationVal.ToString();

            // Set the Autoback date
            var ABDateVal = Properties.Settings.Default.ABDate.ToString();
            lastBackupTb.Text = ABDateVal;

            // Gather information for combobox list of template types
            List<string> Items = Form1.GetItemsFromXmlUsingTagNames("", "type");
            //Add them to the ComboBox
            defaultTempCb.Items.AddRange(Items.ToArray());
            defaultTempCb.SelectedIndex = defaultTemplate;

            // Enable the autobackup fields if default value is Yes
            if (AutoBackupVal == 1)
            {
                backupFreqLbl.Enabled = true;
                backupFreqCb.Enabled = true;
                backupDaysLbl.Enabled = true;
                backupLocationLbl.Enabled = true;
                backupLocTb.Enabled = true;
                backupDateLbl.Enabled = true;
            }

            int defaultModifier = Properties.Settings.Default.DefaultHotKey1;
            var defaultModText = "";
            switch (defaultModifier)
            {
                case 1:
                    defaultModText = "Alt";
                    break;
                case 2:
                    defaultModText = "Control";
                    break;
                case 4:
                    defaultModText = "Shift";
                    break;
                case 8:
                    defaultModText = "WinKey";
                    break;
                default:
                    defaultModText = "Control";
                    break;
            }
            var defaultKeyCode = Properties.Settings.Default.DefaultHotKey2;
            defaultHK.Text = defaultModText + "-" + defaultKeyCode;

        }

        public void UserSettings_FormClosing(Object sender, FormClosingEventArgs e)
        {
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            int currDefaultTemplate = defaultTempCb.SelectedIndex;
            Properties.Settings.Default.DefaultTemplate = currDefaultTemplate;
            Properties.Settings.Default.AutoBackup = backupTkb.Value;

            if (backupTkb.Value== 1)
            {
                Properties.Settings.Default.AutoBackup = backupTkb.Value;
                Properties.Settings.Default.ABFrequency = backupFreqCb.SelectedItem.ToString();
                Properties.Settings.Default.ABLocation = backupLocTb.Text.ToString();
            }

            //12-18-18 Hotkey code
            string hotKeyValue = defaultHK.Text;
            string[] subStrings = hotKeyValue.Split('-');
            var ModifierKeys = subStrings[0];
            int defaultModVal = 0;
            switch (ModifierKeys)
            {
                case "Alt":
                    defaultModVal = 1;
                    break;
                case "Control":
                    defaultModVal = 2;
                    break;
                case "Shift":
                    defaultModVal = 4;
                    break;
                case "WinKey":
                    defaultModVal = 8;
                    break;
                default:
                    defaultModVal = 2;
                    break;
            }
            Properties.Settings.Default.DefaultHotKey1 = defaultModVal;
            Properties.Settings.Default.DefaultHotKey2 = subStrings[1];

            Properties.Settings.Default.Save();

            MessageBox.Show("Your settings have been saved!\n\r" +
                "\n\rIf you changed the default hotkey, it will take effect the next time the app is started.", "Save Settings");
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Open droplist when click anywhere in the droplist
        private void defaultTempCb_Click(object sender, EventArgs e)
        {
            defaultTempCb.DroppedDown = true;
        }

        private void backupTkb_Scroll(object sender, EventArgs e)
        {
            // If Yes then Enable backup days and location fields
            // 0=No 1=Yes
            if (backupTkb.Value == 1)
            {
                backupFreqLbl.Enabled = true;
                backupFreqCb.Enabled = true;
                backupDaysLbl.Enabled = true;
                backupLocationLbl.Enabled = true;
                backupLocTb.Enabled = true;
                backupDateLbl.Enabled = true;
            } else
            {
                backupFreqLbl.Enabled = false;
                backupFreqCb.Enabled = false;
                backupDaysLbl.Enabled = false;
                backupLocationLbl.Enabled = false;
                backupLocTb.Enabled = false;
                backupDateLbl.Enabled = false;
            }
        }

        // This is to build the drop-list.
        public static List<string> GetItemsDefaultAutoBackupDays()
        {
            //Create a list to store all the items.
            List<string> ABDays = new List<string>();
            for (int a = 1; a <= 30; a++)
            {
                ABDays.Add(a.ToString());
            }
            ABDays.Add("60");
            ABDays.Add("90");
            ABDays.Add("120");

            return ABDays;
        }

        private void backupLocTb_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.RootFolder = Environment.SpecialFolder.MyComputer;
            //dlg.SelectedPath = @"C:\";
            dlg.ShowDialog();
            if (dlg.SelectedPath != "")
            {
                backupLocTb.Text = dlg.SelectedPath;
            }
        }

        // 12-18-18 Hotkey code
        private void defaultHK_KeyDown(object sender, KeyEventArgs e)
        {
            string modifier = e.Modifiers.ToString(); // 
            string key_string = e.KeyCode.ToString(); // 
            defaultHK.Text = modifier + "-" + key_string;
        }
    }
}
