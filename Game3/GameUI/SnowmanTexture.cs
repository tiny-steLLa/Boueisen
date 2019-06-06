using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class SnowmanTexture : ButtonTexture
    {
        public SnowmanTexture(asd.Vector2DF pos)
            :base(pos)
        {
            texture = "1509886607944.png";
            TextureNum = 0;
            Texture = asd.Engine.Graphics.CreateTexture2D(texture);
        }
    }
}
