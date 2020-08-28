using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prototipo.Draw_sistem;

namespace Prototipo.Fisic_sistem
{
    public class Objeto_Fisico
    {
        public Dibujo dibujable;
        public bool isStatic = false;
        public bool isTrigger = false;
        public float rot { get { return dibujable.rot; } set { dibujable.rot = value; } }
        public Vector2 pos { get { return dibujable.pos; } set { dibujable.pos = value; } }
        public Vector2 vel { get; private set; }
        public bool isColliding;
        public delegate void OnCollisionDelegate(Object obj);
        public delegate Object GetObjectDelegate();
        public OnCollisionDelegate OnCollision;
        public GetObjectDelegate GetObject;

        public class FFOffset
        {
            public Forma ff;
            public Vector2 offset;
        }
        public List<FFOffset> formasFisicasOffset = new List<FFOffset>();
        public float masa = 1;
        public Objeto_Fisico(Dibujo dibujable, float masa = 1)
        {
            this.dibujable = dibujable;
            this.masa = masa;
            MotorFisico.agregarObjetoFisico(this);
        }
        public void AddVelocity(Vector2 newVel)
        {
            if (!isColliding)
            {
                vel += newVel;
            }
        }
        public void SetVelocity(Vector2 newVel)
        {
            if (!isColliding)
            {
                vel = newVel;
            }
        }
        public void agregarFFCirculo(float radio, Vector2 offsetPos)
        {
            Forma ff = new FormaCirculo(radio);
            FFOffset ffo = new FFOffset();
            ffo.ff = ff;
            ffo.offset = offsetPos;

            formasFisicasOffset.Add(ffo);
        }
        public void agregarFFRectangulo(float ancho, float alto, Vector2 offsetPos)
        {
            Forma ff = new FormaRectangulo(ancho, alto);
            FFOffset ffo = new FFOffset();
            ffo.ff = ff;
            ffo.offset = offsetPos;

            formasFisicasOffset.Add(ffo);
        }
        public bool Colisiona(Objeto_Fisico otro)
        {
            foreach (FFOffset ffo in formasFisicasOffset)
            {
                //Esta linea actualiza la posición de la forma física
                ffo.ff.pos = pos + Rotate(ffo.offset, rot);

                //Se verifica la colición entre formas físicas de este objeto físico y otro.
                foreach (FFOffset otro_ffo in otro.formasFisicasOffset)
                {
                    otro_ffo.ff.pos = Rotate(otro.pos + otro_ffo.offset, otro.rot);
                    if (otro_ffo.ff.colisiona(ffo.ff))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public void AplicaFuerza(Vector2 fuerza, float deltaTiempoSeg, bool forceVel = false)
        {
            if (forceVel)
            {
                vel = new Vector2(0, 0);
            }
            Console.WriteLine("Aplicación Fuerza: Fuerza");
            Console.WriteLine(fuerza);
            Vector2 acel = fuerza / masa;
            vel += acel * deltaTiempoSeg;
        }
        public void Update(float deltaTiempoSeg)
        {
            pos += vel;
            vel = vel * .9f;
        }
        public void Destruir()
        {
            MotorFisico.removerObjetoFisico(this);
        }
        Vector2 Rotate(Vector2 v, double degrees)
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
