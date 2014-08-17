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
    public partial class ToTangoXport
    {
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
