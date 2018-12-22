using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml;
using System.Xml.Linq;
using System.Threading;
using System.Security.Principal;
using System.Deployment.Application;
using Microsoft.Win32;
using MessageBox = System.Windows.Forms.MessageBox;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Documents;
using System.Windows.Markup;

namespace SupportTemplates
{
    public partial class Form1 : Form
    {

        About af;
        //Rename_Template rt;
        ExportXML ex;
        UserSettings us;
        VersionInfo vf;

        FontDialog fontDlg = new FontDialog();
        FontDialog fontDlgLB = new FontDialog();
        FontDialog fontDlgDB = new FontDialog();

        public XmlDocument xm = new XmlDocument();
        /// <summary>
        /// 
        /// </summary>
        public XDocument xdoc;
        /// <summary>
        /// 
        /// </summary>
        public List<template> templates;

        /// <summary>
        /// 
        /// </summary>
        public string xmlFilePath = "";
        public string xmlFilePath5 = "c:\\Users\\" + NameWithoutDomain(System.Security.Principal.WindowsIdentity.GetCurrent().Name) + "\\AppData\\Local\\VirtualStore\\Program Files (x86)\\Egghead Apps\\Support Templates\\templates.xml";

        public int defaultTemplate = 0;

        // 7-24-18 no longer need the 2 different paths after adding custom path for templates.xml
        //   Leaving commented out as informational.
        //string xmlFilePath1 = System.Windows.Forms.Application.CommonAppDataPath; // Necessary for deployment
        //string xmlFilePath2 = System.Windows.Forms.Application.StartupPath; // Used for debugging runs
        /*
         * C:\Users\Marty\AppData\Local\VirtualStore\Program Files (x86)\Egghead Apps\Support Templates
         * Above is the 1.6.x path for the template.xml file.
        */

        string textbx = "//template";
        // string list = "//name"; // Not needed ATM used for on the fly node search
        // string combo = "//type"; // Not needed ATM used for on the fly node search

        //private IEnumerable<template> mytmplt; // Not needed ATM .. not sure why it was needed earlier

        // 12-18-18 Create hotkey function to bring app to foreground
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_MAXIMIZE = 9; // Restore window to foreground as it was previously sized

        /// <summary>
        /// 
        /// </summary>
        public Form1()
        {

            InitializeComponent();

            // 12-19-18 Check for update.  If available turn on the menu strip alert.
            CheckForUpdate();

            Thread.Sleep(1500); // Sleep 1.5 seconds for splash screen

            // Enable selecting all in the search field
            this.Search_Tb.Click += new System.EventHandler(Search_Tb_Click);
            Search_Tb.ForeColor = System.Drawing.Color.LightGray;
            Search_Tb.Text = "Search ...";
            this.Search_Tb.Leave += new System.EventHandler(this.Search_Tb_Leave);
            this.Search_Tb.Enter += new System.EventHandler(this.Search_Tb_Enter);

            // 12-18-18 Hotkey code
            int id = 0;     // The id of the hotkey. 
            int defaultHK1 = Properties.Settings.Default.DefaultHotKey1;
            var defaultHK2 = Properties.Settings.Default.DefaultHotKey2;
            Keys defaultKey = (Keys)Enum.Parse(typeof(Keys), defaultHK2);
            RegisterHotKey(this.Handle, id, defaultHK1, defaultKey.GetHashCode());       // Register saved default as global hotkey. 

        }

        /// <summary>
        /// 
        /// </summary>
        public class template
        {
            public string template_Name { get; set; }
            public string template_Text { get; set; }
            public string template_Type { get; set; }
            public string template_Desc { get; set; }
        }

        /*
         * This fills the Template list box with items in the templates.xml file.
         * The ListBox is sorting automatically
         */
        /// <summary>
        /// 
        /// </summary>
        public void loadList()
        {
            listBox1.Items.Clear();
            TemplateText_tb.Text = "";
            tempDesc_tb.Text = "";

            xm.Load(xmlFilePath);
            XmlNodeList Xn = xm.SelectNodes(textbx); // textbx defines all templates
            foreach (XmlNode xNode in Xn)
            {
                if (comboBox1.SelectedItem != null)
                {
                    if (xNode["type"].InnerText == comboBox1.SelectedItem.ToString())
                    {
                        listBox1.Items.Add(xNode["name"].InnerText);
                    }
                }
            }

            /*
             * Adding here to rebuild the validation check
             * so that it's run every time the list is rebuilt
            */
            xdoc = XDocument.Load(xmlFilePath);
            templates = xdoc.Root.Elements("template")
                .Select(tm => new template
                {
                    template_Name = (string)tm.Element("name"),
                    template_Text = (string)tm.Element("text"),
                    template_Type = (string)tm.Element("type"),
                    template_Desc = (string)tm.Element("desc")
                }).ToList();

            //TemplateText_tb.Text = xmlFilePath5;

            //var fileName = Path.Combine(Environment.GetFolderPath(
            //    Environment.SpecialFolder.LocalApplicationData), "templates.xml");

            // 8-22-18 If the selected type is Search Results go pull the search again
            //  Due to saving from Search Results clears the search results .. QOL so don't have to re-search again
            if (comboBox1.SelectedItem.ToString() == "Search Results")
            {
                searchTmplt();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void xmlFileCheck()
        {
            // Create a permanent filepath
            string defaultPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "EggheadApps\\SupportTemplates");
            string defaultFileName = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "EggheadApps\\SupportTemplates\\templates.xml");
            if (!Directory.Exists(defaultPath))
            {
                Directory.CreateDirectory(defaultPath);
            }

            if (File.Exists(defaultFileName))
            {
                xmlFilePath = defaultFileName;
            }
            else
            {
                // If a previous installation's templates.xml file exists, prompt user to import.  Best I can do to salvage the prior builds data.
                if (File.Exists(xmlFilePath5))
                {
                    DialogResult answer = System.Windows.Forms.MessageBox.Show("It appears you are upgrading from an older version of Support Templates.  " +
                    "The upgrade found what appears to be your old template file.  Do you wish to import it? \n\r" +
                    "Yes = Import Previous Template File | No = Start With Blank Template File", "Confirm Upgrade", MessageBoxButtons.YesNo);
                    if (answer == DialogResult.Yes)
                    {
                        File.Copy(xmlFilePath5, defaultFileName, true);
                    }
                    else
                    {
                        // Initial load of the app so create the template file
                        //File.Copy(@"DefaultXML.xml", defaultPath + "\\DefaultXML.xml", true);
                        File.Copy(@"DefaultXML.xml", defaultFileName, true);
                        xmlFilePath = defaultFileName;
                    }
                }
                else
                {
                    // Initial load of the app so create the template file
                    //File.Copy(@"DefaultXML.xml", defaultPath + "\\DefaultXML.xml", true);
                    File.Copy(@"DefaultXML.xml", defaultFileName, true);
                    xmlFilePath = defaultFileName;
                }
            }
        }

        /// <summary>
        /// This is where the form is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Form1_Load(object sender, EventArgs e)
        {

            /*
             * 7-24-18 This is changed now as we use a custom path to store the templates.xml file.
             *  Now we check for the custom path and set accordingly.
             */

            // Go set the xmlFilePath variable.  If doesn't find it then create it.  This is the first time the app is run.
            xmlFileCheck();

            // templates.xml just got created so go run the check again to set xmlFilePath
            if (xmlFilePath == "")
            {
                xmlFileCheck();
            }

            // Verify we have the new <type> node for the drop list (11/29/2017)
            xmlNodeCheck();

            // Base the size of the window on default or custom settings
            int initWidth = Properties.Settings.Default.InitialWidth;
            int initHeight = Properties.Settings.Default.InitialHeight;
            Size = new System.Drawing.Size(initWidth, initHeight);

            // Base left pane size on default or custom settings
            int initSplitter = Properties.Settings.Default.InitialSplitterDiff;
            splitContainer1.SplitterDistance = initSplitter;

            // Base the template text box colors on default or custom settings
            var initTBForeColor = Properties.Settings.Default.InitialTBForeColor;
            var initTBBackColor = Properties.Settings.Default.InitialTBBackColor;
            TemplateText_tb.BackColor = initTBBackColor;
            TemplateText_tb.ForeColor = initTBForeColor;

            // Base the listbox colors on default or custom settings
            var initLBForeColor = Properties.Settings.Default.InitialLBForeColor;
            var initLBBackColor = Properties.Settings.Default.InitialLBBackColor;
            listBox1.ForeColor = initLBForeColor;
            listBox1.BackColor = initLBBackColor;

            // Base the desc text box colors on default or custom settings
            var initDBForeColor = Properties.Settings.Default.InitialDBForeColor;
            var initDBBackColor = Properties.Settings.Default.InitialDBBackColor;
            tempDesc_tb.BackColor = initDBBackColor;
            tempDesc_tb.ForeColor = initDBForeColor;

            // Pull the default template setting
            defaultTemplate = Properties.Settings.Default.DefaultTemplate;

            // Gather information for combobox list of template types
            List<string> Items = Form1.GetItemsFromXmlUsingTagNames(xmlFilePath, "type");
            //Add them to the ComboBox
            comboBox1.Items.AddRange(Items.ToArray());
            //comboBox1.SelectedIndex = 4;
            comboBox1.SelectedIndex = defaultTemplate;

            // Set CheckBox1 to Checked by default
            //checkBox1.Checked = true;

            // Set Autobackup values
            int AutoBackup = Properties.Settings.Default.AutoBackup;
            int AutoBackupVal = Properties.Settings.Default.AutoBackup;
            var ABFrequencyVal = Properties.Settings.Default.ABFrequency;
            var ABLocationVal = Properties.Settings.Default.ABLocation;
            DateTime ABDateVal = Properties.Settings.Default.ABDate;
            DateTime ABCurrDateVal = DateTime.Now;

            // Reload the template list
            loadList();

            // Check for font size & style of main text box
            Font initFont = Properties.Settings.Default.InitialTBFont;
            TemplateText_tb.Font = new Font(initFont.FontFamily, initFont.Size, initFont.Style);

            // Check for font size & style of list box
            Font initFontLB = Properties.Settings.Default.InitialLBFont;
            listBox1.Font = new Font(initFontLB.FontFamily, initFontLB.Size, initFontLB.Style);

            // Check for font size & style of desc text box
            Font initDBFont = Properties.Settings.Default.InitialDBFont;
            tempDesc_tb.Font = new Font(initDBFont.FontFamily, initDBFont.Size, initDBFont.Style);

            // Set the value of the slider to the current font of the text box
            resetTrackBarValue();

            // Check to see if AutoBackup needs to occur; if so perform autobackup
            if (AutoBackup == 1)
            {
                // ABDateVal = Convert.ToDateTime("11/8/2018"); // Temp date to test functionality
                AutoBackupProcess(ABDateVal, ABCurrDateVal, ABFrequencyVal, ABLocationVal);
            }

        }

        // Change the font size default to be the current value on close
        // Save all custom changes
        public void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            float currTBFontSize = TemplateText_tb.Font.Size;
            float currLBFontSize = listBox1.Font.Size;
            float currDBFontSize = tempDesc_tb.Font.Size;
            var currTBFontFC = TemplateText_tb.ForeColor;
            var currTBFontBC = TemplateText_tb.BackColor;
            var currLBFontFC = listBox1.ForeColor;
            var currLBFontBC = listBox1.BackColor;
            var currDBFontFC = tempDesc_tb.ForeColor;
            var currDBFontBC = tempDesc_tb.BackColor;
            Properties.Settings.Default.InitialTBSize = currTBFontSize;
            Properties.Settings.Default.InitialLBSize = currLBFontSize;
            Properties.Settings.Default.InitialDBSize = currDBFontSize;
            Properties.Settings.Default.InitialTBForeColor = currTBFontFC;
            Properties.Settings.Default.InitialTBBackColor = currTBFontBC;
            Properties.Settings.Default.InitialLBForeColor = currLBFontFC;
            Properties.Settings.Default.InitialLBBackColor = currLBFontBC;
            Properties.Settings.Default.InitialDBForeColor = currDBFontFC;
            Properties.Settings.Default.InitialDBBackColor = currDBFontBC;
            Properties.Settings.Default.InitialTBFont = TemplateText_tb.Font;
            Properties.Settings.Default.InitialLBFont = listBox1.Font;
            Properties.Settings.Default.InitialDBFont = tempDesc_tb.Font;
            Properties.Settings.Default.InitialHeight = Size.Height;
            Properties.Settings.Default.InitialWidth = Size.Width;
            Properties.Settings.Default.InitialSplitterDiff = splitContainer1.SplitterDistance;
            Properties.Settings.Default.Save();

            // 12-18-18 Hotkey code to unregister hotkey
            UnregisterHotKey(this.Handle, 0);       // Unregister hotkey with id 0 before closing the form. You might want to call this more than once with different id values if you are planning to register more than one hotkey.

        }

        /// <summary>
        /// Item selected in Template List Box.
        /// <remarks>
        /// When user selects a template in the Template List Box, the XML is read and returns the associated text for that template name.
        /// </remarks>
        /// </summary>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                TemplateText_tb.Clear(); // Clear text box .. fixes issue with search highlighting where first item in list would cause all items to be highlighted.
                tempDesc_tb.Clear(); // Clear text box .. fixes issue with search highlighting where first item in list would cause all items to be highlighted.
                XmlNodeList xnList = xm.SelectNodes(textbx); // textbx defines all templates
                foreach (XmlNode xn in xnList)
                {
                    if (xn["name"].InnerText == listBox1.SelectedItem.ToString())
                    {
                        TemplateText_tb.Text = xn["text"].InnerText;
                        tempDesc_tb.Text = xn["desc"].InnerText;
                    }
                }

                if (Search_Tb.Text != "Search ...")
                {
                    HighlightWords(Search_Tb.Text);
                }
            }
        }

        /// <summary>
        /// Save button is clicked.
        /// <remarks>
        /// When user clicks the save button, the application validates:
        /// --- That the template text box has text present.
        /// --- If the new template name box is empty it assumes this is an update and prompts the user to confirm the update.
        /// --- If the new template name has a value it checks to see if it exists already in the list.  If it exists, the save is aborted. If it doesn't exist the user is prompted to confirm the save.
        /// Once saved, the Template list is refreshed.
        /// </remarks>
        /// </summary>
        private void Save_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TemplateText_tb.Text))
            {
                System.Windows.Forms.MessageBox.Show("Must Enter Template Text!", "Warning!");
            }
            else if (string.IsNullOrEmpty(NewTemplateName_tb.Text)) // Update existing template
            {
                if (listBox1.SelectedIndex >= 0)
                {
                    DialogResult answer = System.Windows.Forms.MessageBox.Show("Are you sure you wish to update the template?", "Confirm Save", MessageBoxButtons.YesNo);
                    if (answer == DialogResult.Yes)
                    {
                        int updOK = 0;
                        XmlDocument xdocUpt = new XmlDocument();
                        xdocUpt.Load(xmlFilePath);
                        foreach (XmlElement element in xdocUpt.SelectNodes("//template"))
                        {
                            foreach (XmlElement element1 in element)
                            {
                                if (string.Equals(element.SelectSingleNode(@".//name").InnerText, listBox1.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase))
                                {
                                    element.SelectSingleNode(@".//text").InnerText = TemplateText_tb.Text.ToString();
                                    element.SelectSingleNode(@".//desc").InnerText = tempDesc_tb.Text.ToString();
                                    // 8-22-18 If the comboBox1 is 'Search Results' don't update the type, leave it the same
                                    //  Allows for updating from Search Results display
                                    if (comboBox1.SelectedItem.ToString() != "Search Results")
                                    {
                                        element.SelectSingleNode(@".//type").InnerText = comboBox1.SelectedItem.ToString();
                                    }
                                    xdocUpt.Save(xmlFilePath);
                                    System.Windows.Forms.MessageBox.Show("Template has been saved.", "Update Template");
                                    updOK = 3;
                                    break;
                                }
                            }
                            if (updOK == 3)
                            {
                                break;
                            }
                        }
                        loadList();
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("No Template Selected.\r\nYou must either select a template to update or enter a new name to save as.", "Warning!");
                }
            }
            else // Copy to new name or create a new template
            {
                var myOutput =
                    from t in templates
                    where t.template_Name.ToLower() == NewTemplateName_tb.Text.ToLower()
                    select t;
                int foundItems = myOutput.Count();

                string tmpltType = "";
                if (comboBox1.SelectedItem.ToString() != "Search Results") // Creating a new template
                {
                    tmpltType = comboBox1.SelectedItem.ToString();
                }
                else if (listBox1.SelectedIndex >= 0) // Copying to a new name
                {
                    // 8-23-2018 Find the current template type for Search Result saves
                    var currTempType =
                        from t in templates
                        where t.template_Name.ToLower() == listBox1.SelectedItem.ToString().ToLower()
                        select t.template_Type.ToString();
                    tmpltType = currTempType.First();
                }
                else // Default -- shouldn't be used
                {
                    tmpltType = "Templates";
                }

                if (foundItems > 0)
                {
                    MessageBox.Show("Template name already exists.\r\nClear the new template name field to update an existing template.", "Warning!");
                }
                else
                {
                    DialogResult answer = System.Windows.Forms.MessageBox.Show("Are you sure you wish to save this template?", "Confirm Save", MessageBoxButtons.YesNo);
                    if (answer == DialogResult.Yes)
                    {
                        xdoc.Root.Add(
                            new XElement("template",
                                new XElement("name", NewTemplateName_tb.Text.ToString()),
                                new XElement("text", TemplateText_tb.Text.ToString()),
                                new XElement("type", tmpltType),
                                new XElement("desc", tempDesc_tb.Text.ToString())
                            ));
                        // new XElement("type", comboBox1.SelectedItem.ToString()) // copied out of the above just in case I need later
                        xdoc.Root.Save(xmlFilePath);
                        MessageBox.Show("Template Has Been Saved.", "Saved New Template");
                        NewTemplateName_tb.Text = "";
                        loadList();
                    }
                }

            }
        }

        /// <summary>
        /// Delete button is clicked.
        /// <remarks>
        /// When the delete button is clicked, the user is prompted to confirm the removal of the template.
        /// Once deleted, the Template list is refreshed.
        /// </remarks>
        /// </summary>
        private void Delete_btn_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                DialogResult answer = System.Windows.Forms.MessageBox.Show("Are you sure you wish to delete this template?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)
                {
                    string delSelect = listBox1.SelectedItem.ToString();
                    XmlDocument xdocDel = new XmlDocument();
                    xdocDel.Load(xmlFilePath);
                    XmlNode t = xdocDel.SelectSingleNode("/templates/template[name='" + delSelect + "']");
                    t.ParentNode.RemoveChild(t);
                    xdocDel.Save(xmlFilePath);
                    System.Windows.Forms.MessageBox.Show("Template Has Been Deleted.", "Delete Template");
                    loadList();
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No Template Selected.\r\nYou must select a template to delete.", "Warning!");
            }
        }

        /// <summary>
        /// Clear button is clicked.
        /// <remarks>
        /// When the user clicks the clear button, the template text box is cleared of all text.
        /// </remarks>
        /// </summary>
        private void Clear_btn_Click(object sender, EventArgs e)
        {
            // 11/7/18 
            //  When clicking clear from a search return to the default template display.  QoL change - No longer have to click the template list after a search
            if (comboBox1.SelectedItem.ToString() == "Search Results") // Creating a new template
            {
                comboBox1.SelectedIndex = Properties.Settings.Default.DefaultTemplate;
            }

            TemplateText_tb.Text = "";
            tempDesc_tb.Text = "";
            NewTemplateName_tb.Text = "";
            listBox1.ClearSelected();
        }

        /// <summary>
        /// Copy to Clipboard button is clicked.
        /// <remarks>
        /// When the Copy to Clipboard button is clicked, the template text box contents are placed in the user's clipboard.
        /// </remarks>
        /// </summary>
        private void Copy_btn_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TemplateText_tb.Text))
            {
                if (TemplateText_tb.SelectionLength > 0)
                {
                    //TemplateText_tb.Copy();
                    System.Windows.Forms.Clipboard.SetText(TemplateText_tb.SelectedText.Replace("\n", "\r\n"), System.Windows.Forms.TextDataFormat.Text);
                    TemplateText_tb.SelectionLength = 0;
                }
                else
                {
                    System.Windows.Forms.Clipboard.SetText(TemplateText_tb.Text.Replace("\n", "\r\n"), System.Windows.Forms.TextDataFormat.Text);
                }
            }
        }

        /// <summary>
        /// About button clicked.
        /// <remarks>
        /// When the About button is clicked, a popup dialog is displayed showing version information about the application.
        /// </remarks>
        /// </summary>
        private void About_btn_Click(object sender, EventArgs e)
        {
            af = new About();
            af.StartPosition = FormStartPosition.CenterScreen;
            af.Show();
            af.Refresh();
        }

        /// <summary>
        /// Reset to Default button clicked.
        /// <remarks>
        /// When the Reset to Default button is clicked the user is prompted to cornfirm the resetting of the templates XML file.
        /// If confirmed, the DefaultXML.xml file is copied over the templates.xml file (overwrite).
        /// The Tmeplate list is refreshed.
        /// </remarks>
        /// </summary>
        private void Reset_btn_Click(object sender, EventArgs e)
        {
            DialogResult answer = System.Windows.Forms.MessageBox.Show("Are you sure you wish to reset the template list to it's orginal state?  Your existing templates will be lost!", "Confirm Reset", MessageBoxButtons.YesNo);
            if (answer == DialogResult.Yes)
            {
                //File.Copy(@"DefaultXML.xml", @"templates.xml",true);
                File.Copy(@"DefaultXML.xml", xmlFilePath, true);
                System.Windows.Forms.MessageBox.Show("Template listing reset to default state.", "Reset Templates");
                loadList();
            }
        }

        /// <summary>
        /// Create a backup copy of the XML file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Backup_btn_Click(object sender, EventArgs e)
        {
            string xmlPath = @"C:\";
            System.Windows.Forms.SaveFileDialog saveFile = new System.Windows.Forms.SaveFileDialog();
            saveFile.Filter = "XML Files|*.xml";
            saveFile.Title = "Backup to an Xml File";
            saveFile.FileName = "templates_bk.xml";
            saveFile.InitialDirectory = @"C:\";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                xmlPath = saveFile.FileName;
                File.Copy(xmlFilePath, @xmlPath, true);
                //File.Copy(@"templates.xml", @xmlPath, true);
                System.Windows.Forms.MessageBox.Show("Your templates file has been successfully backed up to:\r\n" + xmlPath, "Backup Result");
            }
        }

        /// <summary>
        /// Start the import process and determine if the user wants to overwrite the existing XML or insert the new templates into the existing XML.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Import_btn_Click(object sender, EventArgs e)
        {
            using (Import_Options io = new Import_Options())
            {
                io.ShowDialog();
                string importValue = io.get_importValue();
                if (importValue != "")
                {
                    if (importValue == "o")
                    {
                        Import_Overwrite();
                    }
                    else if (importValue == "i")
                    {
                        Import_Insert();
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("There was an error trying to pick an import type!", "Import Error");
                    }
                }
            }
        }

        /*
         * Import a template XML and insert it at the end of the existing XML.  Create a backup of the existing XML onto the user's desktop
         *   to avoide corruption of the existing XML.
         */
        public void Import_Insert()
        {
            string xmlPath = @"C:\";
            string newTempName = "";
            string newTempText = "";
            string newTempType = "";
            string newTempDesc = "";
            System.Windows.Forms.SaveFileDialog saveFile = new System.Windows.Forms.SaveFileDialog();
            saveFile.Filter = "XML Files|*.xml";
            saveFile.Title = "Import an Xml File";
            saveFile.FileName = "templates_bk.xml";
            saveFile.InitialDirectory = @"C:\";
            saveFile.OverwritePrompt = false;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                DialogResult answer = System.Windows.Forms.MessageBox.Show("Are you sure you wish to import this template XML?", "Confirm Import", MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)
                {
                    xmlPath = saveFile.FileName;

                    // Backup the existing template file to desktop 
                    var desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                    var desktopFile = Path.Combine(desktopFolder, "templates_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xml");
                    File.Copy(xmlFilePath, @desktopFile, true); // backup copy
                    //File.Copy(@"templates.xml", @desktopFile, true); // backup copy

                    xm.Load(xmlPath);
                    XmlNodeList Xn = xm.SelectNodes(textbx); // textbx defines all templates
                    foreach (XmlNode xNode in Xn)
                    {
                        var myOutput =
                            from t in templates
                            where t.template_Name.ToLower() == xNode["name"].InnerText.ToLower()
                            select t;
                        int foundItems = myOutput.Count();
                        if (foundItems > 0)
                        {
                            newTempName = xNode["name"].InnerText + "_new";
                        }
                        else
                        {
                            newTempName = xNode["name"].InnerText;
                        }
                        newTempText = xNode["text"].InnerText;
                        newTempType = xNode["type"].InnerText;
                        if (xNode["desc"] != null)
                        {
                            newTempDesc = xNode["desc"].InnerText;
                        }
                        else
                        {
                            newTempDesc = "";
                        }

                        xdoc.Root.Add(
                            new XElement("template",
                                new XElement("name", newTempName),
                                new XElement("text", newTempText),
                                new XElement("type", newTempType),
                                new XElement("desc", newTempDesc)
                            ));

                        newTempName = ""; //Reset to blank to make sure nothing lingers
                        newTempText = "";
                        newTempType = "";
                        newTempDesc = "";

                    }
                    xdoc.Root.Save(xmlFilePath);
                    System.Windows.Forms.MessageBox.Show("Your templates file has been successfully imported.\r\nA copy of your previous template file has been saved to your desktop as templates_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xml.", "Import Result");
                    NewTemplateName_tb.Text = "";
                    loadList();
                }
            }
        }

        /*
        * Import a template XML and overwrite the existing XML.  Create a backup of the existing XML onto the user's desktop
        *   to avoide corruption of the existing XML.
        */
        public void Import_Overwrite()
        {
            string xmlPath = @"C:\";
            System.Windows.Forms.SaveFileDialog saveFile = new System.Windows.Forms.SaveFileDialog();
            saveFile.Filter = "XML Files|*.xml";
            saveFile.Title = "Import an Xml File";
            saveFile.FileName = "templates_bk.xml";
            saveFile.InitialDirectory = @"C:\";
            saveFile.OverwritePrompt = false;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                DialogResult answer = System.Windows.Forms.MessageBox.Show("Are you sure you wish to import this template XML?", "Confirm Import", MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)
                {
                    xmlPath = saveFile.FileName;
                    var desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                    var desktopFile = Path.Combine(desktopFolder, "templates_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xml");
                    //File.Copy(@"templates.xml", @desktopFile, true); // backup copy
                    File.Copy(xmlFilePath, @desktopFile, true); // backup copy
                    //File.Copy(@xmlPath, @"templates.xml", true); // import copy
                    File.Copy(@xmlPath, xmlFilePath, true); // import copy
                    System.Windows.Forms.MessageBox.Show("Your templates file has been successfully imported.\r\nA copy of your previous template file has been saved to your desktop as templates_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xml.", "Import Result");
                    xmlNodeCheck(); // Check to see if the imported XML needs the newer nodes
                    loadList();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Rename_btn_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                string renameSelect = listBox1.SelectedItem.ToString();

                using (Rename_Template rt = new Rename_Template(renameSelect))
                {
                    rt.ShowDialog();

                    string renameValue = rt.get_NewName();
                    if ((renameValue != ""))
                    {
                        XmlDocument xdocUpt = new XmlDocument();
                        xdocUpt.Load(xmlFilePath);
                        foreach (XmlElement element in xdocUpt.SelectNodes("//template"))
                        {
                            foreach (XmlElement element1 in element)
                            {
                                if (string.Equals(element.SelectSingleNode(@".//name").InnerText, listBox1.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase))
                                {
                                    element.SelectSingleNode(@".//name").InnerText = renameValue;
                                    element.SelectSingleNode(@".//text").InnerText = TemplateText_tb.Text.ToString();
                                    element.SelectSingleNode(@".//desc").InnerText = tempDesc_tb.Text.ToString();
                                    // 8-22-18 If the comboBox1 is 'Search Results' don't update the type, leave it the same
                                    //  Allows for updating from Search Results display
                                    if (comboBox1.SelectedItem.ToString() != "Search Results")
                                    {
                                        element.SelectSingleNode(@".//type").InnerText = comboBox1.SelectedItem.ToString();
                                    }
                                    xdocUpt.Save(xmlFilePath);
                                    System.Windows.Forms.MessageBox.Show("Template Has Been Renamed.", "Rename Template");
                                    break;
                                }
                            }
                        }
                    }
                    loadList(); // Moved out of foreach loops to avoid errors from null listBox1.SelectedItem fault
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No Template Selected.\r\nYou must select a template to rename.", "Warning!");
            }
        }

        /// <summary>
        /// Verify the necessary nodes are present in the XML.  If they are missing, warn the user and then add them.
        /// this is being used as new functionality requires additional nodes that were not present.  Missing nodes will cause a failure in the app.
        /// </summary>
        public void xmlNodeCheck()
        {
            // Check for type node
            // This is really old and likely not needed
            var xmlTypeNode = XDocument.Load(xmlFilePath).Descendants("type");
            if (xmlTypeNode.Any())
            {
                // Nothing to do but start the app
            }
            else
            {
                DialogResult answer = System.Windows.Forms.MessageBox.Show("Upgrade Needed To Add New XML Node.", "Confirm Upgrade", MessageBoxButtons.OK);
                if (answer == DialogResult.OK)
                {
                    xmlAddTypeNode();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Be Aware The App May Not Work Until You Proceed With The Upgrade!", "Confirm Upgrade");
                }
            }
            // Check for desc node
            // This could be combined and done as 1 function with a node passed in
            var xmlDescNode = XDocument.Load(xmlFilePath).Descendants("desc");
            if (xmlDescNode.Any())
            {
                // Nothing to do but start the app
            }
            else
            {
                DialogResult answer = System.Windows.Forms.MessageBox.Show("Upgrade Needed To Add New XML Node.", "Confirm Upgrade", MessageBoxButtons.OK);
                if (answer == DialogResult.OK)
                {
                    xmlAddDescNode();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Be Aware The App May Not Work Until You Proceed With The Upgrade!", "Confirm Upgrade");
                }
            }
        }

        /* Add Type node
         * Old and likely not needed any longer.  Type was added back in July 2018.
         * Check to see if there is a node for Type in the XML.  If not add it for use and to avoid errors in the app.
         */
        public void xmlAddTypeNode()
        {
            // Use code from copy section to cycle through each node instead of .Last()

            XmlDocument xdocUpt = new XmlDocument();
            xdocUpt.Load(xmlFilePath);
            foreach (XmlElement element in xdocUpt.SelectNodes("//template"))
            {
                XmlElement newvalue = xdocUpt.CreateElement("type");
                newvalue.InnerText = "Templates";
                element.AppendChild(newvalue);
            }
            xdocUpt.Save(xmlFilePath);
        }

        /* 11/28/18 Add Desc node
         * Check to see if there is a node for Desc in the XML.  If not add it for use and to avoid errors in the app.
         */
        public void xmlAddDescNode()
        {
            // Use code from copy section to cycle through each node instead of .Last()

            XmlDocument xdocUpt = new XmlDocument();
            xdocUpt.Load(xmlFilePath);
            foreach (XmlElement element in xdocUpt.SelectNodes("//template"))
            {
                XmlElement newvalue = xdocUpt.CreateElement("desc");
                newvalue.InnerText = "";
                element.AppendChild(newvalue);
            }
            xdocUpt.Save(xmlFilePath);
        }

        // This is to build the drop-list.
        public static List<string> GetItemsFromXmlUsingTagNames(string Filename, string TagName)
        {
            //Create a list to store all the items.
            List<string> Items = new List<string>();
            // Hardcoding types for now (12/16/2017) .. can change later if add feature to add types
            Items.Add("Templates");
            Items.Add("Tips");
            Items.Add("Notes");
            Items.Add("General");
            Items.Add("Misc");
            Items.Add("Search Results");
            /*
            //Load the document from a file.
            XmlDocument doc = new XmlDocument();
            doc.Load(Filename);

            //Get all the <node3> nodes.
            XmlNodeList Node3Nodes = doc.GetElementsByTagName(TagName);
            //Loop through the node list to get the data we want.
            foreach (XmlNode Node3Node in Node3Nodes)
            {
                //These nodes contain the data we want so lets add it to our List.
                if (!Items.Contains(Node3Node.InnerText))
                    Items.Add(Node3Node.InnerText);
            }
            //Return the List of items we found.
            */
            return Items;
        }

        // Select a template type to display a listing
        //  Handle search options
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripMenuItem5.Checked) // Auto-refresh checked so update list
            {
                if (comboBox1.SelectedItem.ToString() == "Search Results")
                {
                    listBox1.Items.Clear(); // Go ahead and clear the template listing before searching
                    searchTmplt();
                }
                else
                {
                    Search_Tb.Text = "Search ...";
                    Search_Tb.ForeColor = System.Drawing.Color.Gray;
                    loadList();
                }
            } // If Auto-Refresh not check don't do anything
        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            // Selected a new type so go grab the matching items and reload the list
            if (comboBox1.SelectedItem.ToString() == "Search Results")
            {
                searchTmplt();
            }
            else
            {
                Search_Tb.Text = "Search ...";
                Search_Tb.ForeColor = System.Drawing.Color.Gray;
                loadList();
            }
        }

        // Slider to control font size
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Font font = TemplateText_tb.Font;
            float newSize = trackBar1.Value;
            TemplateText_tb.Font = new Font(font.FontFamily, newSize, font.Style);
            //listBox1.Font = new Font(font.FontFamily, newSize, font.Style);
            fontSizeval.Text = newSize.ToString();
        }

        public void searchTmplt()
        {
            if ((Search_Tb.Text != "Search ...") && (Search_Tb.Text != ""))
            {
                comboBox1.SelectedIndex = 3; // Change type to Search Results .. list is alphabetical .. if more types added then update this

                listBox1.Items.Clear();
                TemplateText_tb.Text = "";

                xm.Load(xmlFilePath);
                XmlNodeList Xn = xm.SelectNodes(textbx); // textbx defines all templates
                foreach (XmlNode xNode in Xn)
                {
                    if (xNode["name"].InnerText.ToLower().Contains(Search_Tb.Text.ToLower().ToString()))
                    {
                        listBox1.Items.Add(xNode["name"].InnerText);
                    }
                    if (xNode["text"].InnerText.ToLower().Contains(Search_Tb.Text.ToLower().ToString()))
                    {
                        if (!listBox1.Items.Contains(xNode["name"].InnerText))
                            listBox1.Items.Add(xNode["name"].InnerText);
                    }
                    if (xNode["desc"].InnerText.ToLower().Contains(Search_Tb.Text.ToLower().ToString()))
                    {
                        if (!listBox1.Items.Contains(xNode["name"].InnerText))
                            listBox1.Items.Add(xNode["name"].InnerText);
                    }
                }

                /*
                 * Adding here to rebuild the validation check
                 * so that it's run every time the list is rebuilt
                */
                xdoc = XDocument.Load(xmlFilePath);
                templates = xdoc.Root.Elements("template")
                    .Select(tm => new template
                    {
                        template_Name = (string)tm.Element("name"),
                        template_Text = (string)tm.Element("text"),
                        template_Type = (string)tm.Element("type"),
                        template_Desc = (string)tm.Element("desc")
                    }).ToList();

            }
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            searchTmplt();
        }

        // Select all search text when click into the search field
        void Search_Tb_Click(object sender, System.EventArgs e)
        {
            Search_Tb.SelectAll();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();  //”this” refers to the form
        }

        private void Search_Tb_TextChanged(object sender, EventArgs e)
        {
            searchTmplt();
        }

        private void Search_Tb_Leave(object sender, EventArgs e)
        {
            if (Search_Tb.Text == "")
            {
                Search_Tb.Text = "Search ...";
                Search_Tb.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void Search_Tb_Enter(object sender, EventArgs e)
        {
            if (Search_Tb.Text == "Search ...")
            {
                Search_Tb.Text = "";
                Search_Tb.ForeColor = System.Drawing.Color.Black;
            }
        }

        // Open droplist when click anywhere in the droplist
        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.DroppedDown = true;
        }

        // Open browser if click a link
        private void TemplateText_tb_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            string linkText = e.LinkText.Replace((char)160, ' ');
            System.Diagnostics.Process.Start("explorer.exe", linkText);
        }

        // ContextMenu2 for main text field
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TemplateText_tb.SelectionLength > 0)
                TemplateText_tb.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TemplateText_tb.SelectionLength > 0)
            {
                //TemplateText_tb.Copy();
                System.Windows.Forms.Clipboard.SetText(TemplateText_tb.SelectedText.Replace("\n", "\r\n"), System.Windows.Forms.TextDataFormat.Text);
                //TemplateText_tb.SelectionLength = 0; 7/16/18 Removed the auto unselect
            }
            else
            {
                System.Windows.Forms.Clipboard.SetText(TemplateText_tb.Text.Replace("\n", "\r\n"), System.Windows.Forms.TextDataFormat.Text);
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //            if (TemplateText_tb.SelectionLength > 0)
            TemplateText_tb.Paste();

        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TemplateText_tb.CanUndo)
                TemplateText_tb.Undo();
            TemplateText_tb.ClearUndo();
        }

        // ContextMenu3 for Desc field
        private void cutToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (tempDesc_tb.SelectionLength > 0)
                tempDesc_tb.Cut();
        }

        private void copyToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (tempDesc_tb.SelectionLength > 0)
            {
                //tempDesc_tb.Copy();
                System.Windows.Forms.Clipboard.SetText(tempDesc_tb.SelectedText.Replace("\n", "\r\n"), System.Windows.Forms.TextDataFormat.Text);
                //tempDesc_tb.SelectionLength = 0; 7/16/18 Removed the auto unselect
            }
            else
            {
                System.Windows.Forms.Clipboard.SetText(tempDesc_tb.Text.Replace("\n", "\r\n"), System.Windows.Forms.TextDataFormat.Text);
            }
        }

        private void pasteToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //            if (tempDesc_tb.SelectionLength > 0)
            tempDesc_tb.Paste();

        }

        private void undoToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (tempDesc_tb.CanUndo)
                tempDesc_tb.Undo();
            tempDesc_tb.ClearUndo();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ex = new ExportXML(xmlFilePath);
            ex.StartPosition = FormStartPosition.CenterScreen;
            ex.Show();
            ex.Refresh();

        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = false;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            MyDialog.Color = TemplateText_tb.BackColor;

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
                TemplateText_tb.BackColor = MyDialog.Color;

        }

        private void backgroundColorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = false;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            MyDialog.Color = listBox1.BackColor;

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
                listBox1.BackColor = MyDialog.Color;

        }

        private void backgroundColorToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = false;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            MyDialog.Color = tempDesc_tb.BackColor;

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
                tempDesc_tb.BackColor = MyDialog.Color;

        }

        private void resetColorsDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult answer = System.Windows.Forms.MessageBox.Show("Are you sure you wish to reset the font scheme to it's orginal state?", "Confirm Reset", MessageBoxButtons.YesNo);
            if (answer == DialogResult.Yes)
            {
                TemplateText_tb.ForeColor = Properties.Settings.Default.InitialForeColor;
                TemplateText_tb.BackColor = Properties.Settings.Default.InitialBackColor;
                TemplateText_tb.Font = Properties.Settings.Default.InitialFont;
                listBox1.ForeColor = Properties.Settings.Default.InitialForeColor;
                listBox1.BackColor = Properties.Settings.Default.InitialBackColor;
                listBox1.Font = Properties.Settings.Default.InitialFont;
                tempDesc_tb.ForeColor = Properties.Settings.Default.InitialForeColor;
                tempDesc_tb.BackColor = Properties.Settings.Default.InitialBackColor;
                tempDesc_tb.Font = Properties.Settings.Default.InitialFont;
                resetTrackBarValue();
            }

        }

        private void resetTrackBarValue()
        {
            int newTBV = Convert.ToInt32(TemplateText_tb.Font.Size);
            trackBar1.Value = newTBV;
            fontSizeval.Text = newTBV.ToString();
        }

        // Highlight the text in the search field that is found in the main template text box
        private void HighlightWords(string word)
        {
            int startIndex = 0;
            while (startIndex < TemplateText_tb.TextLength)
            {
                int wordStartIndex = TemplateText_tb.Find(word, startIndex, RichTextBoxFinds.None);
                if (wordStartIndex != -1)
                {
                    TemplateText_tb.SelectionStart = wordStartIndex;
                    TemplateText_tb.SelectionLength = word.Length;
                    TemplateText_tb.SelectionBackColor = Color.Yellow;
                }
                else
                    break;
                startIndex += wordStartIndex + word.Length;
            }
        }

        // Font dialog for main text box
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDlg.ShowColor = true;
            fontDlg.ShowApply = true;
            fontDlg.ShowEffects = true;
            fontDlg.ShowHelp = false;
            fontDlg.MaxSize = 20;
            fontDlg.MinSize = 8;
            fontDlg.Font = TemplateText_tb.Font;
            fontDlg.Color = TemplateText_tb.ForeColor;
            fontDlg.Apply += new System.EventHandler(fontDlg_Apply);

            // Save the existing font.
            System.Drawing.Font oldFont = TemplateText_tb.Font;
            System.Drawing.Color oldColor = TemplateText_tb.ForeColor;

            DialogResult fntResult = fontDlg.ShowDialog();

            if (fntResult == DialogResult.OK)
            {
                fontDlg_Apply(this.fontToolStripMenuItem, new System.EventArgs());
            }
            // Restore the old font if click cancel .. treats apply as temporary
            else if (fntResult == DialogResult.Cancel)
            {
                TemplateText_tb.Font = oldFont;
                TemplateText_tb.ForeColor = oldColor;
                resetTrackBarValue();
            }
        }

        // Handle the Apply event by setting all text box fonts to 
        // the chosen font. 
        private void fontDlg_Apply(object sender, System.EventArgs e)
        {
            TemplateText_tb.Font = fontDlg.Font;
            TemplateText_tb.ForeColor = fontDlg.Color;
            resetTrackBarValue();
        }

        // Font dialog for list box
        private void fontToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fontDlgLB.ShowColor = true;
            fontDlgLB.ShowApply = true;
            fontDlgLB.ShowEffects = true;
            fontDlgLB.ShowHelp = false;
            fontDlgLB.MaxSize = 14;
            fontDlgLB.MinSize = 8;
            fontDlgLB.Font = listBox1.Font;
            fontDlgLB.Color = listBox1.ForeColor;
            fontDlgLB.Apply += new System.EventHandler(fontDlgLB_Apply);

            // Save the existing font.
            System.Drawing.Font oldLBFont = listBox1.Font;
            System.Drawing.Color oldLBColor = listBox1.ForeColor;

            DialogResult fntLBResult = fontDlgLB.ShowDialog();

            if (fntLBResult == DialogResult.OK)
            {
                fontDlgLB_Apply(this.fontToolStripMenuItem1, new System.EventArgs());
            }
            // Restore the old font if click cancel .. treats apply as temporary
            else if (fntLBResult == DialogResult.Cancel)
            {
                listBox1.Font = oldLBFont;
                listBox1.ForeColor = oldLBColor;
            }
        }

        // Handle the Apply event by setting all list box fonts to 
        // the chosen font. 
        private void fontDlgLB_Apply(object sender, System.EventArgs e)
        {
            listBox1.Font = fontDlgLB.Font;
            listBox1.ForeColor = fontDlgLB.Color;
        }

        // Font dialog for desc text box
        private void fontToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            fontDlgDB.ShowColor = true;
            fontDlgDB.ShowApply = true;
            fontDlgDB.ShowEffects = true;
            fontDlgDB.ShowHelp = false;
            fontDlgDB.MaxSize = 20;
            fontDlgDB.MinSize = 8;
            fontDlgDB.Font = tempDesc_tb.Font;
            fontDlgDB.Color = tempDesc_tb.ForeColor;
            fontDlgDB.Apply += new System.EventHandler(fontDlgDB_Apply);

            // Save the existing font.
            System.Drawing.Font oldFont = tempDesc_tb.Font;
            System.Drawing.Color oldColor = tempDesc_tb.ForeColor;

            DialogResult fntResultDB = fontDlgDB.ShowDialog();

            if (fntResultDB == DialogResult.OK)
            {
                fontDlgDB_Apply(this.fontToolStripMenuItem, new System.EventArgs());
            }
            // Restore the old font if click cancel .. treats apply as temporary
            else if (fntResultDB == DialogResult.Cancel)
            {
                tempDesc_tb.Font = oldFont;
                tempDesc_tb.ForeColor = oldColor;
            }
        }

        // Handle the Apply event by setting desc text box fonts to 
        // the chosen font. 
        private void fontDlgDB_Apply(object sender, System.EventArgs e)
        {
            tempDesc_tb.Font = fontDlgDB.Font;
            tempDesc_tb.ForeColor = fontDlgDB.Color;
        }

        /*
         * Imported code and not modified
         */
        public static string NameWithoutDomain(string userName)
        {
            string[] parts = userName.Split(new char[] { '\\' });

            //highly recommend checking parts array for validity here 
            //prior to dereferencing

            return parts[1];
        }

        private void Copy_btn_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Copy_btn.FlatAppearance.BorderSize = 1;
        }

        private void Copy_btn_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Copy_btn.FlatAppearance.BorderSize = 0;
        }

        private void Clear_btn_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Clear_btn.FlatAppearance.BorderSize = 1;
        }

        private void Clear_btn_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Clear_btn.FlatAppearance.BorderSize = 0;
        }

        private void Delete_btn_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Delete_btn.FlatAppearance.BorderSize = 1;
        }

        private void Delete_btn_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Delete_btn.FlatAppearance.BorderSize = 0;
        }

        private void Rename_btn_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Rename_btn.FlatAppearance.BorderSize = 1;
        }

        private void Rename_btn_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Rename_btn.FlatAppearance.BorderSize = 0;
        }

        private void SearchBtn_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            SearchBtn.FlatAppearance.BorderSize = 1;
        }

        private void SearchBtn_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            SearchBtn.FlatAppearance.BorderSize = 0;
        }

        private void refresh_btn_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            refresh_btn.FlatAppearance.BorderSize = 1;
        }

        private void refresh_btn_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            refresh_btn.FlatAppearance.BorderSize = 0;
        }

        private void Save_btn_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Save_btn.FlatAppearance.BorderSize = 1;
        }

        private void Save_btn_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Save_btn.FlatAppearance.BorderSize = 0;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            us = new UserSettings();
            us.StartPosition = FormStartPosition.CenterScreen;
            us.Show();
            us.Refresh();
        }

        /*
         * v1.9.2
         * Auto backup process.  Uses the default backup settings to create a backup every n days.  This should help alleviate issues with laptop upgrades/crashes
         * losing user template files if it's setup by the user.
         */
        public void AutoBackupProcess(DateTime LastBU, DateTime CurrDate, string ABFreq, string ABLoc)
        {
            DateTime LastBUModified = LastBU.AddDays(int.Parse(ABFreq));
            if (CurrDate.Date > LastBUModified.Date)
            {
                var ABFileName = Path.Combine(ABLoc, "templates_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xml");
                File.Copy(xmlFilePath, ABFileName, true);
                //System.Windows.Forms.MessageBox.Show("Your templates file has been successfully backed up to:\r\n" + ABLoc, "Backup Result");
                //TemplateText_tb.Text = LastBUModified.ToString() + "Your templates file has been successfully backed up to: " + ABLoc;
                TemplateText_tb.Text = "Per your default AutoBackup settings, your current templates " +
                    "file has been successfully backed up to the following location: \n\r \n\r" + ABFileName;

                MessageBox.Show("Your scheduled automated backup has been completed.", "Auto-Backup");

                Properties.Settings.Default.ABDate = DateTime.Now;
            }
        }

        /*
         * v1.9.8
         * Save text box to a file.  Allows for sharing (and printing) of templates to others that are not using the app.
         */
        public void saveBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TemplateText_tb.Text))
            {
                System.Windows.Forms.MessageBox.Show("Must Enter Template Text!", "Warning!");
            }
            else
            {
                saveFileDialog1.Filter = "Text Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf";
                saveFileDialog1.AddExtension = true;
                if (listBox1.SelectedIndex >= 0)
                {
                    saveFileDialog1.FileName = listBox1.SelectedItem.ToString();
                }
                else
                {
                    saveFileDialog1.FileName = "STFile";
                }
                saveFileDialog1.DefaultExt = "txt";
                DialogResult SaveResult = saveFileDialog1.ShowDialog();
                if ((SaveResult == DialogResult.OK) && (saveFileDialog1.FileName.Length > 0))
                {
                    var extension = System.IO.Path.GetExtension(saveFileDialog1.FileName);
                    var textToRestore = TemplateText_tb.Text;
                    var textToSave = "";
                    if (tempDesc_tb.Text != "") // if there is a description, add it to the file
                    {
                        textToSave = tempDesc_tb.Text + "\r\n-----\r\n" + TemplateText_tb.Text;
                    }
                    else
                    {
                        textToSave = TemplateText_tb.Text;
                    }
                    if (extension.ToLower() == ".txt") /*saveFileDialog.FilterIndex==1*/
                    {
                        TemplateText_tb.Text = textToSave;
                        TemplateText_tb.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                        TemplateText_tb.Text = textToRestore;
                    }
                    else
                    {
                        TemplateText_tb.Text = textToSave;
                        TemplateText_tb.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
                        TemplateText_tb.Text = textToRestore;
                    }

                    MessageBox.Show("Your text has been saved to \n\r" + saveFileDialog1.FileName + ".", "Save To File");
                }
            }
        }

        // 12-18-18 Hotkey code
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0312)
            {
                /* Note that the three lines below are not needed if you only want to register one hotkey.
                 * The below lines are useful in case you want to register multiple keys, which you can use a switch with the id as argument, or if you want to know which key/modifier was pressed for some particular reason. */

                //Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);                  // The key of the hotkey that was pressed.
                //KeyModifier modifier = (KeyModifier)((int)m.LParam & 0xFFFF);       // The modifier of the hotkey that was pressed.
                //int id = m.WParam.ToInt32();                                        // The id of the hotkey that was pressed.


                //MessageBox.Show("Hotkey has been pressed!");
                // do something
                ActivateApp("SupportTemplates");
            }
        }

        // 12-18-18 Hotkey code
        void ActivateApp(string processName)
        {
            Process[] p = Process.GetProcessesByName(processName);

            // Activate the first application we find with this name
            if (p.Count() > 0)
                SetForegroundWindow(p[0].MainWindowHandle);
            ShowWindow(p[0].MainWindowHandle, SW_MAXIMIZE);
        }

        // Update is available so open the About form to allow for update installation
        private void updateAvailableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            af = new About();
            af.StartPosition = FormStartPosition.CenterScreen;
            af.Show();
            af.Refresh();
        }

        // Check for updates and turn on menustrip item if one is ready to install.
        public void CheckForUpdate()
        {
            UpdateCheckInfo info = null;

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
                try
                {
                    info = ad.CheckForDetailedUpdate();
                }
                catch (DeploymentDownloadException dde)
                {
                }
                catch (InvalidDeploymentException ide)
                {
                }
                catch (InvalidOperationException ioe)
                {
                }
                if (info.UpdateAvailable)
                {
                    updateAvailableToolStripMenuItem.Visible = true;
                }
                else
                {
                    updateAvailableToolStripMenuItem.Visible = false;
                }
            } 
        }

        // 12-21-18 Added help docs link to file about menu
        private void helpDocsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://sites.google.com/site/martyelder/support-templates");
        }

        // 12-21-18 Added Version info to file about menu 
        private void versionInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vf = new VersionInfo();
            vf.StartPosition = FormStartPosition.CenterScreen;
            vf.Show();
            vf.Refresh();
        }

        // 12-21-18 Right click menu item to insert a file URL into the main RTB
        //   Allows for linking images or other files to a template
        private void insertFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog insertFileURL = new System.Windows.Forms.OpenFileDialog();
            insertFileURL.ShowHelp = true;
            insertFileURL.ShowDialog();
            var newFilePath = insertFileURL.FileName;
            // Handle the canceling of the file dialog so that the file:// isn't added unless needed
            if (insertFileURL.FileName != "")
            {
                TemplateText_tb.SelectedText = " file://" + insertFileURL.FileName.Replace(' ', (char)160) + " ";
            }
        }

        // 12-22-18 Toying with RichTextFormatting in main template RTB
        //  Would take major rewrite to save to XAML
        //  Leaving here just in case
        private static string GetRTF(System.Windows.Controls.RichTextBox rt)
        {
            TextRange range = new TextRange(rt.Document.ContentStart, rt.Document.ContentEnd);
            MemoryStream stream = new MemoryStream();
            range.Save(stream, System.Windows.DataFormats.Xaml);
            string xamlText = Encoding.UTF8.GetString(stream.ToArray());
            return xamlText;
        }
        private static FlowDocument SetRTF(string xamlString)
        {
            StringReader stringReader = new StringReader(xamlString);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            Section sec = XamlReader.Load(xmlReader) as Section;
            FlowDocument doc = new FlowDocument();
            while (sec.Blocks.Count > 0)
                doc.Blocks.Add(sec.Blocks.FirstBlock);
            return doc;
        }

    }
}
