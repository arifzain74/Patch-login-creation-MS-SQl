using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Patch_Login_User_Creation
{
    public partial class atMessageBox : Form
    {
        #region Constructor
        public atMessageBox()
        {
            InitializeComponent();
        }
        #endregion

        #region Form Events / Public Events
        public atMessageBox(string Description, string ApplicationName)
        {
             InitializeComponent(); 
             txtMessage.Text  = Description;
             this.Text = ApplicationName;
        } 
        public static DialogResult Show(string description,string applicationname)
        {
            using (var form = new atMessageBox(description, applicationname))
            {
                return form.ShowDialog();
            }
        }
        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
        #endregion
    }
}
