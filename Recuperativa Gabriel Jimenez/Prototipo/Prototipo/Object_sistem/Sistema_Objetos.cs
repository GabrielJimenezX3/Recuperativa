using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prototipo.Draw_sistem;
using Prototipo.Fisic_sistem;

namespace Prototipo.Object_sistem
{
    public class Sistema_Objetos
    {
        public Objeto_Fisico objetoFisico;
        Dibujo dibujable;
        public enum FF_form { Circulo, Rectangulo };
        public float rot { get { return dibujable.rot; } set { dibujable.rot = value; } }
        public Sistema_Objetos(string imagen, Vector2 pos, float escala, FF_form forma, bool isStatic = false)
        {
            dibujable = new Dibujo(imagen, pos, escala);
            objetoFisico = new Objeto_Fisico(dibujable);
            if (forma == FF_form.Circulo)
            {
                objetoFisico.agregarFFCirculo(dibujable.ancho / 2f, new Vector2(0, 0));
            }
            else
            {
                objetoFisico.agregarFFRectangulo(dibujable.ancho, dibujable.alto, new Vector2(0, 0));
            }
            objetoFisico.isStatic = isStatic;
            objetoFisico.OnCollision = OnCollision;
            objetoFisico.GetObject = GetObject;


            Sistema_Objetos_Manager.suscribirObjeto(this);
        }
        private void OnCollision(Object other)
        {
            Sistema_Objetos otherUTG = other as Sistema_Objetos;
            OnCollision(otherUTG);
        }
        public Object GetObject()
        {
            return this as Object;
        }

        public virtual void OnCollision(Sistema_Objetos other)
        {

        }
        public void Destroy()
        {
            Sistema_Objetos_Manager.DestruirObjeto(this);
        }
        public void OnDestroy()
        {
            dibujable.Destruir();
            objetoFisico.Destruir();
        }
        public virtual void Update(GameTime gameTime)
        {

        }
        public Vector2 Rotate(Vector2 v, double degrees)
        {
            float sin = (float)Math.Sin(degrees);
            float cos = (float)Math.Cos(degrees);

            float tx = v.X;
            float ty = v.Y;
            v.X = (cos * tx) - (sin * ty);
            v.Y = (sin * tx) + (cos * ty);
            return v;
        }

    }
}
