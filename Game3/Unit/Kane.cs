using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    //金を生み出す
    class Kane　: Unit
    {
        public static int CostST = Status.Instance.KaneStatus.Cost;
        public static int AttackST = Status.Instance.KaneStatus.Attack;
        public static int MAXHPST = Status.Instance.KaneStatus.HP;
        public static int Income = Status.Instance.KaneStatus.Income;

        public Kane(asd.Vector2DF pos)
            : base(pos)
        {
            Cost = CostST;
            Attack = AttackST;
            MAXHP = MAXHPST;
            HP = MAXHPST;
            Texture = asd.Engine.Graphics.CreateTexture2D("kane.png");
            Scale = new asd.Vector2DF(0.5f, 0.5f);
            Radius *= Scale.X;
            CenterPosition = new asd.Vector2DF(Texture.Size.X / 2, Texture.Size.Y / 2);
        }
        protected override void OnUpdate()
        {
            if (GameScene.IsStageMoving)
            {
                Count++;
                if (Count % 360 == 0)
                {
                    GameScene.Money += Income;
                }
                base.OnUpdate();
            }
        }
    }
}
