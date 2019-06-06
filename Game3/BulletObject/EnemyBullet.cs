using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    public class EnemyBullet : CollidableObject
    {
        public asd.Vector2DF MoveVelocity;
        public int Attack;
        asd.SoundSource ColSound = asd.Engine.Sound.CreateSoundSource("damage1.wav", true);
        public EnemyBullet(asd.Vector2DF pos, asd.Vector2DF vel, int attack)
        {
            this.Attack = attack;
            Texture = asd.Engine.Graphics.CreateTexture2D("EnemyBullet.png");
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
        //実際の画面より大きい
        protected void DisposeFromGame()
        {
            var windowSize = asd.Engine.WindowSize;
            if (Position.Y < -Texture.Size.Y / 2 -200|| Position.Y > windowSize.Y + Texture.Size.Y / 2 || Position.X < -Texture.Size.X / 2 -200 || Position.X > windowSize.X + Texture.Size.X / 2)
            {
                Dispose();
            }
        }
        public override void OnCollide(CollidableObject obj)
        {
            asd.Engine.Sound.SetVolume(asd.Engine.Sound.Play(ColSound), 0.1f);
            base.OnUpdate();
        }
        protected void CollideWith(CollidableObject obj)
        {
            if (obj == null)
            { return; }

            if (obj is Unit)
            {
                Unit unit = (Unit)obj;
                if (IsCollide(unit))
                {
                    OnCollide(unit);
                    Dispose();
                    unit.HP -= Attack;
                }
            }
        }
        protected override void OnDispose()
        {
            base.OnDispose();
        }
    }
}
