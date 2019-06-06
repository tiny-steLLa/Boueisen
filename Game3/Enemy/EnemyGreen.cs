using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class EnemyGreen : Enemy
    {
        protected int Count = 0;
        public EnemyGreen(asd.Vector2DF pos)
            :base(pos)
        {
            Axel = new asd.Vector2DF(0, 0.06f);
            Maxvel = new asd.Vector2DF(0, 0.5f);
            Reward = 8;
            Attack = 20;
            MAXHP = 70;
            AttackCount = 35;
            HP = MAXHP;
            Texture = asd.Engine.Graphics.CreateTexture2D("EnemyGreen.png");
        }
        protected override void OnUpdate()
        {
            Count++;
            if (Count >= AttackCount)
            {
                asd.Engine.Sound.SetVolume(asd.Engine.Sound.Play(ShotSound), VolumeChange);
                Layer.AddObject(new EnemyBullet(Position, new asd.Vector2DF(0, 4), 20));
                Count = 0;
            }
            base.OnUpdate();
        }
    }
}
