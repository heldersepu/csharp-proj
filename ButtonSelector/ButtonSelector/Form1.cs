using System;
using System.Drawing;
using System.Windows.Forms;

namespace ButtonSelector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = (((Button)sender).BackColor == Color.Green)? Color.Red: Color.Green;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            string seats = "";
            foreach (var control in this.Controls)
            {
                if ((control is Button) && (((Button)control).BackColor == Color.Green))
                {
                    seats += ((Button)control).Name + " ";
                }
            }
            MessageBox.Show(seats);
        }
    }
}
