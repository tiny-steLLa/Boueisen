using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//相手の弾と衝突して消す
namespace Game3
{
    class StrongBullet : Bullet
    {
        public StrongBullet(asd.Vector2DF pos, asd.Vector2DF vel, int a)
            :base(pos,vel,a)
        {
            Texture = asd.Engine.Graphics.CreateTexture2D("StrongBullet.png");
        }
        protected override void OnUpdate()
        {
            Position += MoveVelocity;
            DisposeFromGame();

            foreach (var obj in Layer.Objects)
            { CollideWith(obj as CollidableObject); }
        }
        public override void OnCollide(CollidableObject obj)
        {
            if (obj is EnemyBullet)
            {
                HitEffect effect = new HitEffect();
                effect.Scale = new asd.Vector2DF(20, 20);
                Layer.AddObject(effect);
                effect.Position = Position;
                effect.Play();
                asd.Engine.Sound.SetVolume(asd.Engine.Sound.Play(ColSound), 0.05f);
            }
            base.OnCollide(obj);
        }
        protected override void CollideWith(CollidableObject obj)
        {
            base.CollideWith(obj);
            if (obj is EnemyBullet)
            {
                EnemyBullet bullet = (EnemyBullet)obj;
                if (IsCollide(bullet))
                {
                    OnCollide(bullet);
                    bullet.Dispose();
                    Dispose();
                }
            }
        }
    }
}
