using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prototipo.Object_sistem;

namespace Prototipo.Draw_sistem
{
    public class Escena
    {
        public List<Dibujo> dibujar { get; private set; } = new List<Dibujo>();
        public static Escena INSTANCIA;
        public Escena()
        {
            Sistema_Objetos_Manager.Init();
            INSTANCIA = this;
        }
        public void agregar_dibujo(Dibujo dibujo)
        {
            dibujar.Add(dibujo);
        }
        public void remover_dibujo(Dibujo dibujo)
        {
            dibujar.Remove(dibujo);
        }
        public virtual void Update(GameTime gameTime)
        {
        }
    }
}
