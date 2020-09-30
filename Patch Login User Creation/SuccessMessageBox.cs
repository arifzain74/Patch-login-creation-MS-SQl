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
    public partial class SuccessMessageBox : Form
    {
        #region Constructor
        public SuccessMessageBox()
        {
            InitializeComponent();
        }
        #endregion

        #region Private Variables
        private int count = 0;
        private string mMessage1;
        private string mMessage2;
        private string mMessage3;
        private string mApplicationName;
        #endregion

        #region Form Events
        private void SuccessMessageBox_Load(object sender, EventArgs e)
        {
            timer1.Start();
            btnOK.Visible = false;
            lblMessage1.Text = "";
        }
        public SuccessMessageBox(string Message1, string Message2, string Message3, string ApplicationName)
        {
            InitializeComponent();
            mMessage1 = Message1;
            mMessage2 = Message2;
            mMessage3 = Message3;
            mApplicationName = ApplicationName;
        }
        public static DialogResult Show(string Message1, string Message2, string Message3, string ApplicationName)
        {
            using (var form = new SuccessMessageBox(Message1, Message2, Message3, ApplicationName))
            {
                return form.ShowDialog();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            if (count == 6)
            {
                lblMessage1.Visible = true;
                lblMessage1.Text = mMessage1;
            }
            if (count == 12)
            {
                lblMessage2.Visible = true;
                if (mMessage2 == "2. Login User Creation Failed.")
                {
                    lblMessage2.ForeColor = Color.Crimson;
                }
                lblMessage2.Text = mMessage2;
            }
            if (count == 18)
            {
                lblMessage3.Visible = true;
                lblMessage3.Text = mMessage3;
            }
            if (count == 21)
            {
                pcImage.Enabled = false;
                count = 0;

                btnOK.Visible = true;
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
