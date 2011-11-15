namespace PID773176
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.txbAddress = new System.Windows.Forms.TextBox();
            this.txbAddressList = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(381, 13);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(36, 22);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // txbAddress
            // 
            this.txbAddress.Location = new System.Drawing.Point(31, 15);
            this.txbAddress.Name = "txbAddress";
            this.txbAddress.Size = new System.Drawing.Size(344, 20);
            this.txbAddress.TabIndex = 1;
            // 
            // txbAddressList
            // 
            this.txbAddressList.Location = new System.Drawing.Point(31, 50);
            this.txbAddressList.Multiline = true;
            this.txbAddressList.Name = "txbAddressList";
            this.txbAddressList.Size = new System.Drawing.Size(385, 292);
            this.txbAddressList.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 367);
            this.Controls.Add(this.txbAddressList);
            this.Controls.Add(this.txbAddress);
            this.Controls.Add(this.btnAdd);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txbAddress;
        private System.Windows.Forms.TextBox txbAddressList;
    }
}

