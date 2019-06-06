using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class EnemyYellow : Enemy
    {
        protected bool RightVel=true;
        public EnemyYellow(asd.Vector2DF pos)
            :base(pos)
        {
            Axel = new asd.Vector2DF(1.0f, 0.7f);
            Maxvel = new asd.Vector2DF(17.0f, 3.0f);
            Reward = 22;
            Attack = 30;
            MAXHP = 500;
            HP = MAXHP;
            XBound = 1.2f;
            Texture = asd.Engine.Graphics.CreateTexture2D("EnemyYellow.png");
        }
        protected override void OnUpdate()
        {
            if (Maxvel.X < Vel.X)
            {
                RightVel = false;
            }
            if (-Maxvel.X > Vel.X)
            {
                RightVel = true;
            }

            if (RightVel == true)
            {
                Vel.X += Axel.X;
            }
            else
            {
                Vel.X -= Axel.X;
            }
            var windowSize = asd.Engine.WindowSize;
            if (Position.X < Texture.Size.X/2)
            {
                Vel.X = Maxvel.X * XBound *1.4f;
            }
            else if (Position.X > windowSize.X - Texture.Size.X/2 - 200)
            {
                Vel.X = -Maxvel.X * XBound *1.4f;
            }
            base.OnUpdate();
        }
    }
}
