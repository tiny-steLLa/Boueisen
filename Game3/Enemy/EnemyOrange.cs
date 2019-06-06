using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class EnemyOrange : Enemy
    {
        List<RotateBullet> BulletList = new List<RotateBullet>();
        protected int Count;
        public EnemyOrange(asd.Vector2DF pos)
            : base(pos)
        {
            Axel = new asd.Vector2DF(0, 0.3f);
            Maxvel = new asd.Vector2DF(0, 0.7f);
            Reward = 30;
            Attack = 300;
            MAXHP = 470;
            AttackCount = 13;
            HP = MAXHP;
            Texture = asd.Engine.Graphics.CreateTexture2D("EnemyOrange.png");
        }

        /// <summary>
        /// 弾生成とリストにぶち込むメソッド
        /// </summary>
        /// <param name="firstpos">初期ベクトル</param>
        /// <param name="firstvel">初期スピード</param>
        /// <param name="attack">攻撃力</param>
        /// <param name="pos">回転中心</param>
        protected void AddBullet(asd.Vector2DF firstpos,asd.Vector2DF firstvel,int attack, asd.Vector2DF pos)
        {
            RotateBullet a = new RotateBullet(firstpos,firstvel,attack,pos);
            Layer.AddObject(a);
            BulletList.Add(a);
        }
        protected override void OnUpdate()
        {
            if (Count >= AttackCount)
            {
                asd.Engine.Sound.SetVolume(asd.Engine.Sound.Play(ShotSound), VolumeChange);
                AddBullet(Position + new asd.Vector2DF(100, 0), new asd.Vector2DF(0, 6), 5, Position);
                AddBullet(Position + new asd.Vector2DF(-100, 0), new asd.Vector2DF(0, -6), 5, Position);
                AddBullet(Position + new asd.Vector2DF(150, 0), new asd.Vector2DF(0, -7), 5, Position);
                AddBullet(Position + new asd.Vector2DF(-150, 0), new asd.Vector2DF(0, 7), 5, Position);
                Count = 0;
            }
            Count++;

            foreach (var rot in BulletList)
            {
                rot.Position += Vel;
                rot.RotateCenter = Position;
            }
            base.OnUpdate();
        }
        protected override void OnDispose()
        {
            foreach (var rot in BulletList)
            {
                rot.Dispose();
            }
            base.OnDispose();

        }
    }
}