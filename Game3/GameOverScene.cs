using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class GameOverScene : asd.Scene
    {
        bool Increasing = false;
        bool IsSceneChanging = false;
        asd.TextObject2D TitleText = new asd.TextObject2D();
        asd.TextObject2D StageText = new asd.TextObject2D();
        asd.TextObject2D EnterText = new asd.TextObject2D();
        asd.Color FontColor = new asd.Color(90, 255, 150, 255);
        private asd.SoundSource Click;
        protected override void OnRegistered()
        {
            Click = asd.Engine.Sound.CreateSoundSource("Click2.wav", true);

            asd.Layer2D layer = new asd.Layer2D();
            AddLayer(layer);
            asd.TextureObject2D backGround = new asd.TextureObject2D();
            backGround.Texture = asd.Engine.Graphics.CreateTexture2D("Gameover.png");
            backGround.Color = new asd.Color(255, 255, 255, 200);

            TitleText.Font = asd.Engine.Graphics.CreateDynamicFont("font.ttf", 90, FontColor, 1, new asd.Color(0, 0, 0, 255));
            TitleText.Position = new asd.Vector2DF(80, 20);
            TitleText.Text = "げーむおーばー";

            StageText.Font = asd.Engine.Graphics.CreateDynamicFont("font.ttf", 45, FontColor, 1, new asd.Color(0, 0, 0, 255));
            StageText.Position = new asd.Vector2DF(400, 150);
            StageText.Text = "ステージ" + GameScene.Stage + "到達!!";

            EnterText.Font = asd.Engine.Graphics.CreateDynamicFont("font.ttf", 70, FontColor, 1, new asd.Color(0, 0, 0, 255));
            EnterText.Position = new asd.Vector2DF(120, 700);
            EnterText.Text = "クリックでタイトル";

            layer.AddObject(backGround);
            layer.AddObject(TitleText);
            layer.AddObject(EnterText);
            layer.AddObject(StageText);
            base.OnRegistered();
        }

        protected override void OnUpdated()
        {
            if (Increasing)
            {
                var a = EnterText.Color;
                a.A += 5;
                EnterText.Color = a;
                StageText.Color = a;
                if (EnterText.Color.A == 255)
                    Increasing = false;
            }
            else
            {
                var a = EnterText.Color;
                a.A -= 5;
                EnterText.Color = a;
                StageText.Color = a;
                if (EnterText.Color.A == 0)
                    Increasing = true;
            }
            if (asd.Engine.Mouse.LeftButton.ButtonState == asd.MouseButtonState.Push)
            {
                if (!IsSceneChanging)
                {
                    asd.Engine.Sound.Play(Click);
                    asd.Engine.ChangeSceneWithTransition(new TitleScene(), new asd.TransitionFade(1, 1));
                    IsSceneChanging = true;
                }
            }
            base.OnUpdated();
        }
    }
}
