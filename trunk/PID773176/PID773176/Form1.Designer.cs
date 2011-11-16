namespace GeoData
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFromSQLStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFromTextFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eXECUTEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OutputToSQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OutputToTextFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runUnattendedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Latitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Longitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(506, 33);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(36, 22);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "&add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txbAddress
            // 
            this.txbAddress.Location = new System.Drawing.Point(39, 35);
            this.txbAddress.Name = "txbAddress";
            this.txbAddress.Size = new System.Drawing.Size(461, 20);
            this.txbAddress.TabIndex = 0;
            this.txbAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbAddress_KeyDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inputToolStripMenuItem,
            this.eXECUTEToolStripMenuItem,
            this.outputToolStripMenuItem,
            this.runUnattendedToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(594, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inputToolStripMenuItem
            // 
            this.inputToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFromSQLStripMenuItem,
            this.loadFromTextFileToolStripMenuItem});
            this.inputToolStripMenuItem.Name = "inputToolStripMenuItem";
            this.inputToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.inputToolStripMenuItem.Text = "&Input";
            // 
            // loadFromSQLStripMenuItem
            // 
            this.loadFromSQLStripMenuItem.Name = "loadFromSQLStripMenuItem";
            this.loadFromSQLStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.loadFromSQLStripMenuItem.Text = "Input from &SQL";
            this.loadFromSQLStripMenuItem.Click += new System.EventHandler(this.loadFromSQLStripMenuItem_Click);
            // 
            // loadFromTextFileToolStripMenuItem
            // 
            this.loadFromTextFileToolStripMenuItem.Name = "loadFromTextFileToolStripMenuItem";
            this.loadFromTextFileToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.loadFromTextFileToolStripMenuItem.Text = "Input from &Text file";
            this.loadFromTextFileToolStripMenuItem.Click += new System.EventHandler(this.loadFromTextFileToolStripMenuItem_Click);
            // 
            // eXECUTEToolStripMenuItem
            // 
            this.eXECUTEToolStripMenuItem.Name = "eXECUTEToolStripMenuItem";
            this.eXECUTEToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.eXECUTEToolStripMenuItem.Text = "E&XECUTE";
            this.eXECUTEToolStripMenuItem.Click += new System.EventHandler(this.eXECUTEToolStripMenuItem_Click);
            // 
            // outputToolStripMenuItem
            // 
            this.outputToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OutputToSQLToolStripMenuItem,
            this.OutputToTextFileToolStripMenuItem});
            this.outputToolStripMenuItem.Enabled = false;
            this.outputToolStripMenuItem.Name = "outputToolStripMenuItem";
            this.outputToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.outputToolStripMenuItem.Text = "&Output";
            // 
            // OutputToSQLToolStripMenuItem
            // 
            this.OutputToSQLToolStripMenuItem.Name = "OutputToSQLToolStripMenuItem";
            this.OutputToSQLToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.OutputToSQLToolStripMenuItem.Text = "Output to &SQL";
            this.OutputToSQLToolStripMenuItem.Click += new System.EventHandler(this.OutputToSQLToolStripMenuItem_Click);
            // 
            // OutputToTextFileToolStripMenuItem
            // 
            this.OutputToTextFileToolStripMenuItem.Name = "OutputToTextFileToolStripMenuItem";
            this.OutputToTextFileToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.OutputToTextFileToolStripMenuItem.Text = "Output to &Text file";
            this.OutputToTextFileToolStripMenuItem.Click += new System.EventHandler(this.OutputToTextFileToolStripMenuItem_Click);
            // 
            // runUnattendedToolStripMenuItem
            // 
            this.runUnattendedToolStripMenuItem.Name = "runUnattendedToolStripMenuItem";
            this.runUnattendedToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.runUnattendedToolStripMenuItem.Text = "Run Unattended";
            this.runUnattendedToolStripMenuItem.Click += new System.EventHandler(this.runUnattendedToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeight = 20;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Address,
            this.Latitude,
            this.Longitude,
            this.ID});
            this.dataGridView.Location = new System.Drawing.Point(24, 75);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(548, 271);
            this.dataGridView.TabIndex = 4;
            this.dataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView_RowsAdded);
            // 
            // Address
            // 
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            this.Address.Width = 254;
            // 
            // Latitude
            // 
            this.Latitude.HeaderText = "Latitude";
            this.Latitude.Name = "Latitude";
            // 
            // Longitude
            // 
            this.Longitude.HeaderText = "Longitude";
            this.Longitude.Name = "Longitude";
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Width = 50;
            // 
            // frmGeoData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 371);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.txbAddress);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 396);
            this.MinimumSize = new System.Drawing.Size(600, 396);
            this.Name = "frmGeoData";
            this.Text = "GeoData";
            this.Shown += new System.EventHandler(this.frmGeoData_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txbAddress;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFromTextFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFromSQLStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OutputToTextFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OutputToSQLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eXECUTEToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ToolStripMenuItem runUnattendedToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Latitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn Longitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
    }
}

