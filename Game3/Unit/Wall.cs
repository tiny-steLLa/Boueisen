using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class Wall : Unit
    {
        public static int AttackST = Status.Instance.WallStatus.Attack;
        public static int MAXHPST = Status.Instance.WallStatus.HP;
        public static int CostST = Status.Instance.WallStatus.Cost;
        public Wall(asd.Vector2DF pos)
            :base (pos)
        {
            Cost = CostST;
            MAXHP = MAXHPST;
            HP = MAXHP;
            Attack = AttackST;
            Texture = asd.Engine.Graphics.CreateTexture2D("Wall.png");
        }
        protected override void OnUpdate()
        {
            base.OnUpdate();
        }
    }
}
