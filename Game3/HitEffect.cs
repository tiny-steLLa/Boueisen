using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class HitEffect : asd.EffectObject2D
    {
        public HitEffect()
        {
            Effect = asd.Engine.Graphics.CreateEffect("hit.efk");
        }
        protected override void OnUpdate()
        {
            if (IsPlaying == false)
                Dispose();
        }
    }
}
