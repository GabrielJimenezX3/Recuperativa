using Microsoft.Xna.Framework;
using Prototipo.Object_sistem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Prototipo.Object_sistem.Sistema_Objetos;

namespace Prototipo.Objetos
{
    class Muro : Sistema_Objetos
    {

        public Muro(string imagen, Vector2 pos, float escala, FF_form forma, bool isStatic = false) : base(imagen, pos, escala, forma, isStatic)
        {
        }
    }
}
