namespace WindowsFormsApplication7
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
            this.bunifuCustomLabel1 = new System.Windows.Forms.Label();
            this.bunifuFlatButton1 = new System.Windows.Forms.Button();
            this.bunifuFlatButton4 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.proxy_list = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(51, 45);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(35, 13);
            this.bunifuCustomLabel1.TabIndex = 0;
            this.bunifuCustomLabel1.Text = "label1";
            // 
            // bunifuFlatButton1
            // 
            this.bunifuFlatButton1.Location = new System.Drawing.Point(45, 216);
            this.bunifuFlatButton1.Name = "bunifuFlatButton1";
            this.bunifuFlatButton1.Size = new System.Drawing.Size(75, 23);
            this.bunifuFlatButton1.TabIndex = 1;
            this.bunifuFlatButton1.Text = "button1";
            this.bunifuFlatButton1.UseVisualStyleBackColor = true;
            this.bunifuFlatButton1.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // bunifuFlatButton4
            // 
            this.bunifuFlatButton4.Location = new System.Drawing.Point(153, 216);
            this.bunifuFlatButton4.Name = "bunifuFlatButton4";
            this.bunifuFlatButton4.Size = new System.Drawing.Size(75, 23);
            this.bunifuFlatButton4.TabIndex = 2;
            this.bunifuFlatButton4.Text = "button1";
            this.bunifuFlatButton4.UseVisualStyleBackColor = true;
            this.bunifuFlatButton4.Click += new System.EventHandler(this.bunifuFlatButton4_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(162, 45);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(100, 55);
            this.richTextBox2.TabIndex = 3;
            this.richTextBox2.Text = "";
            // 
            // proxy_list
            // 
            this.proxy_list.Location = new System.Drawing.Point(31, 133);
            this.proxy_list.Name = "proxy_list";
            this.proxy_list.Size = new System.Drawing.Size(216, 55);
            this.proxy_list.TabIndex = 4;
            this.proxy_list.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.proxy_list);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.bunifuFlatButton4);
            this.Controls.Add(this.bunifuFlatButton1);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label bunifuCustomLabel1;
        private System.Windows.Forms.Button bunifuFlatButton1;
        private System.Windows.Forms.Button bunifuFlatButton4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox proxy_list;
    }
}

