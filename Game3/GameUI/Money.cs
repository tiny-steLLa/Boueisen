using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class Money :asd.TextObject2D
    {
        public Money()
        {
            asd.Font font = asd.Engine.Graphics.CreateDynamicFont("font.ttf", 24, new asd.Color(255, 255, 255, 255), 1, new asd.Color(0, 0, 0, 255));
            Font = font;
            Position = new asd.Vector2DF(600, 740);
        }

        protected override void OnUpdate()
        {
            Text = "Money : " + GameScene.Money.ToString();
        }
    }
}
