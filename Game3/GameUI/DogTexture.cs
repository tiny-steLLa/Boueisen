using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class DogTexture :ButtonTexture
    {
        public DogTexture(asd.Vector2DF pos)
            :base(pos)
        {
            texture = "1509882889252.png";
            TextureNum = 2;
            Texture = asd.Engine.Graphics.CreateTexture2D(texture);
        }
    }
}
