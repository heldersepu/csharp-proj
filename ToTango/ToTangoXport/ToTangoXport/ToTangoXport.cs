using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToTangoXport
{
    public partial class ToTangoXport : Form
    {
        public ToTangoXport()
        {
            InitializeComponent();
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "ToTango";
            saveFileDialog1.Filter = "ToTango Config|*.ToTango";

            openFileDialog1.AddExtension = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.DefaultExt = "ToTango";
            openFileDialog1.Filter = "ToTango Config|*.ToTango";
            openFileDialog1.FileName = "";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = ((DataGridView)(sender)).CurrentRow;
            if (row.Cells[0].Value != null)
            {
                string url = row.Cells[0].Value.ToString();
                if (url.Length > 0)
                {
                    MessageBox.Show(url);
                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count == 1)
                MessageBox.Show("Nothing to save...");
            else
            {
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName != "")
                {
                    this.writeToFile(saveFileDialog1.FileName);
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                this.loadFromFile(openFileDialog1.FileName);
            }
        }

        private void loadFromFile(string FileName)
        {
            dataGridView.Rows.Clear();
            foreach (string line in File.ReadAllLines(FileName))
            {
                dataGridView.Rows.Add();
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (row.Cells[0].Value == null)
                    {
                        row.Cells[0].Value = line;
                        break;
                    }
                }
            }
        }

        private void writeToFile(string FileName)
        {
            List<string> lines = new List<string>();
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    string url = row.Cells[0].Value.ToString();
                    if (url.Length > 0)
                    {
                        lines.Add(url);
                    }
                }
            }
            File.WriteAllLines(FileName, lines);
        }
    }
}
