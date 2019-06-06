using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class ClearScene : asd.Scene
    {
        bool Increasing = false;
        bool IsSceneChanging = false;
        asd.TextObject2D TitleText = new asd.TextObject2D();
        asd.TextObject2D EnterText = new asd.TextObject2D();
        asd.TextObject2D Comment = new asd.TextObject2D();
        private asd.SoundSource ClearSound;
        private asd.SoundSource Click;
        int SoundCount;

        asd.Color FontColor = new asd.Color(90, 255, 150, 255);
        protected override void OnRegistered()
        {
            Click = asd.Engine.Sound.CreateSoundSource("Click2.wav", true);
            ClearSound = asd.Engine.Sound.CreateSoundSource("Clear.wav", true);

            asd.Layer2D layer = new asd.Layer2D();
            AddLayer(layer);
            asd.TextureObject2D backGround = new asd.TextureObject2D();
            backGround.Texture = asd.Engine.Graphics.CreateTexture2D("Clear.png");
            backGround.Color = new asd.Color(255, 255, 255, 200);

            TitleText.Font = asd.Engine.Graphics.CreateDynamicFont("font.ttf", 100, FontColor, 1, new asd.Color(0, 0, 0, 255));
            TitleText.Position = new asd.Vector2DF(170, 20);
            TitleText.Text = "げーむ\n　くりあー！";

            Comment.Font = asd.Engine.Graphics.CreateDynamicFont("font.ttf", 80, new asd.Color(0,0,0,255), 1, new asd.Color(0, 0, 0, 255));
            Comment.Position = new asd.Vector2DF(280, 440);
            if (TitleScene.EasyMode || TitleScene.HardMode)
                Comment.Text = "やったぜ！";
            else
            {
                Comment.Font = asd.Engine.Graphics.CreateDynamicFont("font.ttf", 35, new asd.Color(0, 0, 0, 255), 1, new asd.Color(0, 0, 0, 255));
                Comment.Text = "タイトル画面でHを\n押しながらAを押そう!\n製作者も心折れたモードだ!";
            }

            EnterText.Font = asd.Engine.Graphics.CreateDynamicFont("font.ttf", 60, FontColor, 1, new asd.Color(0, 0, 0, 255));
            EnterText.Position = new asd.Vector2DF(200, 250);
            EnterText.Text = "クリックでタイトル";

            layer.AddObject(backGround);
            layer.AddObject(Comment);
            layer.AddObject(TitleText);
            layer.AddObject(EnterText);
            base.OnRegistered();
        }

        protected override void OnUpdated()
        {
            SoundCount++;
            if (SoundCount == 60)
            {
                asd.Engine.Sound.SetVolume(asd.Engine.Sound.Play(ClearSound), 0.2f);
            }
            if (Increasing)
            {
                var a = EnterText.Color;
                a.A += 5;
                EnterText.Color = a;
                if (EnterText.Color.A == 255)
                    Increasing = false;
            }
            else
            {
                var a = EnterText.Color;
                a.A -= 5;
                EnterText.Color = a;
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
