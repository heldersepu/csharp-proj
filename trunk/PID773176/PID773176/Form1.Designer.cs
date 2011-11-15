namespace PID773176
{
    partial class frmGeoData
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.txbAddress = new System.Windows.Forms.TextBox();
            this.txbAddressList = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fielToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFromTextFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFromStoredProcedureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputToTextFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputToSQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eXECUTEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(381, 30);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(36, 22);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txbAddress
            // 
            this.txbAddress.Location = new System.Drawing.Point(31, 32);
            this.txbAddress.Name = "txbAddress";
            this.txbAddress.Size = new System.Drawing.Size(344, 20);
            this.txbAddress.TabIndex = 0;
            this.txbAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbAddress_KeyDown);
            // 
            // txbAddressList
            // 
            this.txbAddressList.BackColor = System.Drawing.SystemColors.Window;
            this.txbAddressList.Location = new System.Drawing.Point(12, 68);
            this.txbAddressList.Multiline = true;
            this.txbAddressList.Name = "txbAddressList";
            this.txbAddressList.ReadOnly = true;
            this.txbAddressList.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txbAddressList.Size = new System.Drawing.Size(425, 287);
            this.txbAddressList.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fielToolStripMenuItem,
            this.editToolStripMenuItem,
            this.eXECUTEToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(449, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fielToolStripMenuItem
            // 
            this.fielToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFromTextFileToolStripMenuItem,
            this.loadFromStoredProcedureToolStripMenuItem});
            this.fielToolStripMenuItem.Name = "fielToolStripMenuItem";
            this.fielToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.fielToolStripMenuItem.Text = "Input";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inputToTextFileToolStripMenuItem,
            this.inputToSQLToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.editToolStripMenuItem.Text = "Output";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // loadFromTextFileToolStripMenuItem
            // 
            this.loadFromTextFileToolStripMenuItem.Name = "loadFromTextFileToolStripMenuItem";
            this.loadFromTextFileToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.loadFromTextFileToolStripMenuItem.Text = "Input from text file";
            this.loadFromTextFileToolStripMenuItem.Click += new System.EventHandler(this.loadFromTextFileToolStripMenuItem_Click);
            // 
            // loadFromStoredProcedureToolStripMenuItem
            // 
            this.loadFromStoredProcedureToolStripMenuItem.Name = "loadFromStoredProcedureToolStripMenuItem";
            this.loadFromStoredProcedureToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.loadFromStoredProcedureToolStripMenuItem.Text = "Input from SQL";
            // 
            // inputToTextFileToolStripMenuItem
            // 
            this.inputToTextFileToolStripMenuItem.Name = "inputToTextFileToolStripMenuItem";
            this.inputToTextFileToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.inputToTextFileToolStripMenuItem.Text = "Output to text file";
            // 
            // inputToSQLToolStripMenuItem
            // 
            this.inputToSQLToolStripMenuItem.Name = "inputToSQLToolStripMenuItem";
            this.inputToSQLToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.inputToSQLToolStripMenuItem.Text = "Output to SQL";
            this.inputToSQLToolStripMenuItem.Click += new System.EventHandler(this.inputToSQLToolStripMenuItem_Click);
            // 
            // eXECUTEToolStripMenuItem
            // 
            this.eXECUTEToolStripMenuItem.Name = "eXECUTEToolStripMenuItem";
            this.eXECUTEToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.eXECUTEToolStripMenuItem.Text = "EXECUTE";
            this.eXECUTEToolStripMenuItem.Click += new System.EventHandler(this.eXECUTEToolStripMenuItem_Click);
            // 
            // frmGeoData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 367);
            this.Controls.Add(this.txbAddressList);
            this.Controls.Add(this.txbAddress);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmGeoData";
            this.Text = "GeoData";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txbAddress;
        private System.Windows.Forms.TextBox txbAddressList;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fielToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFromTextFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFromStoredProcedureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inputToTextFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inputToSQLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eXECUTEToolStripMenuItem;
    }
}

