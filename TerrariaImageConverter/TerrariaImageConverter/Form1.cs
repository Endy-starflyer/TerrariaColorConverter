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
    public partial class Form1 : Form
    {
        List<TerrariaPixel> TerrariaColors = new List<TerrariaPixel>();
        Color[,] InputImageArray;
        Color[,] OutputImageArray;
        TerrariaPixel[,] TerrariaMapArray;

        public Form1()
        {
            InitializeComponent();
            ResetColors();
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            string inputImagePath = ImportImage();
            inputPictureBox.Load(inputImagePath);
            InputImageArray = DecodePNG(inputImagePath);
        }

        private void colorEditButton_Click(object sender, EventArgs e)
        {
            ColorForm Colors = new ColorForm();
            Colors.Show();
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            TerrariaColors = LoadColors();
            OutputImageArray = new Color[InputImageArray.GetLength(0), InputImageArray.GetLength(1)];
            TerrariaMapArray = new TerrariaPixel[InputImageArray.GetLength(0), InputImageArray.GetLength(1)];

            for (int i = 0; i < InputImageArray.GetLength(0); i++)
            {
                for (int j = 0; j < InputImageArray.GetLength(1); j++)
                {
                    (Color outputColor, TerrariaPixel outputTile) terrariaColor = NearestTerrariaColor(InputImageArray[i, j]);
                    OutputImageArray[i, j] = terrariaColor.outputColor;
                    TerrariaMapArray[i, j] = terrariaColor.outputTile;
                }
            }
            OutputImage(OutputImageArray);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ResetColors()
        {
            File.Delete("..\\..\\docs\\Colors.txt");
            File.Copy("..\\..\\docs\\ColorsReset.txt", "..\\..\\docs\\Colors.txt");
        }

        private string ImportImage()
        {
            string inputImagePath;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    inputImagePath = openFileDialog.FileName;
                    return inputImagePath;
                }
                else return null;
            }
        }

        private Color[,] DecodePNG(string InputImagePath)
        {
            Bitmap decoder = new Bitmap(InputImagePath);
            Color[,] inputArray = new Color[decoder.Width, decoder.Height];
            for (int i = 0; i < decoder.Width; i++)
            {
                for (int j = 0; j < decoder.Height; j++)
                {
                    inputArray[i,j] = decoder.GetPixel(i, j);
                }
            }
            return inputArray;
        }

        private void OutputImage(Color[,] outputImageArray)
        {
            throw new NotImplementedException();
        }

        private List<TerrariaPixel> LoadColors()
        {
            StreamReader sr = new StreamReader("..\\..\\docs\\Colors.txt");
            string line;
            List<TerrariaPixel> terrariaColors = new List<TerrariaPixel>();
            while ((line = sr.ReadLine()) != null)
            {
                string[] colorData = line.Split('	');
                (bool isWall, ushort tileID) tileData = GetTileData(colorData[0]);
                terrariaColors.Add(new TerrariaPixel(tileData.isWall, tileData.tileID, ConvertPaint(colorData[1]), System.Drawing.ColorTranslator.FromHtml('#' + colorData[2])));
            }
            sr.Close();
            return terrariaColors;
        }

        private (bool, ushort) GetTileData(string colorData)
        {
            string[] tileData = colorData.Split(' ');
            if (tileData[0] == "WALL:") return (true, Convert.ToUInt16(tileData[1]));
            else return (false, Convert.ToUInt16(tileData[1]));
        }

        private byte ConvertPaint(string paintString)
        {
            byte paintByte;
            if (paintString == "None") paintByte = 0;
            else if (paintString == "Red") paintByte = 1;
            else if (paintString == "Orange") paintByte = 2;
            else if (paintString == "Yellow") paintByte = 3;
            else if (paintString == "Lime") paintByte = 4;
            else if (paintString == "Green") paintByte = 5;
            else if (paintString == "Teal") paintByte = 6;
            else if (paintString == "Cyan") paintByte = 7;
            else if (paintString == "SkyBlue") paintByte = 8;
            else if (paintString == "Blue") paintByte = 9;
            else if (paintString == "Purple") paintByte = 10;
            else if (paintString == "Violet") paintByte = 11;
            else if (paintString == "Pink") paintByte = 12;
            else if (paintString == "DeepRed") paintByte = 13;
            else if (paintString == "DeepOrange") paintByte = 14;
            else if (paintString == "DeepYellow") paintByte = 15;
            else if (paintString == "DeepLime") paintByte = 16;
            else if (paintString == "DeepGreen") paintByte = 17;
            else if (paintString == "DeepTeal") paintByte = 18;
            else if (paintString == "DeepCyan") paintByte = 19;
            else if (paintString == "DeepSkyBlue") paintByte = 20;
            else if (paintString == "DeepBlue") paintByte = 21;
            else if (paintString == "DeepPurple") paintByte = 22;
            else if (paintString == "DeepViolet") paintByte = 23;
            else if (paintString == "DeepPink") paintByte = 24;
            else if (paintString == "Black") paintByte = 25;
            else if (paintString == "White") paintByte = 26;
            else if (paintString == "Gray") paintByte = 27;
            else if (paintString == "Brown") paintByte = 28;
            else if (paintString == "Shadow") paintByte = 29;
            else if (paintString == "Negative") paintByte = 30;
            else if (paintString == "Illuminant") paintByte = 31;
            else return 0;
            return paintByte;
        }

        private (Color, TerrariaPixel) NearestTerrariaColor(Color inputColor)
        {
            int min = int.MaxValue;
            Color outputColor = Color.Empty;
            TerrariaPixel outputTile = TerrariaColors[0];

            for (int i = 0; i < TerrariaColors.Count; i++)
            {
                Color compareColor = TerrariaColors[i].GetColor();
                int colorDistance = Convert.ToInt32(
                    Math.Pow(inputColor.R - compareColor.R, 2) +
                    Math.Pow(inputColor.G - compareColor.G, 2) +
                    Math.Pow(inputColor.B - compareColor.B, 2));
                if (colorDistance < min)
                {
                    min = colorDistance;
                    outputColor = inputColor;
                    outputTile = TerrariaColors[i];
                }
            }

            return (outputColor, outputTile);
        }
    }
}
