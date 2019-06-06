using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    public class CollidableObject : asd.TextureObject2D
    {
        public float Radius = 0.0f;

        public bool IsCollide(CollidableObject o)
        {
            return (o.Position - Position).Length < Radius + o.Radius -5;
        }
        public virtual void OnCollide(CollidableObject obj)
        {

        }
    }
}
