using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TMapArt
{
    public partial class Form1 : Form
    {
        SolidBrush preBrush = new SolidBrush(Color.Empty);
        public Form1()
        {
            InitializeComponent();
        }

        private void Convert_Click_1(object sender, EventArgs e)
        {
        }

        private void HexIn_TextChanged(object sender, EventArgs e)
        {
            if (HexIn.Text.Length == 6)
            {
                InputColor.BackColor = ParseColor(HexIn.Text);
                TileDataOut.Clear();
                Color hexColor = ParseColor(HexIn.Text);
                var (outputText, outputColor) = ColorCompare.Distance(hexColor);
                TileDataOut.AppendText(outputText);
                OutputColor.BackColor = outputColor;
            }
        }

        private Color ParseColor(string color)
        {
            try
            {
                Color hexColor = System.Drawing.ColorTranslator.FromHtml("#" + color);
                return hexColor;
            }
            catch (Exception w)
            {
                MessageBox.Show("Enter valid hex code");
                return Color.Empty;
            }
        }
    }
}
