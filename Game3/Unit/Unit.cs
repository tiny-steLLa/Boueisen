using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    public class Unit : CollidableObject
    {
        //HPゲージ
        protected int HPlength;
        protected asd.Color Yellow = new asd.Color(255, 255, 0, 170);
        protected asd.Vector2DF StartHPLine;
        protected asd.Vector2DF DestHPLine;
        protected const int DiameterHPLine = 5;

        //作るのに必要なお金
        public int Cost;//override先でstaticにする
        public int MAXHP;//同上
        public int Attack;//同上
        public int Count;
        public int HP;
        //敵に攻撃可能な半径
        public int MaxRange;
        protected int AttackCount = 0;

        //GameSceneで初期化
        public static List<Unit> unitlist;
        protected Enemy nearestenemy;
        asd.SoundSource ColSound = asd.Engine.Sound.CreateSoundSource("damage1.wav", true);
        protected asd.SoundSource ShotSound = asd.Engine.Sound.CreateSoundSource("shot.wav", true);
        public float soundChange = 0.2f;//shotの音の大きさ調整用

        public Unit(asd.Vector2DF pos)
        {
            //画像適当
            Texture = asd.Engine.Graphics.CreateTexture2D("EnemyRed.png");
            Position = pos;
            CenterPosition = new asd.Vector2DF(Texture.Size.X / 2, Texture.Size.Y / 2);
            Radius = Texture.Size.X / 2;
        }

        protected override void OnAdded()
        {
            base.OnAdded();
        }
        protected int distance(CollidableObject obj)
        {
            int t = (int)obj.Position.X - (int)Position.X;
            int s = (int)obj.Position.Y - (int)Position.Y;
            return (int)Math.Sqrt(t * t + s * s);
        }
        public override void OnCollide(CollidableObject obj)
        {
            if (obj is Enemy)
            {
                HitEffectEnemy effect = new HitEffectEnemy();
                effect.Scale = new asd.Vector2DF(4, 4);
                Layer.AddObject(effect);
                effect.Position = Position;
                effect.Play();
                asd.Engine.Sound.SetVolume(asd.Engine.Sound.Play(ColSound), 0.2f);
            }
            else if (obj is EnemyBullet)
            {
                HitEffectEnemy effect = new HitEffectEnemy();
                effect.Scale = new asd.Vector2DF(4, 4);
                Layer.AddObject(effect);
                effect.Position = Position;
                effect.Play();
                //弾との衝突音はEnemyBulletで
            }
            base.OnCollide(obj);
        }
        protected void CollideWith(CollidableObject obj)
        {
            if (obj == null)
            { return; }
            if (obj is Enemy)
            {
                Enemy enemy = (Enemy)obj;
                if (IsCollide(enemy))
                {
                    HP -= enemy.Attack;
                    OnCollide(enemy);
                }

                else if (obj is EnemyBullet)
                {
                    EnemyBullet enemybullet = (EnemyBullet)obj;
                    if (IsCollide(enemybullet))
                    {
                        //HPはEnemyBulletで。
                        //attackがEnemy依存で全部０ダメージになる
                        OnCollide(enemybullet);
                    }
                }
            }
        }
        //継承先で使う。一番近い敵を探す
        protected virtual void DecideEnemy()
        {
            //複数の敵の距離の最小値
            int MinDistance = int.MaxValue;
            foreach (var obj in Layer.Objects)
            {
                if (!(obj is Enemy))
                    continue;
                Enemy enemy = (Enemy)obj;
                if (distance(enemy) <= MinDistance)
                {
                    MinDistance = distance(enemy);
                    nearestenemy = enemy;

                    if (MinDistance > MaxRange)
                    { nearestenemy = null; }
                }
            }
        }
        protected override void OnUpdate()
        {
            if (GameScene.IsStageMoving)
            {
                if (HP < 0)
                    Dispose();
                foreach (var obj in Layer.Objects)
                    CollideWith(obj as CollidableObject);
                //list追加処理,消去の処理はClickSystemで(一回/フレームだけ呼びたい)

                if (HP >= MAXHP)
                {
                    HP = MAXHP;
                }
                HPlength = 50 * HP / MAXHP;
                StartHPLine = Position - new asd.Vector2DF(25, 25);
                DestHPLine = StartHPLine + new asd.Vector2DF(HPlength, 0);
                DrawLineAdditionally(StartHPLine, DestHPLine, Yellow, DiameterHPLine, asd.AlphaBlendMode.Blend, 5);
            }
        }
    }
}
