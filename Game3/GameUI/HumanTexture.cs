using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class HumanTexture : ButtonTexture
    {
        public HumanTexture(asd.Vector2DF pos)
            :base(pos)
        {
            texture = "1509884775448.png";
            TextureNum = 4;
            Texture = asd.Engine.Graphics.CreateTexture2D(texture);
        }
    }
}
