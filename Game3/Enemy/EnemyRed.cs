using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    
    public class EnemyRed : Enemy
    {
        protected int Count;
        public EnemyRed(asd.Vector2DF pos)
            :base(pos)
        {
            Axel = new asd.Vector2DF(0, 0.03f);
            Maxvel = new asd.Vector2DF(0, 0.5f);
            Reward = 14;
            Attack = 60;
            MAXHP = 150;
            AttackCount = 60;
            HP = MAXHP;
            Texture = asd.Engine.Graphics.CreateTexture2D("EnemyRed.png");
        }
        protected override void OnUpdate()
        {
            Count++;
            if (Count >= AttackCount)
            {
                asd.Engine.Sound.SetVolume(asd.Engine.Sound.Play(ShotSound), VolumeChange);
                Layer.AddObject(new EnemyBullet(Position, new asd.Vector2DF(0, 5), 15));
                Layer.AddObject(new EnemyBullet(Position, new asd.Vector2DF(1.5f, 5), 10));
                Layer.AddObject(new EnemyBullet(Position, new asd.Vector2DF(-1.5f, 5), 10));
                Count = 0;
            }
            base.OnUpdate();
        }
    }
}
