using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupportTemplates
{
    public partial class About : Form
    {

        VersionInfo vf;

        /// <summary>
        /// 
        /// </summary>
        public About()
        {
            InitializeComponent();
            label2.Text = ProductVersion;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void About_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Get version of application for About window display
        /// </summary>
        public static new String ProductVersion
        {
            get
            {
                return new Version(FileVersionInfo.GetVersionInfo(Assembly.GetCallingAssembly().Location).ProductVersion).ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HelpLink_lbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://sites.google.com/site/martyelder/support-templates");
        }

        private void donationLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://paypal.me/MartyElder");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            vf = new VersionInfo();
            vf.StartPosition = FormStartPosition.CenterScreen;
            vf.Show();
            vf.Refresh();

        }
    }
}
