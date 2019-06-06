using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class KinokoTexture : ButtonTexture
    {
        public KinokoTexture(asd.Vector2DF pos)
            : base(pos)
        {
            texture = "1509883808660.png";
            TextureNum = 6;
            Texture = asd.Engine.Graphics.CreateTexture2D(texture);
        }
    }
}
