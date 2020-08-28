using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Prototipo.Object_sistem;
using Prototipo.Scene;
using Prototipo.Fisic_sistem;
using Prototipo.Draw_sistem;
using Prototipo.Audio_sistem;
using Microsoft.Xna.Framework.Content;

namespace Prototipo.Objetos
{
    public class Jugador : Sistema_Objetos
    {
        Sistema_Objetos playerUTG;
        float vel;
        float velox;
        float veloy;
        bool dead = false;
        ContentManager content;
        int vida = 100;
        bool life = true;
        bool pause = false;
        GameOver over = new GameOver();
        Vector2 _position = new Vector2(8000, 6000);
        float timerShoot;
        Objeto_Fisico Objeto_Fisico;


        Vector2 rotacion;


        //_position 

        /* public Jugador(string imagen, Vector2 pos, float escala, FF_form forma, bool isStatic = false) : base(imagen, pos, escala, forma, isStatic)
         {

         }*/
        public Jugador() : base("Plankton", new Vector2(8000, 6000), 3f, Sistema_Objetos.FF_form.Rectangulo)
        {
            _position = new Vector2(8000, 6000);
        }



        public override void Update(GameTime gameTime)
        {


            //movimiento horizontal
            objetoFisico.AddVelocity(new Vector2(velox, veloy));

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                velox -= (float)gameTime.ElapsedGameTime.TotalSeconds * 1.4f;



            }


            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                velox += (float)gameTime.ElapsedGameTime.TotalSeconds * 1.4f;

            }
            else
            {
                velox = 0;
            }



        }


        public override void OnCollision(Sistema_Objetos other)
        {



            Roca coli = other as Roca;
            if (coli != null)
            {


                Destroy();
                AudioManager.Play(AudioManager.Sounds.Dead);


                //over.LoadContent(content);

                //over.Draw();

            }
           /* Muro muri = other as Muro;
            objetoFisico.AddVelocity(new Vector2(velox, veloy));
            if (coli != null && velox<0)
            {
                velox -= 4;
                veloy += 100;
            }*/
        }
    }
}
