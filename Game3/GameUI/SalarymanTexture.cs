using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class SalarymanTexture : ButtonTexture
    {
        public SalarymanTexture(asd.Vector2DF pos)
            : base(pos)
        {
            texture = "1509885962687.png";
            TextureNum = 1;
            Texture = asd.Engine.Graphics.CreateTexture2D(texture);
        }
    }
}
