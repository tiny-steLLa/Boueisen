using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    //一定時間ごとにダメージ
    class PoisonKinoko: Unit
    {
        public static int CostST = Status.Instance.PoisonKinokoStatus.Cost;
        public static int AttackST = Status.Instance.PoisonKinokoStatus.Attack;
        public static int MAXHPST = Status.Instance.PoisonKinokoStatus.HP;
        public static int MaxRangeST = Status.Instance.PoisonKinokoStatus.Range;
        public static int Poison = Status.Instance.PoisonKinokoStatus.Poison;
        public PoisonKinoko(asd.Vector2DF pos)
            :base (pos)
        {
            Cost = CostST;
            MAXHP = MAXHPST;
            HP = MAXHP;
            Attack = AttackST;
            MaxRange = MaxRangeST;
            Texture = asd.Engine.Graphics.CreateTexture2D("Dokukinoko.png");
            Scale = new asd.Vector2DF(0.5f, 0.5f);
            CenterPosition = new asd.Vector2DF(Texture.Size.X / 2, Texture.Size.Y / 2);
        }
        protected override void OnUpdate()
        {
            if (GameScene.IsStageMoving)
            {
                Count++;
                if (Count == 60)
                {
                    foreach (var obj in Layer.Objects)
                    {
                        if (!(obj is Enemy))
                            continue;
                        Enemy enemy = (Enemy)obj;
                        if (distance(enemy) < MaxRangeST)
                            enemy.HP -= Poison;
                    }
                    Count = 0;

                }
                base.OnUpdate();
            }
        }
    }
}
