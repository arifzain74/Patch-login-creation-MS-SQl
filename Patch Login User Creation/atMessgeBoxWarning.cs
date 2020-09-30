using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Patch_Login_User_Creation
{
    public partial class atMessgeBoxWarning : Form
    {
        #region Constructor
        public atMessgeBoxWarning()
        {
            InitializeComponent();
        }
        #endregion

        #region Form Events / Public Events
        public atMessgeBoxWarning(string Description, string Caption)
        {
             InitializeComponent(); 
             txtMessage.Text  = Description;
             lblCaption.Text = Caption;
        }
        public static DialogResult Show(string description, string Caption)
        {
            using (var form = new atMessgeBoxWarning(description, Caption))
            {
                return form.ShowDialog();
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion
    }
}
