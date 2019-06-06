using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class PlayerHP : asd.TextureObject2D
    {
        protected int HPlength;
        protected asd.Color blue = new asd.Color(255, 30, 30, 170);
        protected asd.Vector2DF startHPLine;
        protected asd.Vector2DF destHPLine;
        protected const int diameterHPLine = 20;
        public static int MaxHP;
        public static int HP;

        public PlayerHP()
        {
            MaxHP = 300;
            HP = MaxHP;
        }
        protected override void OnUpdate()
        {
            var windowSize = asd.Engine.WindowSize;
            HPlength = (windowSize.X - 10) * HP / MaxHP;
            startHPLine = new asd.Vector2DF(5, 780);
            destHPLine = startHPLine + new asd.Vector2DF(HPlength, 0);
            DrawLineAdditionally(startHPLine, destHPLine, blue, diameterHPLine, asd.AlphaBlendMode.Blend, 5);
            if (HP > MaxHP)
            {
                HP = MaxHP;
            }
        }
    }
}
