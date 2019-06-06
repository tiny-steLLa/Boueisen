using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class EnemyBlack : Enemy
    {
        protected int Count = 0;
        Random r = new Random();
        List<RotateBullet> BulletList = new List<RotateBullet>();
        public EnemyBlack(asd.Vector2DF pos)
            : base(pos)
        {
            Axel = new asd.Vector2DF(0, 0.02f);
            Maxvel = new asd.Vector2DF(0, 0.2f);
            Reward = 300;
            Attack = 100;
            MAXHP = 2500;
            HP = MAXHP;
            Texture = asd.Engine.Graphics.CreateTexture2D("EnemyBlack.png");
        }
        /// <summary>
        /// 弾生成とリストに入れるメソッド
        /// </summary>
        /// <param name="firstpos">初期ベクトル</param>
        /// <param name="firstvel">初期スピード</param>
        /// <param name="attack">攻撃力</param>
        /// <param name="pos">回転中心</param>
        protected void AddBullet(asd.Vector2DF firstpos, asd.Vector2DF firstvel, int attack, asd.Vector2DF pos)
        {
            RotateBullet a = new RotateBullet(firstpos, firstvel, attack, pos);
            Layer.AddObject(a);
            BulletList.Add(a);
        }
        protected override void OnUpdate()
        {
            if (Count%120==0)
            {
                asd.Engine.Sound.SetVolume(asd.Engine.Sound.Play(ShotSound), VolumeChange);
                HP += 3;
                AddBullet(Position + new asd.Vector2DF(100, 0), new asd.Vector2DF(0, 6), 20, Position);
                AddBullet(Position + new asd.Vector2DF(-150, 0), new asd.Vector2DF(0, 6), 20, Position);
                AddBullet(Position + new asd.Vector2DF(-100, 0), new asd.Vector2DF(0, -6), 20, Position);
                AddBullet(Position + new asd.Vector2DF(150, 0), new asd.Vector2DF(0, -6), 20, Position);
                Layer.AddObject(new EnemyBullet(Position, new asd.Vector2DF(-4, 2), 10));
                Layer.AddObject(new EnemyBullet(Position, new asd.Vector2DF(4, 2), 10));
                Layer.AddObject(new EnemyBullet(Position, new asd.Vector2DF(0, 6), 20));
                Layer.AddObject(new EnemyBullet(Position, new asd.Vector2DF(3, 6), 20));
                Layer.AddObject(new EnemyBullet(Position, new asd.Vector2DF(-3, 6), 20));
            }
            if (Count % 60 == 0 && HP < MAXHP / 2)
            {
                HP += 7;
                AddBullet(Position + new asd.Vector2DF(200, 0), new asd.Vector2DF(0, 6), 15, Position);
                AddBullet(Position + new asd.Vector2DF(-250, 0), new asd.Vector2DF(0, 6), 15, Position);
                AddBullet(Position + new asd.Vector2DF(-200, 0), new asd.Vector2DF(0, -6), 15, Position);
                AddBullet(Position + new asd.Vector2DF(250, 0), new asd.Vector2DF(0, -6), 15, Position);
            }
            if (Count % 120 == 0 && HP < MAXHP / 2&&HP>MAXHP/4)
            {
                int a = r.Next(5);
                switch (a)
                {
                    case 0:
                        Layer.AddObject(new EnemyYellow(Position));
                        break;
                    case 1:
                        Layer.AddObject(new EnemyBlue(Position));
                        break;
                    case 2:
                        Layer.AddObject(new EnemyGreen(Position));
                        break;
                    case 3:
                        Layer.AddObject(new EnemyPink(Position));
                        break;
                    case 4:
                        Layer.AddObject(new EnemyWhite(Position));
                        break;
                    case 5:
                        Layer.AddObject(new EnemyRed(Position));
                        break;
                }
            }
            if (Count % 150 == 0 && HP < MAXHP / 4)
            {
                int a = r.Next(8);
                switch (a)
                {
                    case 0:
                        Layer.AddObject(new EnemyPink(Position));
                        Layer.AddObject(new EnemyRed(Position));
                        Layer.AddObject(new EnemyYellow(Position));
                        break;
                    case 1:
                        Layer.AddObject(new EnemyRed(Position));
                        Layer.AddObject(new EnemyWhite(Position));
                        Layer.AddObject(new EnemyBlue(Position));
                        break;
                    case 2:
                        Layer.AddObject(new EnemyPink(Position));
                        Layer.AddObject(new EnemyRed(Position));
                        Layer.AddObject(new EnemyGreen(Position));
                        break;
                    case 3:
                        Layer.AddObject(new EnemyRed(Position));
                        Layer.AddObject(new EnemyPink(Position));
                        break;
                    case 4:
                        Layer.AddObject(new EnemyRed(Position));
                        Layer.AddObject(new EnemyWhite(Position));
                        break;
                    case 5:
                        Layer.AddObject(new EnemyPink(Position));
                        Layer.AddObject(new EnemyWhite(Position));
                        Layer.AddObject(new EnemyRed(Position));
                        break;
                    case 6:
                        Layer.AddObject(new EnemyPink(Position));
                        Layer.AddObject(new EnemyYellow(Position));
                        Layer.AddObject(new EnemyRed(Position));
                        break;
                    case 7:
                        Layer.AddObject(new EnemyPink(Position));
                        Layer.AddObject(new EnemyRed(Position));
                        Layer.AddObject(new EnemyGreen(Position));
                        break;
                }
            }
            foreach (var rot in BulletList)
            {
                rot.Position += Vel;
                rot.RotateCenter = Position;
            }
            if (Count % 780==0)
            {
                foreach (var obj in BulletList)
                {
                    RotateBullet rot = obj;
                    int z = r.Next(4);
                    if (z == 1)
                    {
                        asd.Vector2DF re = rot.Position- Position;
                        rot.MoveVelocity = re.Normal * 10;
                    }
                }
            }
            if (Count > 10000)
            {
                Count = 0;
            }
            Count++;
            base.OnUpdate();
           
        }
        protected override void OnDispose()
        {
            foreach (var obj in BulletList)
            {
                obj.Dispose();
            }
            base.OnDispose();
        }
    }
}
