namespace PjtDailyTask
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
            this.cmdReport = new System.Windows.Forms.Button();
            this.cmdCreateAce = new System.Windows.Forms.Button();
            this.cmdOpen = new System.Windows.Forms.Button();
            this.cmdTemplate = new System.Windows.Forms.Button();
            this.FromDateCalender = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSave = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmdReport
            // 
            this.cmdReport.Location = new System.Drawing.Point(104, 251);
            this.cmdReport.Name = "cmdReport";
            this.cmdReport.Size = new System.Drawing.Size(224, 42);
            this.cmdReport.TabIndex = 0;
            this.cmdReport.Text = "Generate Report of new ZipIt";
            this.cmdReport.UseVisualStyleBackColor = true;
            this.cmdReport.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdCreateAce
            // 
            this.cmdCreateAce.Location = new System.Drawing.Point(378, 55);
            this.cmdCreateAce.Name = "cmdCreateAce";
            this.cmdCreateAce.Size = new System.Drawing.Size(152, 29);
            this.cmdCreateAce.TabIndex = 1;
            this.cmdCreateAce.Text = "Create Ace Ticket";
            this.cmdCreateAce.UseVisualStyleBackColor = true;
            this.cmdCreateAce.Click += new System.EventHandler(this.cmdUploadAce_Click);
            // 
            // cmdOpen
            // 
            this.cmdOpen.Location = new System.Drawing.Point(378, 187);
            this.cmdOpen.Name = "cmdOpen";
            this.cmdOpen.Size = new System.Drawing.Size(152, 30);
            this.cmdOpen.TabIndex = 2;
            this.cmdOpen.Text = "Open UploadShar";
            this.cmdOpen.UseVisualStyleBackColor = true;
            this.cmdOpen.Click += new System.EventHandler(this.button3_Click);
            // 
            // cmdTemplate
            // 
            this.cmdTemplate.Location = new System.Drawing.Point(378, 121);
            this.cmdTemplate.Name = "cmdTemplate";
            this.cmdTemplate.Size = new System.Drawing.Size(152, 32);
            this.cmdTemplate.TabIndex = 3;
            this.cmdTemplate.Text = "Generate Template for Ace";
            this.cmdTemplate.UseVisualStyleBackColor = true;
            // 
            // FromDateCalender
            // 
            this.FromDateCalender.Location = new System.Drawing.Point(101, 55);
            this.FromDateCalender.Name = "FromDateCalender";
            this.FromDateCalender.ShowToday = false;
            this.FromDateCalender.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Select From Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 311);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Save Report To";
            // 
            // txtSave
            // 
            this.txtSave.Location = new System.Drawing.Point(104, 311);
            this.txtSave.Name = "txtSave";
            this.txtSave.Size = new System.Drawing.Size(224, 20);
            this.txtSave.TabIndex = 9;
            this.txtSave.Text = "C:\\";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 404);
            this.Controls.Add(this.txtSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FromDateCalender);
            this.Controls.Add(this.cmdTemplate);
            this.Controls.Add(this.cmdOpen);
            this.Controls.Add(this.cmdCreateAce);
            this.Controls.Add(this.cmdReport);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdReport;
        private System.Windows.Forms.Button cmdCreateAce;
        private System.Windows.Forms.Button cmdOpen;
        private System.Windows.Forms.Button cmdTemplate;
        private System.Windows.Forms.MonthCalendar FromDateCalender;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSave;
    }
}

