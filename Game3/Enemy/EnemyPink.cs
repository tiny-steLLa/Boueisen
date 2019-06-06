using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class EnemyPink : EnemyYellow
    {
        protected int Count = 0;
        public EnemyPink(asd.Vector2DF pos)
            :base(pos)
        {
            Axel = new asd.Vector2DF(0.10f, 0.01f);
            Maxvel = new asd.Vector2DF(5.0f, 2.0f);
            Reward = 10;
            Attack = 20;
            MAXHP = 250;
            AttackCount = 55;
            HP = MAXHP;
            Texture = asd.Engine.Graphics.CreateTexture2D("EnemyPink.png");
        }
        protected override void OnUpdate()
        {
            Count++;
            Vel.X += Axel.X;
            var windowSize = asd.Engine.WindowSize;
            if (Position.X > windowSize.X - Texture.Size.X / 2 - 200)
            {
                Position -= new asd.Vector2DF(550, 0);
            }

            if (Vel.X > Maxvel.X)
            {
                Vel = Maxvel;
            }
            if (Count >= AttackCount)
            {
                asd.Engine.Sound.SetVolume(asd.Engine.Sound.Play(ShotSound), VolumeChange);
                Layer.AddObject(new EnemyBullet(Position, new asd.Vector2DF(0, 4), 5));
                Count = 0;
            }
            base.OnUpdate();
        }
    }
}
