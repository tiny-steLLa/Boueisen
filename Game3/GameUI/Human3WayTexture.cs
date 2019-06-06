using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class Human3WayTexture : ButtonTexture
    {
        public Human3WayTexture(asd.Vector2DF pos)
            : base(pos)
        {
            texture = "1509888645166.png";
            TextureNum = 5;
            Texture = asd.Engine.Graphics.CreateTexture2D(texture);
        }
    }
}
