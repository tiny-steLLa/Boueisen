using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    //一定時間ごとに味方回復
    class Kinoko : Unit
    {
        public static int CostST = Status.Instance.KinokoStatus.Cost;
        public static int AttackST = Status.Instance.KinokoStatus.Attack;
        public static int MAXHPST = Status.Instance.KinokoStatus.HP;
        public static int MaxRangeST = Status.Instance.KinokoStatus.Range;

        public static int Heal=1;
        public Kinoko(asd.Vector2DF pos)
            : base(pos)
        {
            Cost = CostST;
            MAXHP = MAXHPST;
            HP = MAXHP;
            MaxRange = MaxRangeST;
            Texture = asd.Engine.Graphics.CreateTexture2D("Kinoko.png");
            Scale = new asd.Vector2DF(0.5f, 0.5f);
            CenterPosition = new asd.Vector2DF(Texture.Size.X / 2, Texture.Size.Y / 2);
        }
        protected override void OnUpdate()
        {
            if (GameScene.IsStageMoving)
            {
                Count++;
                if (Count % 80 == 0)
                {
                    foreach (var obj in Layer.Objects)
                    {
                        if (!(obj is Unit))
                            continue;
                        Unit unit = (Unit)obj;
                        unit.HP += Heal;
                    }
                }
                base.OnUpdate();
            }
        }
    }
}
