    using System;
    using System.Threading;
    using System.Windows.Forms;

    namespace ProgressBat
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }

            private void button1_Click(object sender, EventArgs e)
            {
                button1.Enabled = false;
                progressBar1.Value = 0;
                for (int i = 0; i < 100; i++)
                {
                    progressBar1.Value = i;
                    progressBar1.Refresh();
                    Thread.Sleep(50);
                }
                button1.Enabled = true;
            }
        }
    }
