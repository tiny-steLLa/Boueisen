using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class EnemyWhite : Enemy
    {
        public EnemyWhite(asd.Vector2DF pos)
            : base(pos)
        {
            Axel = new asd.Vector2DF(0, 0.05f);
            Maxvel = new asd.Vector2DF(0, 1.0f);
            Reward = 6;
            Attack = 30;
            MAXHP = 120;
            HP = MAXHP;
            Texture = asd.Engine.Graphics.CreateTexture2D("EnemyWhite.png");
        }
        protected override void OnUpdate()
        {
            base.OnUpdate();
        }
    }
}
