using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo.Draw_sistem
{
    public class Dibujo
    {
        private Texture2D texture;
        public Vector2 pos;
        private Vector2 centro;
        public float escala;
        public int ancho { get { return (int)(this.texture.Width * this.escala);  } set { escala = this.texture.Width / value; } }
        public int alto { get { return (int)(this.texture.Height * this.escala); } set { escala = this.texture.Height / value; } }
        public float rot;

        public Dibujo(string textureNombre, Vector2 pos, float escala)
        {
            this.pos = pos;
            this.escala = escala;
            this.texture = Game1.INSTANCE.Content.Load<Texture2D>(textureNombre);
            Escena.INSTANCIA.agregar_dibujo(this);
            this.centro = new Vector2(this.texture.Width / 2, this.texture.Height / 2);
        }
        public void Destruir()
        {
            Escena.INSTANCIA.remover_dibujo(this);
        }
        public void Draw(SpriteBatch SB, Vector2 camaraPos, float camaraRot, float camaraScale)
        {
            SB.Draw(texture, Rotate(((pos - camaraPos) * camaraScale), camaraRot), null, Color.White, camaraRot + rot, centro, camaraScale * escala, SpriteEffects.None, 1);
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
