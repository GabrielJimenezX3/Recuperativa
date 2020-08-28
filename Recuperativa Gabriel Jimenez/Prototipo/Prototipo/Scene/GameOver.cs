using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Prototipo.Audio_sistem;
using Prototipo.Draw_sistem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo.Scene
{
    class GameOver
    {
        Texture2D end;
        Rectangle lose;
        GraphicsDevice graphics;
        SpriteBatch sb;
       

        Texture2D fondo;
        Rectangle bucket;

        public void LoadContent(ContentManager content)
        {
            end = content.Load<Texture2D>("GameOver");
            lose = new Rectangle(0, 0, 1820, 980);

            fondo = content.Load<Texture2D>("ChumBucket");
            bucket = new Rectangle(0, 0, 1820, 980);
            sb = new SpriteBatch(graphics);
        }

        public void Upload()
        {

        }

        public void Draw()
        {
            sb.Begin();
            sb.Draw(end, lose, Color.White);

            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                sb.Draw(fondo, bucket, Color.White);
               
                AudioManager.Play(AudioManager.Sounds.Theme);
                Camara.ActiveCamera.Dibujar(sb);
                
            }
            sb.End();
        }

    }
}
