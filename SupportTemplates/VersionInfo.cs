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
    public partial class VersionInfo : Form
    {
        public VersionInfo()
        {
            InitializeComponent();
            versionLbl.Text = ProductVersion;
        }
    }
}
