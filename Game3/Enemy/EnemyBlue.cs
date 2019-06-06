using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class EnemyBlue : EnemyYellow
    {
        protected int Count;
        public EnemyBlue(asd.Vector2DF pos)
            :base(pos)
        {
            Axel = new asd.Vector2DF(2.0f, 0.01f);
            Maxvel = new asd.Vector2DF(15.0f, 0.03f);
            Reward = 20;
            Attack = 10;
            MAXHP = 40;
            HP = MAXHP;
            Texture = asd.Engine.Graphics.CreateTexture2D("EnemyBlue.png");
            XBound = 1.0f;
            AttackCount = 25;
        }
        protected override void OnUpdate()
        {
            Count++;
            if (Count >= AttackCount)
            {
                Layer.AddObject(new EnemyBullet(Position, new asd.Vector2DF(0, 5), 10));
                Layer.AddObject(new EnemyBullet(Position, new asd.Vector2DF(-1, 5), 10));
                Layer.AddObject(new EnemyBullet(Position, new asd.Vector2DF(1, 5), 10));
                Count = 0;
            }
            base.OnUpdate();
        }
    }
}
