using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class ButtonTexture : asd.TextureObject2D
    {
        //元画像
        protected String TexturePath = "";
        protected int TextureNum = 0;
        private asd.SoundSource Click;
        public ButtonTexture(asd.Vector2DF pos, int textureNum, string path)
        {
            Click = asd.Engine.Sound.CreateSoundSource("Click2.wav", true);
            TexturePath = path;
            TextureNum = textureNum;
            Texture = asd.Engine.Graphics.CreateTexture2D(TexturePath);
            Position = pos;
        }
        protected override void OnUpdate()
        {
            TextureSystem();
        }
        //クリックの画像変更とか、clicknumberの変更してくれる,Object生成はClickSystem
        protected void TextureSystem()
        {
            if (asd.Engine.Mouse.LeftButton.ButtonState == (asd.MouseButtonState.Push))
            {
                if (ClickSystem.Select() == TextureNum)
                {
                    if (ClickSystem.ClickedNumber == TextureNum)
                        return;
                    //画像クリックで透明化
                    asd.Engine.Sound.Play(Click);
                    Color = new asd.Color(255,255,255,100);
                    ClickSystem.ClickedNumber = TextureNum;
                }
                else if (ClickSystem.Select() == -1 || ClickSystem.Select() == -2)
                {
                    //画像そのまま
                }
                else Color = new asd.Color(255, 255, 255, 255);
            }
        }
    }
}
