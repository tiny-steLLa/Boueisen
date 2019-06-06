using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class StrongDogTexture : ButtonTexture
    {
        public StrongDogTexture(asd.Vector2DF pos)
            :base(pos)
        {
            texture = "1509888733365.png";
            TextureNum = 3;
            Texture = asd.Engine.Graphics.CreateTexture2D(texture);
        }
    }
}
