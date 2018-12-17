using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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

        private void DownloadLinkLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.mreswebsites.com/windowsapps/SupportTemplates/publish.htm");
        }

        private void versionCheck_btn_Click(object sender, EventArgs e)
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
                    MessageBox.Show("The new version of the application cannot be downloaded at this time. \n\nPlease check your network connection, or try again later. Error: " + dde.Message, "Upgrade Check");
                    return;
                }
                catch (InvalidDeploymentException ide)
                {
                    MessageBox.Show("Cannot check for a new version of the application. The ClickOnce deployment is corrupt. Please redeploy the application and try again. Error: " + ide.Message, "Upgrade Check");
                    return;
                }
                catch (InvalidOperationException ioe)
                {
                    MessageBox.Show("This application cannot be updated. It is likely not a ClickOnce application. Error: " + ioe.Message, "Upgrade Check");
                    return;
                }

                if (info.UpdateAvailable)
                {
                    Boolean doUpdate = true;

                    if (!info.IsUpdateRequired)
                    {
                        DialogResult dr = MessageBox.Show("An update is available. Would you like to update the application now?", "Update Available", MessageBoxButtons.OKCancel);
                        if (!(DialogResult.OK == dr))
                        {
                            doUpdate = false;
                        }
                    }
                    else
                    {
                        // Display a message that the app MUST reboot. Display the minimum required version.
                        MessageBox.Show("This application has detected a mandatory update from your current " +
                            "version to version " + info.MinimumRequiredVersion.ToString() +
                            ". The application will now install the update and restart.",
                            "Update Available", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

                    if (doUpdate)
                    {
                        try
                        {
                            ad.Update();
                            MessageBox.Show("The application has been upgraded, and will now restart.", "Upgrade Check");
                            Application.Restart();
                        }
                        catch (DeploymentDownloadException dde)
                        {
                            MessageBox.Show("Cannot install the latest version of the application. \n\nPlease check your network connection, or try again later. Error: " + dde, "Upgrade Check");
                            return;
                        }
                    } else
                    {
                        MessageBox.Show("You have chosen to skip the update at this time.  Check back later to perform this upgrade at a more convenient time.","Upgrade Check");
                    }
                } else
                {
                    MessageBox.Show("No update is currently available.  Please check back at a later date.", "Upgrade Check");
                }
            } else
            {
                MessageBox.Show("This application install is not network deployed.  Please check with the application author for more information.", "Upgrade Check");
            }
        }

        private void Download_btn_MouseDown(object sender, MouseEventArgs e)
        {
            Download_btn.FlatAppearance.BorderSize = 1;
        }

        private void Download_btn_MouseUp(object sender, MouseEventArgs e)
        {
            Download_btn.FlatAppearance.BorderSize = 0;
        }

        private void Download_btn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.mreswebsites.com/windowsapps/SupportTemplates/publish.htm");
        }

        private void versionCheck_btn_MouseDown(object sender, MouseEventArgs e)
        {
            versionCheck_btn.FlatAppearance.BorderSize = 1;
        }

        private void versionCheck_btn_MouseUp(object sender, MouseEventArgs e)
        {
            versionCheck_btn.FlatAppearance.BorderSize = 0;
        }

    }
}
