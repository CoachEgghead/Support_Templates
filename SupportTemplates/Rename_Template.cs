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
    /// <summary>
    /// 
    /// </summary>
    public partial class Rename_Template : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public string newName;
        public string oldTName;

        /// <summary>
        /// 
        /// </summary>
        public Rename_Template(string oldName)
        {
            InitializeComponent();
            newName = "";
            rename_tb.Text = oldName;
            oldTName = oldName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string get_NewName()
        {
            return newName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_btn_Click(object sender, EventArgs e)
        {
            if ((rename_tb.Text !=  "") && (rename_tb.Text != oldTName))
            {
                DialogResult answer = MessageBox.Show("Are you sure you wish to rename this template?", "Confirm Rename", MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)
                {
                    newName = rename_tb.Text;
                    Close();
                }
            }
            else if (rename_tb.Text == oldTName)
            {
                MessageBox.Show("You must enter a different name to proceed.  Please try again.", "Rename Error!");
            }
            else
            {
                MessageBox.Show("You did not enter a new value.  Please try again.", "Rename Error!");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
