using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prototipo.Object_sistem;
using Microsoft.Xna.Framework;

namespace Prototipo.Objetos
{
    class Planetas : Sistema_Objetos
    {

        public Planetas(string imagen, Vector2 pos, float escala, FF_form forma, bool isStatic = false) : base(imagen, pos, escala, forma, isStatic)
        {
        }
    }
}