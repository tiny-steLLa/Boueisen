using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Game3
{
    //何も効果がないUnit
    public class Snowman : Unit
    {
        public static int CostST = Status.Instance.SnowmanStatus.Cost;
        public static int AttackST = Status.Instance.SnowmanStatus.Attack;
        public static int MAXHPST = Status.Instance.SnowmanStatus.HP;
        public Snowman(asd.Vector2DF pos)
            : base(pos)
        {
            Cost = CostST;
            Attack = AttackST;
            MAXHP = MAXHPST;
            HP = MAXHP;
            Texture = asd.Engine.Graphics.CreateTexture2D("yukidaruma.png");
            Scale = new asd.Vector2DF(0.5f, 0.5f);
            CenterPosition = new asd.Vector2DF(Texture.Size.X / 2, Texture.Size.Y / 2);
        }
        protected override void OnUpdate()
        {
            base.OnUpdate();
        }
        
    }
}