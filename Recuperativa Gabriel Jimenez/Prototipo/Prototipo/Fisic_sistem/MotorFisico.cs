using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo.Fisic_sistem
{
    public static class MotorFisico
    {
        public static List<Objeto_Fisico> objetosFisicos = new List<Objeto_Fisico>();
        public static void agregarObjetoFisico(Objeto_Fisico of)
        {
            objetosFisicos.Add(of);
        }
        public static void removerObjetoFisico(Objeto_Fisico of)
        {
            objetosFisicos.Remove(of);
        }
        public static void Update(GameTime gameTime)
        {
            foreach (Objeto_Fisico of in objetosFisicos)
            {
                of.isColliding = false;
            }
            for (int i = 0; i < objetosFisicos.Count; i++)
            {
                for (int j = i + 1; j < objetosFisicos.Count; j++)
                {
                    Objeto_Fisico objetoA = objetosFisicos[i];
                    Objeto_Fisico objetoB = objetosFisicos[j];
                    if (objetoA.Colisiona(objetoB))
                    {
                        if (objetoA.OnCollision != null && objetoB.GetObject != null)
                        {
                            objetoA.OnCollision(objetoB.GetObject());
                        }
                        if (objetoB.OnCollision != null && objetoA.GetObject != null)
                        {
                            objetoB.OnCollision(objetoA.GetObject());
                        }
                        //verificamos si alguno de los objetos no es trigger para que sólo en ese caso se apliquen fuerzas
                        if (!(objetoA.isTrigger || objetoB.isTrigger))
                        {
                            //Aplicación de fuerzas
                            objetoA.isColliding = objetoB.isColliding = true;
                            Vector2 direccionBA = (objetoA.pos - objetoB.pos);
                            Vector2 VelocityBA = objetoA.vel + objetoB.vel;
                            if (objetoA.isStatic)
                            {
                                objetoB.AplicaFuerza((-direccionBA + -VelocityBA) * 10f, (float)gameTime.ElapsedGameTime.TotalSeconds, true);
                            }
                            else if (!objetoB.isStatic)
                            {
                                objetoA.AplicaFuerza((direccionBA + VelocityBA) * 10f, (float)gameTime.ElapsedGameTime.TotalSeconds);
                            }
                            if (objetoB.isStatic)
                            {
                                objetoA.AplicaFuerza((direccionBA + -VelocityBA) * 10f, (float)gameTime.ElapsedGameTime.TotalSeconds, true);
                            }
                            else if (!objetoA.isStatic)
                            {
                                objetoB.AplicaFuerza((-direccionBA + VelocityBA) * 10f, (float)gameTime.ElapsedGameTime.TotalSeconds);
                            }
                        }
                    }
                }
                objetosFisicos[i].Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            }

        }
    }
}
