using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TerrariaImageConverter
{
    public partial class ColorForm : Form
    {
        public ColorForm()
        {
            InitializeComponent();
            LoadColors();
        }

        private void LoadColors()
        {
            colorListBox.Text = File.ReadAllText("..\\..\\docs\\Colors.txt");
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            File.WriteAllText("..\\..\\docs\\Colors.txt", colorListBox.Text);
            this.Close();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            File.Delete("..\\..\\docs\\Colors.txt");
            File.Copy("..\\..\\docs\\ColorsReset.txt", "..\\..\\docs\\Colors.txt");
            this.Close();
        }
    }
}
