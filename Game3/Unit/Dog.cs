using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    //相手の方向に弾を打つ
    class Dog : Unit
    {
        public static int CostST = Status.Instance.DogStatus.Cost;
        public static int AttackST = Status.Instance.DogStatus.Attack;
        public static int MAXHPST = Status.Instance.DogStatus.HP;
        public static int BulletATK = Status.Instance.DogStatus.Bullet;
        public static int maxrangeST = Status.Instance.DogStatus.Range;
        public Dog(asd.Vector2DF pos)
            : base(pos)
        {
            Cost = CostST;
            MaxRange = maxrangeST;
            MAXHP = MAXHPST;
            HP = MAXHP;
            Attack = AttackST;
            AttackCount = 60;
            Texture = asd.Engine.Graphics.CreateTexture2D("inu.png");
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

                if (GameScene.IsStageMoving)
                {
                    DecideEnemy();
                    if (Count >= AttackCount && nearestenemy != null && nearestenemy.IsAlive == true)
                    {
                        asd.Engine.Sound.SetVolume(asd.Engine.Sound.Play(ShotSound), soundChange);
                        asd.Vector2DF dir = nearestenemy.Position - Position;
                        asd.Vector2DF moveVelocity = dir.Normal * 10.0f;

                        Layer.AddObject(new Bullet(Position, moveVelocity, BulletATK));
                        Count = 0;
                    }
                    Count++;

                    if (Count > 1000) { Count = 60; }
                    base.OnUpdate();
                }
            }
        }
    }
}
