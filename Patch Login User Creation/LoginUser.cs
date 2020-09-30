using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.ServiceProcess;
using System.Diagnostics;
using System.Security.Principal;
using System.Security.AccessControl;
namespace Patch_Login_User_Creation
{
    public partial class LoginUser : Form
    {
        #region Constructor
        public LoginUser()
        {
            InitializeComponent();
            IsUserAdministrator();
        }
        #endregion

        #region Private Variables
        private int count = 0;
        int Message1;
        int Message2;
        int Message3;
        string _Message1, _Message2, _Message3;
        #endregion

        #region Populate Events
        private void SelectButtonQuickMethod()
        {
            try
            {
                tabLoginUser.SelectedTab = tabQuickMethod;
                cmbServerName.Focus();
                btnQuickMethod.ForeColor = Color.DarkSlateBlue;
                btnQuickMethod.Font = new Font(btnQuickMethod.Font, FontStyle.Bold);
                btnAdvanced.ForeColor = Color.DarkGray;
                btnAdvanced.Font = new Font(btnAdvanced.Font, FontStyle.Regular);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void SelectButonAdvanced()
        {
            try
            {
                tabLoginUser.SelectedTab = tabAdvanced;
                cmbServerName.Focus();
                btnAdvanced.ForeColor = Color.DarkSlateBlue;
                btnAdvanced.Font = new Font(btnAdvanced.Font, FontStyle.Bold);
                btnQuickMethod.ForeColor = Color.DarkGray;
                btnQuickMethod.Font = new Font(btnQuickMethod.Font, FontStyle.Regular);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool IsUserAdministrator()
        {
            bool isAdmin;
            try
            {
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(user);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (UnauthorizedAccessException ex)
            {
                isAdmin = false;
                MessageBox.Show("Please open with AdministratorMode");
            }
            catch (Exception ex)
            {
                isAdmin = false;
                MessageBox.Show("Please open with AdministratorMode");
            }
            return isAdmin;
        }
        private void GetchSystemName()
        {
            try
            {
                string sysName = System.Environment.MachineName;
                txtSystemName.Text = sysName;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void EnableSQLBrowserinAutomatic()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/c cd c:";
            startInfo.Arguments = "/c sc config sqlbrowser start= auto";
            process.StartInfo = startInfo;
            process.Start();
        }

        private void StartSQLBrowserService()
        {
            try
            {
                ServiceController _service = new ServiceController("SQLBROWSER");
                _service.Refresh();
                if (_service.Status == ServiceControllerStatus.Stopped)
                {
                    _service.Start();
                }
            }
            catch (Exception ex)
            {
                atMessgeBoxWarning.Show(ex.Message, this.Name);
            }
        }
        private void ChangeAuthenticationMode(string str, SqlConnection myConn)
        {
            try
            {
                SqlCommand myCommand = new SqlCommand(str, myConn);
                myConn.Open();
                myCommand.CommandText = "USE [master]";
                myCommand.ExecuteNonQuery();
                SqlCommand cmd = new SqlCommand("xp_instance_regwrite", myConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@rootkey", "HKEY_LOCAL_MACHINE");
                cmd.Parameters.AddWithValue("@key", "Software\\Microsoft\\MSSQLServer\\MSSQLServer");
                cmd.Parameters.AddWithValue("@value_name ", "LoginMode");
                cmd.Parameters.AddWithValue("@type", "REG_DWORD");
                cmd.Parameters.AddWithValue("@value", 2);
                cmd.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand("sp_addsrvrolemember", myConn);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@loginame", "atuser");
                cmd2.Parameters.AddWithValue("@rolename", "sysadmin");
                cmd2.ExecuteNonQuery();
                Message1 = 1;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void LoginUserCreation(string str, SqlConnection myConn)
        {
            try
            {
                myConn.Open();
                SqlCommand myCommand = new SqlCommand(str, myConn);
                myCommand.CommandText = "CREATE LOGIN [atuser] WITH PASSWORD=N'at123' , DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF";
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = "USE [master]";
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = "CREATE USER [atuser] FOR LOGIN [atuser]";
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = "USE [master]";
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = "ALTER ROLE [db_owner] ADD MEMBER [atuser]";
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = "ALTER ROLE [sysadmin] ADD MEMBER [atuser]";
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = "USE [model]";
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = "CREATE USER [atuser] FOR LOGIN [atuser]";
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = "USE [model]";
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = "ALTER ROLE [db_owner] ADD MEMBER [atuser]";
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = "USE [msdb]";
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = "CREATE USER [atuser] FOR LOGIN [atuser]";
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = "USE [msdb]";
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = "ALTER ROLE [db_owner] ADD MEMBER [atuser]";
                myCommand.ExecuteNonQuery();
                Message2 = 1;
            }
            catch (Exception e)
            {
                atMessgeBoxWarning.Show(e.Message, "Warning");
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
        }
        private void RestartSQLService()
        {
            try
            {
                ServiceController sc = new ServiceController(txtServiceName.Text.Trim(), txtSystemName.Text.Trim());
                if (sc.Status == ServiceControllerStatus.Running)
                {
                    sc.Stop();
                    sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(30));
                    sc.Refresh();
                }
                if (sc.Status == ServiceControllerStatus.Stopped)
                {
                    sc.Start();
                    sc.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(30));
                }
                Message3 = 1; 
            }
            catch (Exception)
            {
               
                throw;
            }
        }
        private void MessageBoxStatus()
        {
            try
            {
                if (Message1 == 1)
                {
                    _Message1 = "1. Login mode changed.";
                }
                else if (Message1 != 1)
                {
                    _Message1 = "1. Login mode changed process failed.";
                }
                if (Message2 == 1)
                {
                    _Message2 = "2. User created successfully.";
                }
                else if (Message2 != 1)
                {
                    _Message2 = "2. Login User Creation Failed.";
                }
                if (Message3 == 1)
                {
                    _Message3 = "3. Service Restarted Successfully";
                }
                else
                {
                    _Message3 = "3. Service Restarted failed";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Form Events
        private void timer1_Tick(object sender, EventArgs e)
        {
            count ++;
            if (count == 5)
            {
                StartSQLBrowserService();
            }
        }
        private void LoginUser_Load(object sender, EventArgs e)
        {
            try
            {
                IsUserAdministrator();
                cmbServerName.Focus();
                timer1.Start();
                EnableSQLBrowserinAutomatic();
                GetchSystemName();
                SelectButtonQuickMethod();
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void LoginUser_Activated(object sender, EventArgs e)
        {
            cmbServerName.Focus();
        }
        private void ExecuteSql(string str, SqlConnection myConn)
        {
            try
            {
                SqlCommand myCommand = new SqlCommand(str, myConn);
                try
                {
                    myConn.Open();
                    myCommand.CommandText = "USE [master]";
                    myCommand.ExecuteNonQuery();
                    SqlCommand cmd = new SqlCommand("xp_instance_regwrite", myConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@rootkey", "HKEY_LOCAL_MACHINE");
                    cmd.Parameters.AddWithValue("@key","Software\\Microsoft\\MSSQLServer\\MSSQLServer");
                    cmd.Parameters.AddWithValue("@value_name ","LoginMode");
                    cmd.Parameters.AddWithValue("@type","REG_DWORD");
                    cmd.Parameters.AddWithValue("@value",2);
                    cmd.ExecuteNonQuery();
                    Message1 = 1;
                    
                    ///***///
                   
                    //myCommand.ExecuteNonQuery();
                     myCommand.CommandText = "SELECT name FROM sys.server_principals WHERE name = 'atuser'";
                    string user =  (string)myCommand.ExecuteScalar();
                    if (user == "atuser")
                    {
                        atMessageBox.Show("User has been already created",this.Name);
                    }
                    else
                    {
                        myCommand.CommandText = "CREATE LOGIN [atuser] WITH PASSWORD=N'at123' , DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF";
                        myCommand.ExecuteNonQuery();
                        myCommand.CommandText = "USE [master]";
                        myCommand.ExecuteNonQuery();
                        myCommand.CommandText = "CREATE USER [atuser] FOR LOGIN [atuser]";
                        myCommand.ExecuteNonQuery();
                        myCommand.CommandText = "USE [master]";
                        myCommand.ExecuteNonQuery();
                        myCommand.CommandText = "ALTER ROLE [db_owner] ADD MEMBER [atuser]";
                        myCommand.ExecuteNonQuery();
                        myCommand.CommandText = "USE [model]";
                        myCommand.ExecuteNonQuery();
                        myCommand.CommandText = "CREATE USER [atuser] FOR LOGIN [atuser]";
                        myCommand.ExecuteNonQuery();
                        myCommand.CommandText = "USE [model]";
                        myCommand.ExecuteNonQuery();
                        myCommand.CommandText = "ALTER ROLE [db_owner] ADD MEMBER [atuser]";
                        myCommand.ExecuteNonQuery();
                        myCommand.CommandText = "USE [msdb]";
                        myCommand.ExecuteNonQuery();
                        myCommand.CommandText = "CREATE USER [atuser] FOR LOGIN [atuser]";
                        myCommand.ExecuteNonQuery();
                        myCommand.CommandText = "USE [msdb]";
                        myCommand.ExecuteNonQuery();
                        myCommand.CommandText = "ALTER ROLE [db_owner] ADD MEMBER [atuser]";
                        myCommand.ExecuteNonQuery();
                        Message2 = 1;
                    }
                }
                catch (System.Exception ex)
                {
                    atMessgeBoxWarning.Show(ex.Message,this.Name);
                }
                finally
                {
                    if (myConn.State == ConnectionState.Open)
                    {
                        myConn.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void btnUserCreation_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbServerName.Text.Trim() == "")
                {
                    atMessgeBoxWarning.Show("Server Name Cannot be blank!",this.Name);
                    return;
                }
                this.Cursor = Cursors.WaitCursor;
                String str;
                using (SqlConnection myConn = new SqlConnection("Server=" + cmbServerName.Text + ";Integrated security=SSPI;database=master;"))
                {

                    try
                    {
                        str = "";
                        ExecuteSql(str, myConn);
                    }
                    catch { }
                    myConn.Close();
                }
                RestartSQLService();
                MessageBoxStatus();
                SuccessMessageBox.Show(_Message1, _Message2, _Message3, this.Name);
                this.Cursor = Cursors.Arrow;
                if (this.DialogResult == DialogResult.OK)
                {
                    
                }
            }
            catch (Exception ex)
            {
                atMessgeBoxWarning.Show("Login User Creation Failed",this.Name);
                this.Cursor = Cursors.Arrow;
            }
        }
        private void cmbServerName_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbServerName.Text == txtSystemName.Text)
            {
                txtServiceName.Text = "MSSQLSERVER";
            }
            String value = cmbServerName.Text;
            Char delimiter = '\\';
            String[] substrings = value.Split(delimiter);
            foreach (var substring in substrings)
                txtServiceName.Text = substring;
                
        }
        private void cmbServerName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cmbServerName.Text.Trim().ToLower() == txtSystemName.Text.Trim().ToLower() || cmbServerName.Text.ToLower() == "localhost")
                {
                    txtServiceName.Text = "MSSQLSERVER";
                }
                else
                {
                    String value = cmbServerName.Text;
                    Char delimiter = '\\';
                    String[] substrings = value.Split(delimiter);
                    foreach (var substring in substrings)
                        txtServiceName.Text = substring;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (atMessageBox.Show("Are you sure you want to close", this.Name) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void btnClose1_Click(object sender, EventArgs e)
        {
            if (atMessageBox.Show("Are you sure you want to close", this.Name) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void btnQuickMethod_Click(object sender, EventArgs e)
        {
            SelectButtonQuickMethod();
        }
        private void btnAdvanced_Click(object sender, EventArgs e)
        {
            SelectButonAdvanced();
        }
        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.ForeColor = Color.White;
        }
        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.ForeColor = Color.DimGray;
        }
        private void btnStartBrowserService_Click(object sender, EventArgs e)
        {
            try
            {
                StartSQLBrowserService();
                atMessgeBoxWarning.Show("SQL Browser service Restarted sucessfully", "Information");
            }
            catch (Exception)
            {
                atMessgeBoxWarning.Show("Browser service Restart failed!", "Information");
                throw;
            }
        }
        private void btnAuthenticationMode_Click(object sender, EventArgs e)
        {
            if (cmbServerName.Text.Trim() == "")
            {
                atMessgeBoxWarning.Show("Server Name Cannot be blank!", "Warning");
                return;
            }
            String str;
            str = "";
            using (SqlConnection myConn = new SqlConnection("Server=" + cmbServerName.Text + ";Integrated security=SSPI;database=master;"))
            ChangeAuthenticationMode(str, myConn);
            if (Message1 == 1)
            {
                atMessgeBoxWarning.Show("Authentication Mode Changed Sucessfully", "Information");
            }
            else
            {
                atMessgeBoxWarning.Show("Authentication Mode Changed failed!", "Information");
            }
        }
        private void btnLoginUserCreation_Click(object sender, EventArgs e)
        {
            if (cmbServerName.Text.Trim() == "")
            {
                atMessgeBoxWarning.Show("Server Name Cannot be blank!", "Warning");
                return;
            }
            String str;
            str = "";
            using (SqlConnection myConn = new SqlConnection("Server=" + cmbServerName.Text + ";Integrated security=SSPI;database=master;"))
            LoginUserCreation(str, myConn);
            if (Message2 == 1)
            {
                atMessgeBoxWarning.Show("Login user created sucessfully", "Information");
            }
            else
            {
                atMessgeBoxWarning.Show("User Creation failed!", "Information");
            }
        }
        private void btnRestartService_Click(object sender, EventArgs e)
        {
            if (cmbServerName.Text.Trim() == "")
            {
                atMessgeBoxWarning.Show("Server Name Cannot be blank!", "Warning");
                return;
            }
            RestartSQLService();
            if (Message3 == 1)
            {
                atMessgeBoxWarning.Show("SQL service Restarted sucessfully", "Information");
            }
            else
            {
                atMessgeBoxWarning.Show("Service Restart failed!", "Information");
            }
        }
        #endregion
    }
}
