using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class Human : Unit
    {
        public static int CostST = Status.Instance.HumanStatus.Cost;
        public static int AttackST = Status.Instance.HumanStatus.Attack;
        public static int MAXHPST = Status.Instance.HumanStatus.HP;
        public static int BulletATK = Status.Instance.HumanStatus.Bullet;
        public Human(asd.Vector2DF pos)
            : base(pos)
        {
            Cost = CostST;
            MAXHP = MAXHPST;
            HP = MAXHP;
            Attack = AttackST;
            AttackCount = 30;
            Texture = asd.Engine.Graphics.CreateTexture2D("hito.png");
            Scale = new asd.Vector2DF(0.5f, 0.5f);
            CenterPosition = new asd.Vector2DF(Texture.Size.X / 2, Texture.Size.Y / 2);
        }
        protected override void OnUpdate()
        {
            if (GameScene.IsStageMoving)
            {
                Count++;
                if (Count >= AttackCount)
                {
                    asd.Engine.Sound.SetVolume(asd.Engine.Sound.Play(ShotSound), soundChange);
                    Layer.AddObject(new Bullet(Position, new asd.Vector2DF(0, -4), BulletATK));
                    Count = 0;
                }
                base.OnUpdate();
            }
        }
    }
}
