using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace AsyncLambda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Using async and await Task.Run the application remains responsive
        private async void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Starting ASync Operation.";
            await Task.Run(() => ExampleMethodAsync(5));
            textBox1.Text = "Control returned to Click event handler.";
        }

        void ExampleMethodAsync(int d)
        {
            // just a time consuming operation to show the application remains responsive            
            for (int i = 0; i < int.MaxValue; i++)
            {
                var x = i - d;                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ForeColor = (this.ForeColor == Color.Cyan) ? Color.Red : Color.Cyan;
        }
    }
}
