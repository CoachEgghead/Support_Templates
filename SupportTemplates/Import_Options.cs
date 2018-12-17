using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupportTemplates
{
    public partial class Import_Options : Form
    {

        string importValue = "";

        public Import_Options()
        {
            InitializeComponent();
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Overwrite_btn_Click(object sender, EventArgs e)
        {
            importValue = "o";
            Close();
        }

        private void Insert_btn_Click(object sender, EventArgs e)
        {
            importValue = "i";
            Close();
        }

        public string get_importValue()
        {
            return importValue;
        }

    }
}
