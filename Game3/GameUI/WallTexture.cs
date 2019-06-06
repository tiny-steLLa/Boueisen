using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class WallTexture : ButtonTexture
    {
        public WallTexture(asd.Vector2DF pos)
            : base(pos)
        {
            texture = "WallTexture.png";
            TextureNum = 10;
            Texture = asd.Engine.Graphics.CreateTexture2D(texture);
        }
    }
}
