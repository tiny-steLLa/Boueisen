using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    //movevelocityの初期x方向は0なら使える
    public class RotateBullet : EnemyBullet
    {
        protected float BulletRadius;
        //回転系中心
        public asd.Vector2DF RotateCenter;
        protected float F;
        public RotateBullet(asd.Vector2DF pos,asd.Vector2DF vel,int attack,asd.Vector2DF c)
            :base(pos,vel,attack)
        {
            asd.Vector2DF rad = c - pos;
            BulletRadius = rad.Length;
            Texture = asd.Engine.Graphics.CreateTexture2D("RotateBullet.png");
            RotateCenter = c;
            F = MoveVelocity.Length * MoveVelocity.Length * 1/BulletRadius;
        }
        protected override void OnUpdate()
        {
            asd.Vector2DF dir = RotateCenter - Position;
            MoveVelocity += dir.Normal* F;
            if (dir.Length > 300)
            {
                Dispose();
            }
            base.OnUpdate();
        }
    }
}
