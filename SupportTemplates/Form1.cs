using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace SupportTemplates
{
    public partial class Form1 : Form
    {

        About af;
        Rename_Template rt;

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
        string xmlFilePath1 = Application.CommonAppDataPath; // Necessary for deployment
        string xmlFilePath2 = Application.StartupPath; // Used for debugging runs

        string list = "//name";
        string textbx = "//template";
        string combo = "//type";
        private IEnumerable<template> mytmplt;

        /// <summary>
        /// 
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public class template
        {
            public string template_Name { get; set; }
            public string template_Text { get; set; }
            public string template_Type { get; set; }
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
                    template_Type = (string)tm.Element("type")
                }).ToList();

        }

        /// <summary>
        /// 
        /// </summary>
        public void xmlFileCheck()
        {
            if (File.Exists(xmlFilePath1 + "\\templates.xml"))
            {
                xmlFilePath = xmlFilePath1 + "\\templates.xml";
            }
            else if (File.Exists(xmlFilePath2 + "\\templates.xml"))
            {
                xmlFilePath = xmlFilePath2 + "\\templates.xml";
            }
            else if (File.Exists(xmlFilePath1.Replace("\\bin\\Debug", "\\") + "\\templates.xml"))
            {
                xmlFilePath = xmlFilePath1.Replace("\\bin\\Debug", "\\") + "\\templates.xml";
            }
            else if (File.Exists(xmlFilePath2.Replace("\\bin\\Debug", "\\") + "\\templates.xml"))
            {
                xmlFilePath = xmlFilePath2.Replace("\\bin\\Debug", "\\") + "\\templates.xml";
            }
            else
            {
                xmlFilePath = "";
                // Initial load of the app so create the templates.xml file
                File.Copy(@"DefaultXML.xml", @"templates.xml", true);
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
             * Have to validate the path to the xml file due to some issue with the installation of the application.
             * Likely has to due to the debug pathing during development.  This remedies the issue & automatically
             * picks the correct path of the templates.xml file in producation & development.
             */
            //    //MessageBox.Show("Unable to find XML file.  Please contact support.");

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
            Size = new Size(initWidth, initHeight);

            // Base left pane size on default or custom settings
            int initSplitter = Properties.Settings.Default.InitialSplitterDiff;
            splitContainer1.SplitterDistance = initSplitter;

            // Gather information for combobox list of template types
            List<string> Items = Form1.GetItemsFromXmlUsingTagNames(xmlFilePath, "type");
            //Add them to the ComboBox
            comboBox1.Items.AddRange(Items.ToArray());
            comboBox1.SelectedIndex = 3;

            // Set CheckBox1 to Checked by default
            checkBox1.Checked = true;

            // Reload the template list
            loadList();

            // Check for font size of main text box
            Font initFont = TemplateText_tb.Font;
            TemplateText_tb.Font = new Font(initFont.FontFamily, Properties.Settings.Default.InitialTBSize, initFont.Style);

            // Set the value of the slider to the current font of the text box
            float initFontSize = TemplateText_tb.Font.Size;
            int ifs = (int)initFontSize;
            trackBar1.Value = ifs;
            fontSizeval.Text = initFontSize.ToString();

        }

        // Change the font size default to be the current value on close
        public void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            float currFontSize = TemplateText_tb.Font.Size;
            Properties.Settings.Default.InitialTBSize = currFontSize;
            Properties.Settings.Default.InitialHeight = Size.Height;
            Properties.Settings.Default.InitialWidth = Size.Width;
            Properties.Settings.Default.InitialSplitterDiff = splitContainer1.SplitterDistance;
            Properties.Settings.Default.Save();
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
                XmlNodeList xnList = xm.SelectNodes(textbx); // textbx defines all templates
                foreach (XmlNode xn in xnList)
                {
                    if (xn["name"].InnerText == listBox1.SelectedItem.ToString())
                    {
                        TemplateText_tb.Text = xn["text"].InnerText;
                    }
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
                MessageBox.Show("Must Enter Template Text!", "Warning!");
            }
            else if (string.IsNullOrEmpty(NewTemplateName_tb.Text)) // Update existing template
            {
                if (listBox1.SelectedIndex >= 0)
                { 
                    DialogResult answer = MessageBox.Show("Are you sure you wish to update the template?", "Confirm Clear", MessageBoxButtons.YesNo);
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
                                    element.SelectSingleNode(@".//type").InnerText = comboBox1.SelectedItem.ToString();
                                    xdocUpt.Save(xmlFilePath);
                                    MessageBox.Show("Template has been saved.", "Update Template");
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
                    MessageBox.Show("No Template Selected.\r\nYou must either select a template to update or enter a new name to save as.", "Warning!");
                }
            }
            else // Copy to new name
            {
                var myOutput =
                    from t in templates
                    where t.template_Name.ToLower() == NewTemplateName_tb.Text.ToLower()
                    select t;
                int foundItems = myOutput.Count();
                if (foundItems > 0)
                {
                    MessageBox.Show("Template name already exists.\r\nClear the new template name field to update an existing template.", "Warning!");
                }
                else
                {
                    DialogResult answer = MessageBox.Show("Are you sure you wish to save this template?", "Confirm Save", MessageBoxButtons.YesNo);
                    if (answer == DialogResult.Yes)
                    {
                        xdoc.Root.Add(
                            new XElement("template",
                                new XElement("name", NewTemplateName_tb.Text.ToString()),
                                new XElement("text", TemplateText_tb.Text.ToString()),
                                new XElement("type", comboBox1.SelectedItem.ToString())
                            ));
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
                DialogResult answer = MessageBox.Show("Are you sure you wish to delete this template?", "Confirm Clear", MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)
                {
                    string delSelect = listBox1.SelectedItem.ToString();
                    XmlDocument xdocDel = new XmlDocument();
                    xdocDel.Load(xmlFilePath);
                    XmlNode t = xdocDel.SelectSingleNode("/templates/template[name='" + delSelect + "']");
                    t.ParentNode.RemoveChild(t);
                    xdocDel.Save(xmlFilePath);
                    MessageBox.Show("Template Has Been Deleted.", "Delete Template");
                    loadList();
                }
            }
            else
            {
                MessageBox.Show("No Template Selected.\r\nYou must select a template to delete.", "Warning!");
            }
        }

        /// <summary>
        /// Clear/New button is clicked.
        /// <remarks>
        /// When the user clicks the clear button, the template text box is cleared of all text.
        /// </remarks>
        /// </summary>
        private void Clear_btn_Click(object sender, EventArgs e)
        {
            TemplateText_tb.Text = "";
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
                    Clipboard.SetText(TemplateText_tb.SelectedText);
                    TemplateText_tb.SelectionLength = 0;
                }
                else
                {
                    Clipboard.SetText(TemplateText_tb.Text);
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
            DialogResult answer = MessageBox.Show("Are you sure you wish to reset the template list to it's orginal state?", "Confirm Reset", MessageBoxButtons.YesNo);
            if (answer == DialogResult.Yes)
            {
                File.Copy(@"DefaultXML.xml", @"templates.xml",true);
                MessageBox.Show("Template listing reset to default state.", "Reset Templates");
                loadList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Export_btn_Click(object sender, EventArgs e)
        {
            string xmlPath = @"C:\";
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "XML Files|*.xml";
            saveFile.Title = "Export an Xml File";
            saveFile.FileName = "templates_bk.xml";
            saveFile.InitialDirectory = @"C:\";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                xmlPath = saveFile.FileName;
                File.Copy(@"templates.xml", @xmlPath, true);
                MessageBox.Show("Your templates file has been successfully exported to:\r\n" + xmlPath, "Export Result");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Import_btn_Click(object sender, EventArgs e)
        {
            string xmlPath = @"C:\";
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "XML Files|*.xml";
            saveFile.Title = "Import an Xml File";
            saveFile.FileName = "templates_bk.xml";
            saveFile.InitialDirectory = @"C:\";
            saveFile.OverwritePrompt = false;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                DialogResult answer = MessageBox.Show("Are you sure you wish to import this template XML?", "Confirm Import", MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)
                {
                    xmlPath = saveFile.FileName;
                    var desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                    var desktopFile = Path.Combine(desktopFolder, "templates_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xml");
                    File.Copy(@"templates.xml", @desktopFile, true); // backup copy
                    File.Copy(@xmlPath, @"templates.xml", true); // import copy
                    MessageBox.Show("Your templates file has been successfully imported.\r\nA copy of your previous template file has been saved to your desktop as templates_"+ DateTime.Now.ToString("yyyyMMddHHmmss") + ".xml.", "Import Result");
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
                                    element.SelectSingleNode(@".//type").InnerText = comboBox1.SelectedItem.ToString();
                                    xdocUpt.Save(xmlFilePath);
                                    MessageBox.Show("Template Has Been Renamed.", "Rename Template");
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
                MessageBox.Show("No Template Selected.\r\nYou must select a template to rename.", "Warning!");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void xmlNodeCheck()
        {
            var xmlTypeNode = XDocument.Load(xmlFilePath).Descendants("type");
            if (xmlTypeNode.Any())
            {
                // Nothing to do but start the app
            } else
            {
                DialogResult answer = MessageBox.Show("Upgrade Needed To Add New XML Nodes.  Proceed?", "Confirm Upgrade", MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)
                {
                    xmlAddTypeNode();
                } else
                {
                    MessageBox.Show("Be Aware The App May Not Work Until You Proceed With The Upgrade!", "Confirm Upgrade");
                }
            }
        }

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

            //MessageBox.Show("Node Add Check", "Check For Node");
        }

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                loadList();
            }
        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            // Selected a new type so go grab the matching items and reload the list
            loadList();
        }

        private void toolTip2_Popup(object sender, PopupEventArgs e)
        {

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
    }
}
