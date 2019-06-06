using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class StrongWallTexture : ButtonTexture
    {
        public StrongWallTexture(asd.Vector2DF pos)
            : base(pos)
        {
            texture = "YellowWallTexture.png";
            TextureNum = 11;
            Texture = asd.Engine.Graphics.CreateTexture2D(texture);
        }
    }
}
