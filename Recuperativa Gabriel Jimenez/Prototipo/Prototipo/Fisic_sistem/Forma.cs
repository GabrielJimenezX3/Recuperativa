using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo.Fisic_sistem
{
    public abstract class Forma
    {
        public Vector2 pos;
        public abstract bool colisiona(Forma otra);
    }
}