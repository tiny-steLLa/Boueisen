using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    public class ClickSystem : asd.TextureObject2D
    {
        public static int Pointx;
        public static int Pointy;
        public static asd.Vector2DF Point;
        //クリック時の生成物を決める値、Texture系のクラスで値変更、初期値は適当
        public static int ClickedNumber = -1;
        public asd.SoundSource Click = asd.Engine.Sound.CreateSoundSource("Click2.wav", true);

        protected override void OnUpdate()
        {
            Unit.unitlist.RemoveAll(unit => unit.HP <= 0);
            Pointx = (int)asd.Engine.Mouse.Position.X;
            Pointy = (int)asd.Engine.Mouse.Position.Y;
            Point = new asd.Vector2DF(Pointx / 50 * 50 + 25, Pointy / 50 * 50 + 25);
        }

        //Select マウスの位置によってずっと変わる値
        /*|-----------------|
          |           |0 | 1|
          |           |2 | 3|
          |   -1      |4 | 5|  ←Window
          |           |6 | 7|
          |           |8 | 9|
          |           |10|11|
          |-----------------
          |  -2             |*/
        public static int Select()
        {
            if (Pointx >= 600 && Pointx <= 700 && Pointy >= 0 && Pointy < 100)
            {
                return 0;
            }
            else if (Pointx > 700 && Pointx <= 800 && Pointy >= 0 && Pointy < 100)
            {
                return 1;
            }
            else if (Pointx >= 600 && Pointx <= 700 && Pointy >= 100 && Pointy < 200)
            {
                return 2;
            }
            else if (Pointx > 700 && Pointx <= 800 && Pointy >= 100 && Pointy < 200)
            {
                return 3;
            }
            else if (Pointx >= 600 && Pointx <= 700 && Pointy >= 200 && Pointy < 300)
            {
                return 4;
            }
            else if (Pointx > 700 && Pointx <= 800 && Pointy >= 200 && Pointy < 300)
            {
                return 5;
            }
            else if (Pointx >= 600 && Pointx <= 700 && Pointy >= 300 && Pointy < 400)
            {
                return 6;
            }
            else if (Pointx > 700 && Pointx <= 800 && Pointy >= 300 && Pointy < 400)
            {
                return 7;
            }
            else if (Pointx >= 600 && Pointx <= 700 && Pointy >= 400 && Pointy < 500)
            {
                return 8;
            }
            else if (Pointx > 700 && Pointx <= 800 && Pointy >= 400 && Pointy < 500)
            {
                return 9;
            }
            else if (Pointx >= 600 && Pointx <= 700 && Pointy >= 500 && Pointy <= 600)
            {
                return 10;
            }
            else if (Pointx > 700 && Pointx <= 800 && Pointy >= 500 && Pointy <= 600)
            {
                return 11;
            }
            else if (Point.Y >= 600)
            {
                return -2;
            }
            else return -1;
        }

        // unitをLayer,Listに追加、音、金の処理
        private void AddUnit (Unit unit)
        {
            Layer.AddObject(unit);
            Unit.unitlist.Add(unit);
            asd.Engine.Sound.Play(Click);
            GameScene.Money -= unit.Cost;
        }

        public void Create()
        {
            if (asd.Engine.Mouse.LeftButton.ButtonState == asd.MouseButtonState.Push && Select() == -1)
            {
                int x = Pointx / 50;
                int y = Pointy / 50;
                switch (ClickedNumber)
                {
                    case 0:
                        if (GameScene.Money >= 5 && !(Unit.unitlist.Exists(unit => unit.Position == Point)))
                        {
                            var a = new Snowman(new asd.Vector2DF(25 + 50 * x, 25 + 50 * y));
                            AddUnit(a);
                        }
                        break;
                    case 1:
                        if (GameScene.Money >= Kane.CostST && !(Unit.unitlist.Exists(unit => unit.Position == Point)))
                        {
                            var a = new Kane(new asd.Vector2DF(25 + 50 * x, 25 + 50 * y));
                            AddUnit(a);
                        }
                        break;
                    case 2:
                        if (GameScene.Money >= Dog.CostST && !(Unit.unitlist.Exists(unit => unit.Position == Point)))
                        {
                            var a = new Dog(new asd.Vector2DF(25 + 50 * x, 25 + 50 * y));
                            AddUnit(a);
                        }
                        break;
                    case 3:
                        if (GameScene.Money >= StrongDog.CostST && !(Unit.unitlist.Exists(unit => unit.Position == Point)))
                        {
                            var a = new StrongDog(new asd.Vector2DF(25 + 50 * x, 25 + 50 * y));
                            AddUnit(a);
                        }
                        break;
                    case 4:
                        if (GameScene.Money >= Human.CostST && !(Unit.unitlist.Exists(unit => unit.Position == Point)))
                        {
                            var a = new Human(new asd.Vector2DF(25 + 50 * x, 25 + 50 * y));
                            AddUnit(a);
                        }
                        break;
                    case 5:
                        if (GameScene.Money >= Human3Way.CostST && !(Unit.unitlist.Exists(unit => unit.Position == Point)))
                        {
                            var a = new Human3Way(new asd.Vector2DF(25 + 50 * x, 25 + 50 * y));
                            AddUnit(a);
                        }
                        break;
                    case 6:
                        if (GameScene.Money >= Kinoko.CostST && !(Unit.unitlist.Exists(unit => unit.Position == Point)))
                        {
                            var a = new Kinoko(new asd.Vector2DF(25 + 50 * x, 25 + 50 * y));
                            AddUnit(a);
                        }
                        break;
                    case 7:
                        if (GameScene.Money >= PoisonKinoko.CostST && !(Unit.unitlist.Exists(unit => unit.Position == Point)))
                        {
                            var a = new PoisonKinoko(new asd.Vector2DF(25 + 50 * x, 25 + 50 * y));
                            AddUnit(a);
                        }
                        break;
                    case 8:
                        if (GameScene.Money >= Kirakira.CostST && !(Unit.unitlist.Exists(unit => unit.Position == Point)))
                        {
                            var a = new Kirakira(new asd.Vector2DF(25 + 50 * x, 25 + 50 * y));
                            AddUnit(a);
                        }
                        break;
                    case 9:
                        if (GameScene.Money >= Hana.CostST && !(Unit.unitlist.Exists(unit => unit.Position == Point)))
                        {
                            var a = new Hana(new asd.Vector2DF(25 + 50 * x, 25 + 50 * y));
                            AddUnit(a);
                        }
                        break;
                    case 10:
                        if (GameScene.Money >= Wall.CostST && !(Unit.unitlist.Exists(unit => unit.Position == Point)))
                        {
                            var a = new Wall(new asd.Vector2DF(25 + 50 * x, 25 + 50 * y));
                            AddUnit(a);
                        }
                        break;
                    case 11:
                        if (GameScene.Money >= StrongWall.CostST && !(Unit.unitlist.Exists(unit => unit.Position == Point)))
                        {
                            var a = new StrongWall(new asd.Vector2DF(25 + 50 * x, 25 + 50 * y));
                            AddUnit(a);
                        }
                        break;
                }
            }
        }
    }
}
