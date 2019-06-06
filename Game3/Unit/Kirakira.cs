using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    //player回復
    class Kirakira : Unit
    {
        public static int CostST = Status.Instance.KirakiraStatus.Cost;
        public static int AttackST = Status.Instance.KirakiraStatus.Attack;
        public static int MAXHPST = Status.Instance.KirakiraStatus.HP;
        public static int Heal = Status.Instance.KirakiraStatus.Heal;
        public Kirakira(asd.Vector2DF pos)
            : base(pos)
        {
            Cost = CostST;
            MAXHP = MAXHPST;
            HP = MAXHP;
            Attack = AttackST;
            Texture = asd.Engine.Graphics.CreateTexture2D("kirakira.png");
            Scale = new asd.Vector2DF(0.5f, 0.5f);
            CenterPosition = new asd.Vector2DF(Texture.Size.X / 2, Texture.Size.Y / 2);
        }
        protected override void OnUpdate()
        {
            if (GameScene.IsStageMoving)
            {
                Count++;
                {
                    if (Count % 300 == 0)
                    {
                        PlayerHP.HP += Heal;
                    }
                }
                base.OnUpdate();
            }
        }
    }
}
