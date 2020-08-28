using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Prototipo.Object_sistem;
using Prototipo.Draw_sistem;
using Prototipo.Fisic_sistem;

namespace Prototipo.Objetos
{
    class Roca : Sistema_Objetos
    {
        int vida_torreta =100 ;
        Random randomizer= new Random();
        Objeto_Fisico Objeto_Fisico;
        
        float velox, veloy;
        string imagen= "Rock";
        

        public Roca(string imagen, Vector2 pos, float escala, FF_form forma, bool isStatic = true) : base(imagen, pos, escala, forma, isStatic)
        {
            this.imagen=imagen;

        }

        public override void Update(GameTime gameTime)
        {
            objetoFisico.AddVelocity(new Vector2(velox, veloy));
            int ra = randomizer.Next(-5, 5);
            velox += (float)gameTime.ElapsedGameTime.TotalSeconds * ra * 1f;
            veloy += (float)gameTime.ElapsedGameTime.TotalSeconds * ra * 1f;
           /* if (ra == 0)
            {
                velox -= (float)gameTime.ElapsedGameTime.TotalSeconds * 1f;
                veloy -= (float)gameTime.ElapsedGameTime.TotalSeconds * 1f;

            }
            if (ra == 1)
            {
                velox += (float)gameTime.ElapsedGameTime.TotalSeconds * 1f;
                veloy -= (float)gameTime.ElapsedGameTime.TotalSeconds * 1f;

            }
            if (ra == 2)
            {
                velox -= (float)gameTime.ElapsedGameTime.TotalSeconds * 1f;
                veloy += (float)gameTime.ElapsedGameTime.TotalSeconds * 1f;

            }
            if (ra == 3)
            {
                velox += (float)gameTime.ElapsedGameTime.TotalSeconds * 1f;
                veloy += (float)gameTime.ElapsedGameTime.TotalSeconds * 1f;

            }*/

        }
        

        public override void OnCollision(Sistema_Objetos other)
        {
            Muro muri = other as Muro;
            velox = velox * -1;
            veloy = veloy * -1;

        }


     
        }
}
