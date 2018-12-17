using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using static SupportTemplates.Form1;

namespace SupportTemplates
{
    public partial class ExportXML : Form
    {
        public XmlDocument xm = new XmlDocument();
        public XDocument xdoc;
        public List<template> templates;
        public string xmlFilePath = "";
        string textbx = "//template";

        public ExportXML(string xmlFile)
        {
            xmlFilePath = xmlFile;
            InitializeComponent();
            //xmlFileCheck();
            loadTemplateList();
            xdoc = XDocument.Load("DefaultXML.xml"); // Load in the default template to add to.
        }

        public void loadTemplateList()
        {
            listView1.ShowGroups = true;
            xm.Load(xmlFilePath);
            XmlNodeList Xn = xm.SelectNodes(textbx); // textbx defines all templates
            foreach (XmlNode xNode in Xn)
            {
                int count = 5;
                for (int n = 0; n < count; n++)
                {
                    if (xNode["type"].InnerText == listView1.Groups[n].Header)
                    {
                        listView1.Items.Add(xNode["name"].InnerText); /// need to add to groups not list
                        var item = listView1.FindItemWithText(xNode["name"].InnerText);
                        listView1.Items[listView1.Items.IndexOf(item)].Group = listView1.Groups[n];
                    }
                }
            }
            //listView1.Sorting = SortOrder.Ascending;
            //listView1.Sort();// = SortOrder.Ascending;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            int listCount = listView1.Items.Count;
            if (checkBox1.Checked == true)
            {
                foreach (ListViewItem item in listView1.Items)
                {
                    item.Checked = true;
                }
            } else
            {
                foreach (ListViewItem item in listView1.Items)
                {
                    item.Checked = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.CheckedIndices.Count > 0)
            {
                foreach (ListViewItem item in listView1.CheckedItems)
                {
                    XmlNodeList xnList = xm.SelectNodes(textbx); // textbx defines all templates
                    foreach (XmlNode xn in xnList)
                    {
                        if (xn["name"].InnerText == item.Text)
                        {
                            xdoc.Root.Add(
                                new XElement("template",
                                    new XElement("name", item.Text),
                                    new XElement("text", xn["text"].InnerText),
                                    new XElement("type", xn["type"].InnerText),
                                    new XElement("desc", xn["desc"].InnerText)
                                ));
                        }
                    }
                }
                string xmlPath = @"C:\";
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "XML Files|*.xml";
                saveFile.Title = "Export to an Xml File";
                saveFile.FileName = "export_template.xml";
                saveFile.InitialDirectory = @"C:\";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    xmlPath = saveFile.FileName;
                    xdoc.Root.Save(xmlPath);
                    System.Windows.Forms.MessageBox.Show("Template Has Been Exported.", "Export Template");
                }
            } else
            {
                System.Windows.Forms.MessageBox.Show("You must select at least 1 template to export.", "Export Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void reSortList(object sender, EventArgs e)
        {
            listView1.Sorting = SortOrder.Ascending;
            listView1.Sort();// = SortOrder.Ascending;
        }
    }
}
