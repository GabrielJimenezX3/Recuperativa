using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prototipo.Audio_sistem;
using Prototipo.Draw_sistem;
using Prototipo.Fisic_sistem;
using Prototipo.Object_sistem;
using Microsoft.Xna.Framework.Graphics;

namespace Prototipo.Objetos
{
    public class Juego : Escena
    {

        Sistema_Objetos playerUTG;
        Camara camara;
        SpriteBatch spriteBatch;
       

        Camara Menu;
       

        Camara Creditros;
        bool click = false;
        bool TabPressed;
        
        public Juego()
        {

            Sistema_Objetos Plankton = new Jugador();


           new Roca("Rock", new Vector2(5000, 5500), 2.2f, Sistema_Objetos.FF_form.Circulo, false);

        


           new Roca("Rock", new Vector2(2300, 2500), 2.2f, Sistema_Objetos.FF_form.Circulo, false);


            for (int i = 0; i <= 45; i++)
            {
                new Muro("Muro2", new Vector2(0, i * 2.2f * 200), 2, Sistema_Objetos.FF_form.Rectangulo, true);
            }

            for (int i = 0; i <= 45; i++)
            {
                new Muro("Muro2", new Vector2(14000, i * 2.2f * 200), 2, Sistema_Objetos.FF_form.Rectangulo, true);
            }
            for (int i = 0; i <= 50; i++)
            {
                new Muro("Muro", new Vector2(i * 2.2f * 70, -800), 2, Sistema_Objetos.FF_form.Rectangulo, true);
            }
            for (int i = 0; i <= 50; i++)
            {
                new Muro("Muro", new Vector2(i * 2.2f * 70, 30000), 2, Sistema_Objetos.FF_form.Rectangulo, true);
            }


            camara = new Camara(new Vector2(0, 0), 0.13f, 0);



            // camara.centro = Batwing.objetoFisico.dibujable;

            

        }

         
        public override void Update(GameTime gameTime)
        {
            
       


                base.Update(gameTime);
                
            }
    }
}