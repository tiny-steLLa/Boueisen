using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class StrongWall : Unit
    {
        public static int AttackST = Status.Instance.StrongWallStatus.Attack;
        public static int MAXHPST = Status.Instance.StrongWallStatus.HP;
        public static int CostST = Status.Instance.StrongWallStatus.Cost;
        public StrongWall(asd.Vector2DF pos)
            :base (pos)
        {
            Cost = CostST;
            MAXHP = MAXHPST;
            HP = MAXHP;
            Attack = AttackST;
            Texture = asd.Engine.Graphics.CreateTexture2D("YellowWall.png");
        }
        protected override void OnUpdate()
        {
            base.OnUpdate();
        }
    }
}
