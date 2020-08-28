using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo.Fisic_sistem
{
    public class FormaCirculo : Forma
    {
        public float radio;
        public FormaCirculo(float radio)
        {
            this.radio = radio;
        }
        public override bool colisiona(Forma otra)
        {
            try
            {
                FormaCirculo otroCirculo = otra as FormaCirculo;
                if (otroCirculo != null)
                {
                    float distanciaCuadrada = (otroCirculo.pos - this.pos).LengthSquared();
                    float sumaRadios = this.radio + otroCirculo.radio;
                    if (distanciaCuadrada < sumaRadios * sumaRadios)
                    {
                        return true;
                    }
                    return false;
                }
                FormaRectangulo otroRectangulo = otra as FormaRectangulo;
                if (otroRectangulo != null)
                {
                    return otroRectangulo.colisiona(this);
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
