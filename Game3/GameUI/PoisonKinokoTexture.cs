using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class PoisonKinokoTexture : ButtonTexture
    {
        public PoisonKinokoTexture(asd.Vector2DF pos)
            : base(pos)
        {
            texture = "1509883676004.png";
            TextureNum = 7;
            Texture = asd.Engine.Graphics.CreateTexture2D(texture);
        }
    }
}
