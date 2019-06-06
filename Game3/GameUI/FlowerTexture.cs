using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class FlowerTexture :ButtonTexture
    {
        public FlowerTexture(asd.Vector2DF pos)
            : base(pos)
        {
            texture = "1509875815401.png";
            TextureNum = 9;
            Texture = asd.Engine.Graphics.CreateTexture2D(texture);
        }

    }
}
