using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class KirakiraTexture : ButtonTexture
    {
        public KirakiraTexture(asd.Vector2DF pos)
            :base(pos)
        {
            texture = "1509885496761.png";
            TextureNum = 8;
            Texture = asd.Engine.Graphics.CreateTexture2D(texture);
        }
    }
}
