using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Prototipo.Objetos;
using Prototipo.Draw_sistem;
using Prototipo.Fisic_sistem;
using Prototipo.Object_sistem;
using Prototipo.Audio_sistem;

namespace Prototipo
{
    

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Escena escena;



        
        bool Play = false;
        bool pause = false;
        bool vivo = true;

        Texture2D fondo;
        Rectangle bucket;

        Texture2D logo;
        Rectangle Name;

        Texture2D title;
        Rectangle rec;

        SpriteFont s_texto;
        SpriteFont Font;

        

        Vector2 posiciontexto = new Vector2(100, 100);

        public static Game1 INSTANCE;

        public Game1()
        {
            INSTANCE = this;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            graphics.PreferredBackBufferWidth = 1820;
            graphics.PreferredBackBufferHeight = 980;
        }

        protected override void Initialize()
        {

            base.Initialize();
        }

       
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            new Juego();

            fondo = Content.Load<Texture2D>("ChumBucket");
            bucket = new Rectangle(0, 0, 1820, 980);

            logo = Content.Load<Texture2D>("PlankTitle");
            Name = new Rectangle(500, 150, 900, 400);

            s_texto = Content.Load<SpriteFont>("GG");
            Font = Content.Load<SpriteFont>("Font");

            title = Content.Load<Texture2D>("Pausa");
            rec = new Rectangle(0, 0, 1820, 980);

            


        }


        protected override void UnloadContent()
        {
        }

        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Console.WriteLine(gameTime.ElapsedGameTime.TotalSeconds);

            Escena.INSTANCIA?.Update(gameTime);
            MotorFisico.Update(gameTime);
            Sistema_Objetos_Manager.Update(gameTime);


            MouseState mouse = Mouse.GetState();

            if (!pause)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.P))
                {
                    pause = true;
                }


            }
            else if (pause)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    pause = false;
                }

            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Cyan);

            
            spriteBatch.Begin();

            spriteBatch.Draw(logo, Name, Color.White);

          
            spriteBatch.DrawString(s_texto, "Presione Enter para comenzar el juego", new Vector2(550, 550), Color.Black);
            spriteBatch.DrawString(Font, "Motor creado por Sven Von Brand", new Vector2(200, 650), Color.Black);
            spriteBatch.DrawString(Font, "muevete con A y D si tocas una roca, se acabo. puedes pausar el juego con P y salir con esc", new Vector2(200, 700), Color.Black);



            if (Play == false)
            {
                AudioManager.Play(AudioManager.Sounds.Title);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Enter) && Play==false)
            {
                Play = true;
            }

                if (Play == true)
            {
                if (!pause)
                {
                    spriteBatch.Draw(fondo, bucket, Color.White);
                    
                    // AudioManager.Stop(AudioManager.Sounds.Title);
                    AudioManager.Play(AudioManager.Sounds.Theme);
                    Camara.ActiveCamera.Dibujar(spriteBatch);

                }
                else
                {
                    spriteBatch.Draw(title, rec, Color.White);
                }

                

            }



            spriteBatch.End();
    

            base.Draw(gameTime);
        }
    }
}
