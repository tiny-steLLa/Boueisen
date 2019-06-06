using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class HitEffectEnemy :asd.EffectObject2D
    {
        public HitEffectEnemy()
        {
            Effect = asd.Engine.Graphics.CreateEffect("hit2.efk");
        }
        protected override void OnUpdate()
        {
            if (IsPlaying == false)
                Dispose();
        }
    }
}
