using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TerrariaImageConverter
{
    internal class TerrariaPixel
    {
        private bool IsWall = false;
        private ushort TileID = 0;
        private byte Paint = 0;
        private Color Color = Color.Empty;

        public TerrariaPixel(bool isWall, ushort tileID, byte paint, Color color)
        {
            this.IsWall = isWall;
            this.TileID = tileID;
            this.Paint = paint;
            this.Color = color;
        }

        public Color GetColor() { return Color; }
    }
}
