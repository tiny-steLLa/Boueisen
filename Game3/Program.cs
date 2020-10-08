using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace Game3
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Status.Load();

            asd.Engine.Initialize("boueisen", 800, 800, new asd.EngineOption());

            asd.Engine.File.AddRootDirectory("resource/");

            var scene = new TitleScene();

            asd.Engine.ChangeSceneWithTransition(scene, new asd.TransitionFade(0, 1));

            while (asd.Engine.DoEvents())
            {
                if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Escape) == asd.KeyState.Push)
                {
                    break;
                }
                asd.Engine.Update();
            }
            asd.Engine.Terminate();
        }
    }
}
