using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{ 
    //味方の弾
    public class Bullet : CollidableObject
    {
        protected asd.Vector2DF MoveVelocity;
        public int Attack;
        protected asd.SoundSource ColSound = asd.Engine.Sound.CreateSoundSource("damage2.wav", true);
        public Bullet(asd.Vector2DF pos,asd.Vector2DF vel,int a)
        {
            Attack = a;
            Texture = asd.Engine.Graphics.CreateTexture2D("Bullet.png");
            CenterPosition = new asd.Vector2DF(Texture.Size.X / 2, Texture.Size.Y / 2);
            Position = pos;
            MoveVelocity = vel;
            Radius = Texture.Size.X / 2;
        }
        protected override void OnUpdate()
        {
            Position += MoveVelocity;
            DisposeFromGame();

            foreach (var obj in Layer.Objects)
            { CollideWith(obj as CollidableObject); }
        }
        protected void DisposeFromGame()
        {
            var windowSize = asd.Engine.WindowSize;
            if (Position.Y < -Texture.Size.Y/2 || Position.Y > windowSize.Y -200 + Texture.Size.Y/2 || Position.X < -Texture.Size.X/2 || Position.X > windowSize.X + Texture.Size.X/2 - 200)
            {
                Dispose();
            }
        }
        public override void OnCollide(CollidableObject obj)
        {
            if (obj is Enemy)
            {
                HitEffect effect = new HitEffect();
                effect.Scale = new asd.Vector2DF(40,40);
                Layer.AddObject(effect);
                effect.Position = Position;
                effect.Play();
                asd.Engine.Sound.SetVolume(asd.Engine.Sound.Play(ColSound), 0.05f);
            }
            base.OnCollide(obj);
        }
        protected virtual void CollideWith(CollidableObject obj)
        {
            if (obj == null)
            { return; }

            if (obj is Enemy)
            {
                Enemy enemy = (Enemy)obj;
                if (IsCollide(enemy))
                {
                    OnCollide(enemy);
                    enemy.HP -= Attack;
                    Dispose();
                }
            }
        }
    }
}
