using System;
using System.Drawing;
using System.Windows.Forms;

namespace LimitCursor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Cursor.Position = CenterPoint(panel2);
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            Cursor.Position = CenterPoint(panel1);
        }

        private Point CenterPoint(Control control)
        {
            return new Point(
                Left + control.Left + control.Width / 2,
                Top + control.Top + control.Height / 2);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X - panel1.Left < 20 && e.Y - panel1.Top < 20)
            {
                Cursor.Position = CenterPoint(panel1);
                Console.WriteLine($"{e.X} {e.Y}");
            }
        }
    }
}
