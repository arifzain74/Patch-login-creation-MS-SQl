namespace Patch_Login_User_Creation
{
    partial class SuccessMessageBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuccessMessageBox));
            this.btnOK = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblMessage3 = new System.Windows.Forms.Label();
            this.lblMessage2 = new System.Windows.Forms.Label();
            this.lblMessage1 = new System.Windows.Forms.Label();
            this.pcImage = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(97, 231);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(133, 34);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.lblMessage3);
            this.pnlMain.Controls.Add(this.lblMessage2);
            this.pnlMain.Controls.Add(this.btnOK);
            this.pnlMain.Controls.Add(this.lblMessage1);
            this.pnlMain.Controls.Add(this.pcImage);
            this.pnlMain.Location = new System.Drawing.Point(0, 2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(322, 273);
            this.pnlMain.TabIndex = 1;
            // 
            // lblMessage3
            // 
            this.lblMessage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.lblMessage3.Font = new System.Drawing.Font("Noto Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage3.Location = new System.Drawing.Point(19, 187);
            this.lblMessage3.Name = "lblMessage3";
            this.lblMessage3.Size = new System.Drawing.Size(301, 22);
            this.lblMessage3.TabIndex = 4;
            this.lblMessage3.Text = "3. Service Restarted";
            this.lblMessage3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMessage3.Visible = false;
            // 
            // lblMessage2
            // 
            this.lblMessage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.lblMessage2.Font = new System.Drawing.Font("Noto Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage2.Location = new System.Drawing.Point(19, 155);
            this.lblMessage2.Name = "lblMessage2";
            this.lblMessage2.Size = new System.Drawing.Size(301, 22);
            this.lblMessage2.TabIndex = 3;
            this.lblMessage2.Text = "2. User Created Successfully";
            this.lblMessage2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMessage2.Visible = false;
            // 
            // lblMessage1
            // 
            this.lblMessage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblMessage1.Font = new System.Drawing.Font("Noto Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage1.Location = new System.Drawing.Point(19, 124);
            this.lblMessage1.Name = "lblMessage1";
            this.lblMessage1.Size = new System.Drawing.Size(301, 22);
            this.lblMessage1.TabIndex = 1;
            this.lblMessage1.Text = "1. Login Mode Changed";
            this.lblMessage1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMessage1.Visible = false;
            // 
            // pcImage
            // 
            this.pcImage.Image = ((System.Drawing.Image)(resources.GetObject("pcImage.Image")));
            this.pcImage.Location = new System.Drawing.Point(-36, -88);
            this.pcImage.Name = "pcImage";
            this.pcImage.Size = new System.Drawing.Size(364, 310);
            this.pcImage.TabIndex = 0;
            this.pcImage.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SuccessMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(322, 276);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SuccessMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SuccessMessageBox";
            this.Load += new System.EventHandler(this.SuccessMessageBox_Load);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblMessage1;
        private System.Windows.Forms.PictureBox pcImage;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblMessage3;
        private System.Windows.Forms.Label lblMessage2;
    }
}