namespace AccuAuto
{
    partial class Form1
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
            this.btnImport = new System.Windows.Forms.Button();
            this.txbDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblGroup = new System.Windows.Forms.Label();
            this.lblFile = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txbPassw = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbDB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbServer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCounter = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Location = new System.Drawing.Point(196, 238);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(79, 29);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // txbDirectory
            // 
            this.txbDirectory.Location = new System.Drawing.Point(116, 165);
            this.txbDirectory.Name = "txbDirectory";
            this.txbDirectory.Size = new System.Drawing.Size(348, 20);
            this.txbDirectory.TabIndex = 1;
            this.txbDirectory.Text = "E:\\Conversion\\Conversion\\AccuAuto\\QQ011068\\DATA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "AccuAuto Directory:";
            // 
            // lblGroup
            // 
            this.lblGroup.Location = new System.Drawing.Point(48, 205);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(109, 13);
            this.lblGroup.TabIndex = 3;
            this.lblGroup.Text = "---";
            // 
            // lblFile
            // 
            this.lblFile.Location = new System.Drawing.Point(163, 205);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(301, 13);
            this.lblFile.TabIndex = 4;
            this.lblFile.Text = "---";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txbPassw);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txbUser);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txbDB);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txbServer);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(32, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 127);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SQL Server";
            // 
            // txbPassw
            // 
            this.txbPassw.Location = new System.Drawing.Point(256, 82);
            this.txbPassw.Name = "txbPassw";
            this.txbPassw.Size = new System.Drawing.Size(100, 20);
            this.txbPassw.TabIndex = 7;
            this.txbPassw.Text = "Ncnysn4378$";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(215, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Passw:";
            // 
            // txbUser
            // 
            this.txbUser.Location = new System.Drawing.Point(101, 83);
            this.txbUser.Name = "txbUser";
            this.txbUser.Size = new System.Drawing.Size(108, 20);
            this.txbUser.TabIndex = 5;
            this.txbUser.Text = "QQ999999";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "User:";
            // 
            // txbDB
            // 
            this.txbDB.Location = new System.Drawing.Point(101, 57);
            this.txbDB.Name = "txbDB";
            this.txbDB.Size = new System.Drawing.Size(255, 20);
            this.txbDB.TabIndex = 3;
            this.txbDB.Text = "QFWinData_QQ999999";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "DB Name:";
            // 
            // txbServer
            // 
            this.txbServer.Location = new System.Drawing.Point(101, 31);
            this.txbServer.Name = "txbServer";
            this.txbServer.Size = new System.Drawing.Size(255, 20);
            this.txbServer.TabIndex = 1;
            this.txbServer.Text = "iprodhost.prod.qq\\iprod04,32459";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Server Name:";
            // 
            // lblCounter
            // 
            this.lblCounter.Location = new System.Drawing.Point(71, 227);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(62, 14);
            this.lblCounter.TabIndex = 6;
            this.lblCounter.Text = "000";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 288);
            this.Controls.Add(this.lblCounter);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.lblGroup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbDirectory);
            this.Controls.Add(this.btnImport);
            this.Name = "Form1";
            this.Text = "Import .json files from AccuAuto";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.TextBox txbDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txbPassw;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbDB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCounter;
    }
}

