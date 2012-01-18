namespace DeCryptImages
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
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.txbDestin = new System.Windows.Forms.TextBox();
            this.txbSource = new System.Windows.Forms.TextBox();
            this.btnDeCrypt = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txbCabinetID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbPassw = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(19, 86);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(63, 13);
            this.Label2.TabIndex = 9;
            this.Label2.Text = "Destination:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(38, 53);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(44, 13);
            this.Label1.TabIndex = 8;
            this.Label1.Text = "Source:";
            // 
            // txbDestin
            // 
            this.txbDestin.Location = new System.Drawing.Point(84, 83);
            this.txbDestin.Name = "txbDestin";
            this.txbDestin.Size = new System.Drawing.Size(336, 20);
            this.txbDestin.TabIndex = 7;
            this.txbDestin.Text = "C:\\QuickFL\\Images";
            this.txbDestin.TextChanged += new System.EventHandler(this.txbDestin_TextChanged);
            // 
            // txbSource
            // 
            this.txbSource.Location = new System.Drawing.Point(84, 50);
            this.txbSource.Name = "txbSource";
            this.txbSource.Size = new System.Drawing.Size(336, 20);
            this.txbSource.TabIndex = 6;
            this.txbSource.TextChanged += new System.EventHandler(this.txbSource_TextChanged);
            // 
            // btnDeCrypt
            // 
            this.btnDeCrypt.Enabled = false;
            this.btnDeCrypt.Location = new System.Drawing.Point(211, 205);
            this.btnDeCrypt.Name = "btnDeCrypt";
            this.btnDeCrypt.Size = new System.Drawing.Size(75, 23);
            this.btnDeCrypt.TabIndex = 25;
            this.btnDeCrypt.Text = "DeCrypt";
            this.btnDeCrypt.UseVisualStyleBackColor = true;
            this.btnDeCrypt.Click += new System.EventHandler(this.btnDeCrypt_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(120, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Cabinet id:";
            // 
            // txbCabinetID
            // 
            this.txbCabinetID.Location = new System.Drawing.Point(179, 121);
            this.txbCabinetID.Name = "txbCabinetID";
            this.txbCabinetID.Size = new System.Drawing.Size(152, 20);
            this.txbCabinetID.TabIndex = 10;
            this.txbCabinetID.Text = "10000701";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(121, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Password:";
            // 
            // txbPassw
            // 
            this.txbPassw.Location = new System.Drawing.Point(179, 154);
            this.txbPassw.Name = "txbPassw";
            this.txbPassw.Size = new System.Drawing.Size(152, 20);
            this.txbPassw.TabIndex = 12;
            this.txbPassw.Text = "Rosalia";
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(55, 205);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(380, 23);
            this.lblStatus.TabIndex = 26;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 273);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbPassw);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbCabinetID);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txbDestin);
            this.Controls.Add(this.txbSource);
            this.Controls.Add(this.btnDeCrypt);
            this.Controls.Add(this.lblStatus);
            this.Name = "Form1";
            this.Text = "DeCrypt Images";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txbDestin;
        internal System.Windows.Forms.TextBox txbSource;
        internal System.Windows.Forms.Button btnDeCrypt;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txbCabinetID;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txbPassw;
        internal System.Windows.Forms.Label lblStatus;
    }
}

