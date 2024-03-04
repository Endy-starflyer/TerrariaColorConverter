using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System;
using System.Xml;
using System.Net.Http.Headers;

namespace TMapArt
{
    internal class ColorCompare
    {
        public static (String, Color) Distance(Color c)
        {
            StreamReader sr = new StreamReader("..\\..\\Colors.txt");
            string line;
            List<Color> Comp = new List<Color>();
            while ((line = sr.ReadLine()) != null)
            {
                string[] array = line.Split('	');
                Comp.Add(System.Drawing.ColorTranslator.FromHtml("#" + array[2]));
            }
            sr.DiscardBufferedData();
            sr.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
            int min = int.MaxValue;
            int index = 0;
            Color output = Color.Empty;
            for (int i = 0; i < Comp.Count; i++)
            {
                Color color = Comp[i];
                int d = Convert.ToInt32(Math.Pow(c.R - color.R, 2) + Math.Pow(c.G - color.G, 2) + Math.Pow(c.B - color.B, 2));
                if (min > d)
                {
                    min = d;
                    index = i;
                    output = color;
                }
            }
            for (int i = 0; i < index; i++)
            {
                sr.ReadLine();
            }
            string result = (($"Distance: {Math.Pow(c.R - Comp[index].R, 2) + Math.Pow(c.G - Comp[index].G, 2) + Math.Pow(c.B - Comp[index].B, 2)}") + Environment.NewLine + sr.ReadLine());
            sr.Close();
            (String, Color) product = (result, output);
            return product;
        }
    }
}