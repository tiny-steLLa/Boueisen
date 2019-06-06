using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    //弾を消す
    class Hana : Unit
    {
        public static int CostST = Status.Instance.HanaStatus.Cost;
        public static int attackST = Status.Instance.HanaStatus.Attack;
        public static int MAXHPST = Status.Instance.HanaStatus.HP;
        public static int BulletATK = Status.Instance.HanaStatus.Bullet;

        public Hana(asd.Vector2DF pos)
            : base(pos)
        {
            Cost = CostST;
            MAXHP = MAXHPST;
            HP = MAXHP;
            Texture = asd.Engine.Graphics.CreateTexture2D("neko.png");
            Scale = new asd.Vector2DF(0.5f, 0.5f);
            CenterPosition = new asd.Vector2DF(Texture.Size.X / 2, Texture.Size.Y / 2);
        }
        protected override void OnUpdate()
        {
            if (GameScene.IsStageMoving)
            {
                Count++;
                if (Count == 40)
                {
                    Layer.AddObject(new StrongBullet(Position, new asd.Vector2DF(-1.5f, -5), BulletATK));
                    asd.Engine.Sound.SetVolume(asd.Engine.Sound.Play(ShotSound), soundChange);
                }
                else if (Count == 60)
                {
                    Layer.AddObject(new StrongBullet(Position, new asd.Vector2DF(-0.7f, -5), BulletATK));
                    asd.Engine.Sound.SetVolume(asd.Engine.Sound.Play(ShotSound), soundChange);
                }
                else if (Count == 80)
                {
                    Layer.AddObject(new StrongBullet(Position, new asd.Vector2DF(0, -5), BulletATK));
                    asd.Engine.Sound.SetVolume(asd.Engine.Sound.Play(ShotSound), soundChange);
                }
                else if (Count == 100)
                {
                    Layer.AddObject(new StrongBullet(Position, new asd.Vector2DF(0.7f, -5), BulletATK));
                    asd.Engine.Sound.SetVolume(asd.Engine.Sound.Play(ShotSound), soundChange);
                }
                if (Count == 120)
                {
                    Layer.AddObject(new StrongBullet(Position, new asd.Vector2DF(1.5f, -4), BulletATK));
                    asd.Engine.Sound.SetVolume(asd.Engine.Sound.Play(ShotSound), soundChange);
                    Count = 0;
                }
                base.OnUpdate();
            }
        }
    }
}
