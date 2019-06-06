using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class GameScene : asd.Scene
    {
        ClickSystem ClickSystem;
        protected asd.MapObject2D Background;
        protected asd.Layer2D BackLayer, GameLayer, UILayer;
        asd.TextObject2D UnitText, StageText, ModeText;
        Random Rand = new Random();

        private bool EnemyExists, IsSceneChanging;//敵存在？
        public static bool IsClear, IsStageMoving;//クリアフラグ, 休憩中かどうか
        private int DequeueCount, RestCount;//敵出現頻度（初期), ステージ間の休憩時間
        public static int Stage, Money;
        int Gamecount;
        int MusicCount;//音楽開始時にのみ使用
        Queue<Enemy>[] EnemyQueues = new Queue<Enemy>[10];

        private asd.SoundSource GameOverSound;
        private asd.SoundSource BGM;
        int? PlayingBgmId;

        protected override void OnRegistered()
        {
            ClickSystem = new ClickSystem();
            BackLayer = new asd.Layer2D();
            GameLayer = new asd.Layer2D();
            UILayer = new asd.Layer2D();
            UnitText = new asd.TextObject2D();
            StageText = new asd.TextObject2D();
            ModeText = new asd.TextObject2D();
            EnemyExists = false;
            IsSceneChanging = false;
            IsStageMoving = true;
            IsClear = false;
            DequeueCount = 100;
            if (TitleScene.HardMode)
                RestCount = 10;
            else RestCount = 500;

            if (TitleScene.EasyMode)
                Money = 1500;
            else
            {
                Money = 700;
            }

            Unit.unitlist = new List<Unit>();
            GameOverSound = asd.Engine.Sound.CreateSoundSource("gameover.wav", true);
            BGM = asd.Engine.Sound.CreateSoundSource("bgm.wav", false);
            BGM.IsLoopingMode = true;
            PlayingBgmId = null;

            AddLayer(GameLayer);
            AddLayer(UILayer);
            AddLayer(BackLayer);
            BackLayer.DrawingPriority = -1;
            GameLayer.DrawingPriority = 0;
            UILayer.DrawingPriority = 1;
            var moneyText = new Money();

            // 説明文を生成する。
            var font = asd.Engine.Graphics.CreateDynamicFont("font.ttf", 18, new asd.Color(255, 255, 255, 255), 1, new asd.Color(0, 0, 0, 255));
            UnitText.Font = font;
            UnitText.Position = new asd.Vector2DF(100, 610);
            UnitText.Text = "";

            var stageFont = asd.Engine.Graphics.CreateDynamicFont("font.ttf", 30, new asd.Color(55, 255, 255, 150), 1, new asd.Color(0, 0, 0, 255));
            StageText.Font = stageFont;
            StageText.Position = new asd.Vector2DF(10, 10);
            StageText.Text = "Stage0";

            var modeFont = asd.Engine.Graphics.CreateDynamicFont("font.ttf", 20, new asd.Color(55, 255, 255, 10), 1, new asd.Color(0, 0, 0, 255));
            ModeText.Font = modeFont;
            ModeText.Position = new asd.Vector2DF(10, 600);

            if (TitleScene.HardMode)
                ModeText.Text = "Hard";
            else if (TitleScene.EasyMode)
                ModeText.Text = "かんたんもーど";
            else
                ModeText.Text = "";

            //背景画像やらの配置
            asd.TextureObject2D textframe = new asd.TextureObject2D();
            textframe.Texture = asd.Engine.Graphics.CreateTexture2D("TextFrame.png");
            textframe.Position = new asd.Vector2DF(0, 600);

            asd.TextureObject2D UIback = new asd.TextureObject2D();
            UIback.Texture = asd.Engine.Graphics.CreateTexture2D("ButtonBack.png");
            UIback.Position = new asd.Vector2DF(600, 0);

            UILayer.AddObject(textframe);
            UILayer.AddObject(StageText);
            UILayer.AddObject(UIback);
            UILayer.AddObject(moneyText);
            UILayer.AddObject(UnitText);
            UILayer.AddObject(ModeText);
            Background = new asd.MapObject2D();
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    var chip = new asd.Chip2D();
                    chip.Texture = asd.Engine.Graphics.CreateTexture2D("kusa.png");
                    chip.Position = new asd.Vector2DF(50 * i, 50 * j);
                    Background.AddChip(chip);
                }
            }
            GameLayer.AddObject(ClickSystem);
            BackLayer.AddObject(Background);
            UILayer.AddObject(new PlayerHP());
            UILayer.AddObject(new SnowmanTexture(new asd.Vector2DF(600, 0)));
            UILayer.AddObject(new SalarymanTexture(new asd.Vector2DF(700, 0)));
            UILayer.AddObject(new DogTexture(new asd.Vector2DF(600, 100)));
            UILayer.AddObject(new StrongDogTexture(new asd.Vector2DF(700, 100)));
            UILayer.AddObject(new HumanTexture(new asd.Vector2DF(600, 200)));
            UILayer.AddObject(new Human3WayTexture(new asd.Vector2DF(700, 200)));
            UILayer.AddObject(new KinokoTexture(new asd.Vector2DF(600, 300)));
            UILayer.AddObject(new PoisonKinokoTexture(new asd.Vector2DF(700, 300)));
            UILayer.AddObject(new KirakiraTexture(new asd.Vector2DF(600, 400)));
            UILayer.AddObject(new FlowerTexture(new asd.Vector2DF(700, 400)));
            UILayer.AddObject(new WallTexture(new asd.Vector2DF(600, 500)));
            UILayer.AddObject(new StrongWallTexture(new asd.Vector2DF(700, 500)));
            initAllStage();
        }

        protected override void OnUpdated()
        {
            ClickSystem.Create();//クリックでUnit作成

            if (TitleScene.HardMode)
            {
                if (Gamecount % 188 == 0&&Gamecount>0)
                {
                    switch (Stage)
                    {
                        case 0:
                        case 1:
                        case 2:
                            GameLayer.AddObject(new EnemyGreen(new asd.Vector2DF(Rand.Next(0, 12) * 50 + 25, 0)));
                            break;
                        case 3:
                        case 4:
                        case 5:
                            GameLayer.AddObject(new EnemyPink(new asd.Vector2DF(Rand.Next(0, 12) * 50 + 25, 0)));
                            break;
                        case 6:
                        case 7:
                            GameLayer.AddObject(new EnemyBlue(new asd.Vector2DF(Rand.Next(7, 12) * 50 + 25, 0)));
                            break;
                        case 8:
                            GameLayer.AddObject(new EnemyBlue(new asd.Vector2DF(Rand.Next(7, 12) * 50 + 25, 0)));
                            GameLayer.AddObject(new EnemyBlue(new asd.Vector2DF(Rand.Next(0, 12) * 50 + 25, 0)));
                            break;
                        case 9:
                            GameLayer.AddObject(new EnemyRed(new asd.Vector2DF(Rand.Next(0, 4) * 50 + 25, 0)));
                            GameLayer.AddObject(new EnemyOrange(new asd.Vector2DF(Rand.Next(5, 8) * 50 + 25, 0)));
                            GameLayer.AddObject(new EnemyBlue(new asd.Vector2DF(Rand.Next(8, 12) * 50 + 25, 0)));
                            break;
                    }
                }
            }

            if (IsClear == false)
            {
                if (!PlayingBgmId.HasValue)
                    MusicCount++;
                if (MusicCount == 120)
                {
                    PlayingBgmId = asd.Engine.Sound.Play(BGM);
                    asd.Engine.Sound.SetVolume((int)PlayingBgmId, 0.2f);
                    asd.Engine.Sound.SetIsPlaybackSpeedEnabled((int)PlayingBgmId, true);
                    MusicCount = 0;
                }

                //最大HPが20%を切ったらBPMを上げる
                if (PlayerHP.HP <= PlayerHP.MaxHP / 5 && PlayingBgmId.HasValue)
                {
                    asd.Engine.Sound.SetPlaybackSpeed((int)PlayingBgmId, 1.5f);
                }
                else if (PlayerHP.HP > PlayerHP.MaxHP / 5 && PlayingBgmId.HasValue)
                {
                    asd.Engine.Sound.SetPlaybackSpeed((int)PlayingBgmId, 1.0f);
                }

                if (PlayerHP.HP <= 0 && !IsSceneChanging)
                {
                    IsSceneChanging = true;
                    if (PlayingBgmId.HasValue)
                    {
                        asd.Engine.Sound.FadeOut(PlayingBgmId.Value, 0.5f);
                        PlayingBgmId = null;
                    }
                    asd.Engine.Sound.SetVolume(asd.Engine.Sound.Play(GameOverSound), 0.2f);
                    asd.Engine.ChangeSceneWithTransition(new GameOverScene(), new asd.TransitionFade(1, 1));
                }
                EnemyCheck();
                updateStage();
                switch (ClickSystem.ClickedNumber)
                {
                    case 0:
                        UnitText.Text = Status.Instance.SnowmanStatus.Name + "\n" + Status.Instance.SnowmanStatus.Comment+"\n物理攻撃," + Snowman.AttackST + "    体力," + Snowman.MAXHPST + "     コスト," + Snowman.CostST;
                        break;
                    case 1:
                        UnitText.Text = Status.Instance.KaneStatus.Name + "\n" + Status.Instance.KaneStatus.Comment+"\n物理攻撃," + Kane.AttackST + "    体力," + Kane.MAXHPST + "     コスト," + Kane.CostST;
                        break;
                    case 2:
                        UnitText.Text = Status.Instance.DogStatus.Name + "\n" + Status.Instance.DogStatus.Comment+"\n物理攻撃," + Dog.AttackST + "    体力," + Dog.MAXHPST + "     生成コスト," + Dog.CostST + "\n弾威力," + Dog.BulletATK + "     攻撃範囲," + Dog.maxrangeST;
                        break;
                    case 3:
                        UnitText.Text = Status.Instance.StrongDogStatus.Name + "\n" + Status.Instance.StrongDogStatus.Comment+"\n物理攻撃," + StrongDog.AttackST + "    体力," + StrongDog.MAXHPST + "     生成コスト," + StrongDog.CostST + "\n弾威力," + StrongDog.BulletATK + "     攻撃範囲," + StrongDog.MaxRangeST;
                        break;
                    case 4:
                        UnitText.Text = Status.Instance.HumanStatus.Name + "\n" + Status.Instance.HumanStatus.Comment+"\n物理攻撃," + Human.AttackST + "    体力," + Human.MAXHPST + "     生成コスト," + Human.CostST + "\n弾威力," + Human.BulletATK;
                        break;
                    case 5:
                        UnitText.Text = Status.Instance.StronghumanStatus.Name+"\n"+ Status.Instance.StronghumanStatus.Comment+"\n物理攻撃," + Human3Way.AttackST + "    体力," + Human3Way.MAXHPST + "     生成コスト," + Human3Way.CostST + "\n弾威力," + Human3Way.BulletATK;
                        break;
                    case 6:
                        UnitText.Text = Status.Instance.KinokoStatus.Name + "\n" + Status.Instance.KinokoStatus.Comment+ "\n物理攻撃," + Kinoko.AttackST + "    体力," + Kinoko.MAXHPST + "     生成コスト," + Kinoko.CostST + "\n回復範囲," + Kinoko.MaxRangeST;
                        break;
                    case 7:
                        UnitText.Text = Status.Instance.PoisonKinokoStatus.Name + "\n" + Status.Instance.PoisonKinokoStatus.Comment+"\n物理攻撃," + PoisonKinoko.AttackST + "    体力," + PoisonKinoko.MAXHPST + "     生成コスト," + PoisonKinoko.CostST + "\n攻撃範囲," + PoisonKinoko.MaxRangeST;
                        break;
                    case 8:
                        UnitText.Text = Status.Instance.KirakiraStatus.Name + "\n" + Status.Instance.KirakiraStatus.Comment+"\n物理攻撃," + Kirakira.AttackST + "    体力," + Kirakira.MAXHPST + "     生成コスト," + Kirakira.CostST;
                        break;
                    case 9:
                        UnitText.Text = Status.Instance.HanaStatus.Name + "\n" + Status.Instance.HanaStatus.Comment+"\n物理攻撃," + Hana.attackST + "    体力," + Hana.MAXHPST + "     生成コスト," + Hana.CostST + "\n弾威力," + Hana.BulletATK;
                        break;
                    case 10:
                        UnitText.Text = Status.Instance.WallStatus.Name + "\n" + Status.Instance.WallStatus.Comment+"\n物理攻撃," + Wall.AttackST + "     体力," + Wall.MAXHPST + "     生成コスト," + Wall.CostST;
                        break;
                    case 11:
                        UnitText.Text = Status.Instance.StrongWallStatus.Name + "\n" + Status.Instance.StrongWallStatus.Comment+"\n物理攻撃," + StrongWall.AttackST + "     体力," + StrongWall.MAXHPST + "     生成コスト," + StrongWall.CostST;
                        break;
                }
            }
        }
        private void initAllStage()
        {
            Stage = 0;
            Gamecount = 0;
            initStage0();
            initStage1();
            initStage2();
            initStage3();
            initStage4();
            initStage5();
            initStage6();
            initStage7();
            initStage8();
            initStage9();
        }
        private void initStage0()
        {
            EnemyQueues[0] = new Queue<Enemy>();
            for (int i = 0; i < 8; i++)
            {
                EnemyQueues[0].Enqueue(new EnemyWhite(new asd.Vector2DF(Rand.Next(0, 12) * 50 + 25, 0)));
            }
        }
        private void initStage1()
        {
            EnemyQueues[1] = new Queue<Enemy>();
            for (int i = 0; i < 10; i++)
            {
                EnemyQueues[1].Enqueue(new EnemyWhite(new asd.Vector2DF(Rand.Next(0, 12) * 50 + 25, 0)));
                if (i % 3 == 0 && i > 0)
                {
                    EnemyQueues[1].Enqueue(new EnemyGreen(new asd.Vector2DF(Rand.Next(0, 12) * 50 + 25, 0)));
                }
            }
        }
        private void initStage2()
        {
            EnemyQueues[2] = new Queue<Enemy>();
            for (int i = 0; i < 8; i++)
            {
                EnemyQueues[2].Enqueue(new EnemyWhite(new asd.Vector2DF(Rand.Next(0, 12) * 50 + 25, 0)));
                EnemyQueues[2].Enqueue(new EnemyGreen(new asd.Vector2DF(Rand.Next(0, 12) * 50 + 25, 0)));
                if (i % 2 == 0)
                    EnemyQueues[2].Enqueue(new EnemyPink(new asd.Vector2DF(Rand.Next(0, 12) * 50 + 25, 0)));
            }

        }
        private void initStage3()
        {
            EnemyQueues[3] = new Queue<Enemy>();
            for (int i = 0; i < 20; i++)
            {
                EnemyQueues[3].Enqueue(new EnemyPink(new asd.Vector2DF(Rand.Next(0, 12) * 50 + 25, 0)));
                EnemyQueues[3].Enqueue(new EnemyGreen(new asd.Vector2DF(Rand.Next(0, 12) * 50 + 25, 0)));
            }
        }
        private void initStage4()
        {
            EnemyQueues[4] = new Queue<Enemy>();
            for (int i = 0; i < 20; i++)
            {
                EnemyQueues[4].Enqueue(new EnemyBlue(new asd.Vector2DF(Rand.Next(0, 12) * 50 + 25, 0)));
                EnemyQueues[4].Enqueue(new EnemyPink(new asd.Vector2DF(Rand.Next(0, 12) * 50 + 25, 0)));
            }
        }
        private void initStage5()
        {
            EnemyQueues[5] = new Queue<Enemy>();
            EnemyQueues[5].Enqueue(new EnemyOrange(new asd.Vector2DF(Rand.Next(0, 12) * 50 + 25, 0)));
            for (int i = 0; i < 20; i++)
            {
                EnemyQueues[5].Enqueue(new EnemyBlue(new asd.Vector2DF(Rand.Next(0, 12) * 50 + 25, 0)));
                EnemyQueues[5].Enqueue(new EnemyYellow(new asd.Vector2DF(Rand.Next(0, 12) * 50 + 25, 0)));
            }
            EnemyQueues[5].Enqueue(new EnemyOrange(new asd.Vector2DF(Rand.Next(0, 12) * 50 + 25, 0)));
        }
        private void initStage6()
        {
            EnemyQueues[6] = new Queue<Enemy>();
            for (int i = 0; i < 8; i++)
            {
                EnemyQueues[6].Enqueue(new EnemyOrange(new asd.Vector2DF(Rand.Next(0, 12) * 50 + 25, 0)));
                EnemyQueues[6].Enqueue(new EnemyYellow(new asd.Vector2DF(Rand.Next(0, 12) * 50 + 25, 0)));
                EnemyQueues[6].Enqueue(new EnemyPink(new asd.Vector2DF(Rand.Next(0, 12) * 50 + 25, 0)));
                if (i % 4 == 0)
                    EnemyQueues[6].Enqueue(new EnemyRed(new asd.Vector2DF(Rand.Next(0, 12) * 50 + 25, 0)));
            }
        }
        private void initStage7()
        {
            EnemyQueues[7] = new Queue<Enemy>();
            EnemyQueues[7].Enqueue(new EnemyOrange(new asd.Vector2DF(Rand.Next(0, 12) * 50 + 25, 0)));
            for (int i = 0; i < 4; i++)
            {
                EnemyQueues[7].Enqueue(new EnemyOrange(new asd.Vector2DF(Rand.Next(0, 12) * 50 + 25, 0)));
                EnemyQueues[7].Enqueue(new EnemyRed(new asd.Vector2DF(Rand.Next(0, 12) * 50 + 25, 0)));
                EnemyQueues[7].Enqueue(new EnemyGreen(new asd.Vector2DF(Rand.Next(0, 12) * 50 + 25, 0)));
                EnemyQueues[7].Enqueue(new EnemyBlue(new asd.Vector2DF(Rand.Next(0, 12) * 50 + 25, 0)));
            }
        }
        private void initStage8()
        {
            EnemyQueues[8] = new Queue<Enemy>();
            for (int i = 0; i < 20; i++)
            {
                EnemyQueues[8].Enqueue(new EnemyRed(new asd.Vector2DF(Rand.Next(0, 12) * 50 + 25, 0)));
                EnemyQueues[8].Enqueue(new EnemyBlue(new asd.Vector2DF(Rand.Next(0, 12) * 50 + 25, 0)));
                EnemyQueues[8].Enqueue(new EnemyOrange(new asd.Vector2DF(Rand.Next(0, 12) * 50 + 25, 0)));
            }
        }
        private void initStage9()
        {
            EnemyQueues[9] = new Queue<Enemy>();
            EnemyQueues[9].Enqueue(new EnemyBlack(new asd.Vector2DF(6 * 50 + 25, 0)));
            for (int i = 0; i < 10; i++)
            {
                EnemyQueues[9].Enqueue(new EnemyWhite(new asd.Vector2DF(Rand.Next(0, 12) * 50 + 25, 0)));
                EnemyQueues[9].Enqueue(new EnemyPink(new asd.Vector2DF(Rand.Next(0, 12) * 50 + 25, 0)));
            }
            if (TitleScene.HardMode)
            {
                EnemyQueues[9].Enqueue(new EnemyBlack(new asd.Vector2DF(4 * 50 + 25, 0)));
                EnemyQueues[9].Enqueue(new EnemyBlack(new asd.Vector2DF(8 * 50 + 25, 0)));
            }
        }
        private void updateStage()
        {
            if (EnemyQueues[Stage].Count > 0 && Stage < 10)
            {
                if (Gamecount % DequeueCount == 0 && Gamecount > RestCount)
                {
                    IsStageMoving = true;
                    GameLayer.AddObject(EnemyQueues[Stage].Dequeue());
                }
            }
            else if (EnemyQueues[Stage].Count == 0 && EnemyExists == false)
            {
                IsStageMoving = false;
                Stage++;
                StageText.Text = ("Stage" + Stage);
                if (Stage == 10 && !IsSceneChanging)
                {
                    if (PlayingBgmId.HasValue)
                    {
                        asd.Engine.Sound.FadeOut(PlayingBgmId.Value, 1.0f);
                        PlayingBgmId = null;
                    }
                    IsSceneChanging = true;
                    IsClear = true;
                    asd.Engine.ChangeSceneWithTransition(new ClearScene(), new asd.TransitionFade(1, 1));
                }
                if (!(TitleScene.EasyMode))
                {
                    switch (Stage)
                    {
                        case 1:
                            DequeueCount = 90;
                            break;
                        case 2:
                            DequeueCount = 70;
                            break;
                        case 3:
                            DequeueCount = 50;
                            break;
                        case 4:
                            DequeueCount = 40;
                            break;
                        case 5:
                            DequeueCount = 35;
                            break;
                        case 6:
                            DequeueCount = 30;
                            break;
                        case 7:
                            DequeueCount = 30;
                            break;
                        case 8:
                            DequeueCount = 20;
                            break;
                        case 9:
                            DequeueCount = 20;
                            break;

                    }
                }
                Gamecount = 0;
            }

            ++Gamecount;

            if (Gamecount > 100000)
            {
                Gamecount = 0;
            }
        }
        protected void EnemyCheck()
        {
            EnemyExists = false;
            foreach (var obj in GameLayer.Objects)
            {
                if (obj == null)
                {
                    EnemyExists = false;
                }
                else if (obj is Enemy)
                {
                    EnemyExists = true;
                }
            }
        }
    }
}
