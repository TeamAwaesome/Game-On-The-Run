using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace ButchCassidyandSundanceKid
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //comment
        enum Gamestate
        {
            Title,
            Main,
            Controls,
            Upgrade,
            Level1,
            Level2,
            Level3,
            Level4,
            Level5,
            Level6,
            Gameover
        }

        Gamestate state;

        Player Horse;


        Background_Ground Wyoming;
        Background_Ground Wyomingback;
        Background_Ground Wyomingsky;

        Background_Ground Utah;
        Background_Ground Utahback;
        Background_Ground Utahsky;

        Background_Ground Nevada;
        Background_Ground Nevadaback;
        Background_Ground Nevadasky;

        Background_Ground Newmexico;
        Background_Ground Newmexicoback;
        Background_Ground Newmexicosky;

        Background_Ground Bolivia;
        Background_Ground Boliviaback;
        Background_Ground Boliviasky;
        Background_Ground Boliviaclouds;

        Background_Ground Argentina;
        Background_Ground Argentinaback;
        Background_Ground Argentinasky;

        GamePadState Padstate;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
        }

        protected override void Initialize()
        {

            state = Gamestate.Level6;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Horse = new Player(Content.Load<Texture2D>("Butch-on-Horse(OriginalSize)"),500,500, 24);

            #region Backgrounds
            Wyoming = new Background_Ground(Content.Load<Texture2D>("Wyomingground"), 0, 300, 4);
            Wyomingback = new Background_Ground(Content.Load<Texture2D>("Wyomingback"), 0, 50, 2);
            Wyomingsky = new Background_Ground(Content.Load<Texture2D>("Wyomingsky"), 0, -100, 1);

            Utah = new Background_Ground(Content.Load<Texture2D>("Utahground"), 0, 300, 4);
            Utahback = new Background_Ground(Content.Load<Texture2D>("Utahback"), 0, 50, 2);
            Utahsky = new Background_Ground(Content.Load<Texture2D>("Utahsky"), 0, -100, 1);

            Nevada = new Background_Ground(Content.Load<Texture2D>("Nevadaground"), 0, 300, 4);
            Nevadaback = new Background_Ground(Content.Load<Texture2D>("Nevadaback"), 0, 100, 2);
            Nevadasky = new Background_Ground(Content.Load<Texture2D>("Nevadasky"), 0, -100, 0);

            Newmexico = new Background_Ground(Content.Load<Texture2D>("Newmexicoground"), 0, 300, 4);
            Newmexicoback = new Background_Ground(Content.Load<Texture2D>("Newmexicoback"), 0, 0, 2);
            Newmexicosky = new Background_Ground(Content.Load<Texture2D>("Newmexicosky"), 0, -100, 0);

            Bolivia = new Background_Ground(Content.Load<Texture2D>("Bolivia"), 0, 300, 4);
            Boliviaback = new Background_Ground(Content.Load<Texture2D>("Boliviaback"), 0, -20, 2);
            Boliviasky = new Background_Ground(Content.Load<Texture2D>("Boliviasky"), 0, -100, 0);
            Boliviaclouds = new Background_Ground(Content.Load<Texture2D>("Boliviaclouds"), 0, 0, 1);

            Argentina = new Background_Ground(Content.Load<Texture2D>("Argentinaground"), 0, 300, 4);
            Argentinaback = new Background_Ground(Content.Load<Texture2D>("Argentinaback"), 0, 50, 2);
            Argentinasky = new Background_Ground(Content.Load<Texture2D>("Argentinasky"), 0, -100, 0);
            #endregion
        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            Padstate = GamePad.GetState(PlayerIndex.One);

            Horse.updateme(Padstate);

            #region Background
            Wyoming.updateme();
            Wyomingback.updateme();
            Wyomingsky.updateme();

            Utah.updateme();
            Utahback.updateme();
            Utahsky.updateme();

            Nevada.updateme();
            Nevadaback.updateme();
            Nevadasky.updateme();

            Newmexico.updateme();
            Newmexicoback.updateme();
            Newmexicosky.updateme();

            Bolivia.updateme();
            Boliviaback.updateme();
            Boliviasky.updateme();
            Boliviaclouds.updateme();

            Argentina.updateme();
            Argentinaback.updateme();
            Argentinasky.updateme();
            #endregion

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            if (state == Gamestate.Main)
            {
                
            }
            else if (state == Gamestate.Level1)
            {
                Wyomingsky.drawme(spriteBatch);
                Wyomingback.drawme(spriteBatch);
                Wyoming.drawme(spriteBatch);
            }
            else if (state == Gamestate.Level2)
            {
                Utahsky.drawme(spriteBatch);
                Utahback.drawme(spriteBatch);
                Utah.drawme(spriteBatch);
            }
            else if (state == Gamestate.Level3)
            {
                Nevadasky.drawme(spriteBatch);
                Nevadaback.drawme(spriteBatch);
                Nevada.drawme(spriteBatch);
            }
            else if (state == Gamestate.Level4)
            {
                Newmexicosky.drawme(spriteBatch);
                Newmexicoback.drawme(spriteBatch);
                Newmexico.drawme(spriteBatch);
            }
            else if (state == Gamestate.Level5)
            {
                Boliviasky.drawme(spriteBatch);
                Boliviaclouds.drawme(spriteBatch);
                Boliviaback.drawme(spriteBatch);
                Bolivia.drawme(spriteBatch);
            }
            else if (state == Gamestate.Level6)
            {
                Argentinasky.drawme(spriteBatch);
                Argentinaback.drawme(spriteBatch);
                Argentina.drawme(spriteBatch);
            }
            Horse.drawme(spriteBatch, gameTime);
            
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
