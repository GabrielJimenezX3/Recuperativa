using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Prototipo.Object_sistem;
using Prototipo.Draw_sistem;

namespace Prototipo.Objetos
{
    class Tanque : Sistema_Objetos
    {
        public Tanque(string imagen, Vector2 pos, float escala, FF_form forma, bool isStatic = true) : base(imagen, pos, escala, forma, isStatic)
        {
        }


        public override void OnCollision(Sistema_Objetos other)
        {
            Rayo disparo = other as Rayo;
            if (disparo != null)
            {
                disparo.Destroy();
            }
        }
    }
}
