using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    //相手の方向に弾を打つ3way
    class StrongDog : Unit
    {
        public static int CostST = Status.Instance.StrongDogStatus.Cost;
        public static int AttackST = Status.Instance.StrongDogStatus.Attack;
        public static int MAXHPST = Status.Instance.StrongDogStatus.HP;
        public static int BulletATK = Status.Instance.StrongDogStatus.Bullet;
        public static int MaxRangeST = Status.Instance.StrongDogStatus.Range;
        public StrongDog(asd.Vector2DF pos)
            : base(pos)
        {
            Cost = CostST;
            MAXHP = MAXHPST;
            HP = MAXHP;
            Attack = AttackST;
            MaxRange = MaxRangeST;
            AttackCount = 60;
            Texture = asd.Engine.Graphics.CreateTexture2D("tuyoiinu.png");
            Scale = new asd.Vector2DF(0.5f, 0.5f);
            CenterPosition = new asd.Vector2DF(Texture.Size.X / 2, Texture.Size.Y / 2);
        }
        protected override void OnUpdate()
        {
            if (GameScene.IsStageMoving)
            {
                DecideEnemy();
                if (nearestenemy != null)
                {
                    var v = nearestenemy.Position - Position;
                    Angle = v.Degree + 90;
                }
                else
                    Angle = 0;
                if (Count >= AttackCount && nearestenemy != null && nearestenemy.IsAlive == true)
                {
                    asd.Engine.Sound.SetVolume(asd.Engine.Sound.Play(ShotSound), soundChange);
                    asd.Vector2DF dir = nearestenemy.Position - Position;
                    asd.Vector2DF moveVelocity = dir.Normal * 10.0f;
                    asd.Vector2DF moveVelocity2 = moveVelocity;
                    moveVelocity2.Degree += 10;
                    asd.Vector2DF moveVelocity3 = moveVelocity;
                    moveVelocity3.Degree -= 10;

                    Layer.AddObject(new Bullet(Position, moveVelocity, BulletATK));
                    Layer.AddObject(new Bullet(Position, moveVelocity2, BulletATK));
                    Layer.AddObject(new Bullet(Position, moveVelocity3, BulletATK));
                    Count = 0;
                }
                Count++;

                if (Count > 1000) { Count = 60; }
                base.OnUpdate();
            }
        }
    }
}
