using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class TitleScene : asd.Scene
    {
        private bool Increasing, IsSceneChanging;
        public static bool EasyMode,HardMode;
        asd.TextObject2D TitleText;
        asd.TextObject2D EnterText;
        asd.Color FontColor = new asd.Color(90, 255, 150, 255);
        private asd.SoundSource StartSound;


        protected override void OnRegistered()
        {
            EasyMode = false;
            HardMode = false;
            StartSound = asd.Engine.Sound.CreateSoundSource("Click1.wav", true);
            TitleText = new asd.TextObject2D();
            EnterText = new asd.TextObject2D();
            Increasing = false;
            IsSceneChanging = false;

            asd.Layer2D layer = new asd.Layer2D();
            AddLayer(layer);
            asd.TextureObject2D backGround = new asd.TextureObject2D();
            backGround.Texture = asd.Engine.Graphics.CreateTexture2D("Title.png");
            backGround.Color = new asd.Color(255, 255, 255, 80);

            TitleText.Font = asd.Engine.Graphics.CreateDynamicFont("font.ttf", 90,FontColor, 1, new asd.Color(0, 0, 0, 255));
            TitleText.LineSpacing = 20f;
            TitleText.Position = new asd.Vector2DF(50, 20);
            TitleText.Text =  "ぼうえいせん!";

            EnterText.Font = asd.Engine.Graphics.CreateDynamicFont("font.ttf", 55,FontColor, 1, new asd.Color(0, 0, 0, 255));
            EnterText.Position = new asd.Vector2DF(50, 550);
            EnterText.Text = "クリックでスタート\n \n※Zボタンでかんたんモード";

            layer.AddObject(backGround);
            layer.AddObject(TitleText);
            layer.AddObject(EnterText);
            base.OnRegistered();
        }

        protected override void OnUpdated()
        {
            //文字の点滅処理
            if (Increasing)
            {
                var color = EnterText.Color;
                color.A+=5;
                EnterText.Color = color;
                if (EnterText.Color.A == 255)
                    Increasing = false;
            }
            else
            {
                var color = EnterText.Color;
                color.A -= 5;
                EnterText.Color = color;
                if (EnterText.Color.A == 0)
                    Increasing = true;
            }
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Z) == asd.KeyState.Push)
            {
                if (!IsSceneChanging)
                {
                    EasyMode = true;
                    asd.Engine.Sound.SetVolume(asd.Engine.Sound.Play(StartSound), 0.2f);
                    asd.Engine.ChangeSceneWithTransition(new GameScene(), new asd.TransitionFade(1, 1));
                    IsSceneChanging = true;
                }
            }
            else if (asd.Engine.Keyboard.GetKeyState(asd.Keys.A)==asd.KeyState.Push&&asd.Engine.Keyboard.GetKeyState(asd.Keys.H)==asd.KeyState.Hold)
            {
                if (!IsSceneChanging)
                {
                    HardMode = true;
                    asd.Engine.Sound.SetVolume(asd.Engine.Sound.Play(StartSound), 0.2f);
                    asd.Engine.ChangeSceneWithTransition(new GameScene(), new asd.TransitionFade(1, 1));
                    IsSceneChanging = true;
                }
            }
            else if(asd.Engine.Mouse.LeftButton.ButtonState == asd.MouseButtonState.Push)
            {
                if (!IsSceneChanging)
                {
                    asd.Engine.Sound.SetVolume(asd.Engine.Sound.Play(StartSound), 0.2f);
                    asd.Engine.ChangeSceneWithTransition(new GameScene(),new asd.TransitionFade(1,1));
                    IsSceneChanging = true;
                }
            }
            base.OnUpdated();
        }
    }
}