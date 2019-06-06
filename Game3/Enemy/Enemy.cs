namespace Game3
{
    public abstract class Enemy : CollidableObject
    {
        protected asd.Vector2DF Vel;
        protected asd.Vector2DF Maxvel;
        public int Attack;
        protected int Reward;
        public int HP;
        protected int MAXHP;
        protected int AttackCount;
        protected asd.Vector2DF Axel;
        protected float XBound = 0;//X方向の反発係数

        protected int HPlength;
        protected asd.Color Blue = new asd.Color(0, 200, 255, 170);
        protected asd.Vector2DF StartHPLine;
        protected asd.Vector2DF DestHPLine;
        protected const int DiameeterHPLine = 5;
        protected asd.SoundSource ColSound = asd.Engine.Sound.CreateSoundSource("damage1.wav", true);
        protected asd.SoundSource ShotSound = asd.Engine.Sound.CreateSoundSource("shot2.wav", true);
        protected float VolumeChange = 0.1f;//shot音調整

        public Enemy(asd.Vector2DF pos)
        {
            //画像適当
            Texture = asd.Engine.Graphics.CreateTexture2D("EnemyRed.png");
            Position = pos;
            CenterPosition = new asd.Vector2DF(Texture.Size.X / 2, Texture.Size.Y / 2);
            Radius = Texture.Size.X / 2.0f;
        }
        protected override void OnUpdate()
        {
            foreach (var obj in Layer.Objects)
            { CollideWith(obj as CollidableObject); }
            //敵HP
            HPlength = Texture.Size.X * HP / MAXHP;
            StartHPLine = Position - new asd.Vector2DF(Texture.Size.X/2,Texture.Size.Y/2);
            DestHPLine = StartHPLine + new asd.Vector2DF(HPlength, 0);
            DrawLineAdditionally(StartHPLine, DestHPLine, Blue, DiameeterHPLine, asd.AlphaBlendMode.Blend, 5);

            Vel.Y += Axel.Y;
            if (Vel.Y > Maxvel.Y)
            { Vel.Y = Maxvel.Y; }
            //Xの速度処理と画面外の処理はoverride先

            Position += Vel;
            if (HP < 0)
            {
                Dispose();
                GameScene.Money += Reward;
            }
            var windowSize = asd.Engine.WindowSize;
            if (Position.Y > windowSize.Y - 200 - Texture.Size.Y/2)
            {
                asd.Engine.Sound.SetVolume(asd.Engine.Sound.Play(ColSound), 0.2f);
                PlayerHP.HP -= Attack;
                Position -= new asd.Vector2DF(0, 600);
            }
            if (Position.Y < -Texture.Size.Y / 2)
            {
                Vel.Y = 2;
            }
        }
        protected virtual void CollideWith(CollidableObject obj)
        {
            if (obj == null)
            { return; }

            else if (obj is Unit)
            {
                Unit unit = (Unit)obj;
                if (IsCollide(unit))
                {
                    Vel.Y = -Maxvel.Y*3;
                    Vel.X = -Vel.X*XBound;
                    HP -= unit.Attack;
                    OnCollide(unit);
                }
            }
            else if (obj is Bullet)
            {
                Bullet bullet = (Bullet)obj;
                if (IsCollide(bullet))
                {
                    //HPとかはbulletクラス
                    OnCollide(bullet);
                }
            }
        }
    }
}
