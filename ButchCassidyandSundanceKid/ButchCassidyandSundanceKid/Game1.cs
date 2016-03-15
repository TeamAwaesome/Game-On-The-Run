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

        Player horse;


        Background_Ground Wyoming;
        Background_Ground Wyomingback;
        Background_Ground Wyomingsky;

        Background_Ground Utah;
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

        List<Rock> rock;
        List<Cactus> cactus;
        List<Shrub> shrub;

        int randomRock;
        int rockTimer;
        int randomCactus;
        int cactusTimer;
        int randomShrub;
        int shrubTimer;

        public static readonly Random RNG = new Random();

        GamePadState Padstate;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;


            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
        }

        protected override void Initialize()
        {

            state = Gamestate.Level2;
            rock = new List<Rock>();
            cactus = new List<Cactus>();
            shrub = new List<Shrub>();

            rockTimer = 50;
            randomRock = 200;
            cactusTimer = 200;
            randomCactus = 400;
            shrubTimer = 150;
            randomShrub = 300;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            horse = new Player(Content.Load<Texture2D>("Butch-on-Horse(OriginalSize)"),500,500, 24);

            #region Backgrounds
            Wyoming = new Background_Ground(Content.Load<Texture2D>("Wyomingground"), 0, 300, 4);
            Wyomingback = new Background_Ground(Content.Load<Texture2D>("Wyomingback"), 0, 50, 2);
            Wyomingsky = new Background_Ground(Content.Load<Texture2D>("Wyomingsky"), 0, -100, 1);

            Utah = new Background_Ground(Content.Load<Texture2D>("Utahground"), 0, 300, 4);
            Utahsky = new Background_Ground(Content.Load<Texture2D>("Utahsky"), 0, -100, 1);

            Nevada = new Background_Ground(Content.Load<Texture2D>("Nevadaground"), 0, 300, 4);
            Nevadaback = new Background_Ground(Content.Load<Texture2D>("Nevadaback"), 0, 100, 2);
            Nevadasky = new Background_Ground(Content.Load<Texture2D>("Nevadasky"), 0, -100, 0);

            Newmexico = new Background_Ground(Content.Load<Texture2D>("Newmexicoback"), 0, 000, 2);
            Newmexicoback = new Background_Ground(Content.Load<Texture2D>("Newmexicoground"), 0, 300, 4);
            Newmexicosky = new Background_Ground(Content.Load<Texture2D>("Newmexicosky"), 0, 0, 0);

            Bolivia = new Background_Ground(Content.Load<Texture2D>("Bolivia"), 0, 300, 4);
            Boliviaback = new Background_Ground(Content.Load<Texture2D>("Boliviaback"), 0, -20, 2);
            Boliviasky = new Background_Ground(Content.Load<Texture2D>("Boliviasky"), 0, -100, 0);
            Boliviaclouds = new Background_Ground(Content.Load<Texture2D>("Boliviaclouds"), 0, 0, 1);
            #endregion
            for (int i = 0; i < 2; i++)
                Content.Load<Texture2D>("rockfixed");
            for (int i = 0; i < 2; i++)
                Content.Load<Texture2D>("Shrubfixed");
            for (int i = 0; i < 2; i++)
                Content.Load<Texture2D>("Cactusfixed");
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

            horse.updateme(Padstate);
            #region obstacles

            for (int i = 0; i < rock.Count; i++)
                rock[i].updateme();
            rockTimer--;
            if (rockTimer <= 0)
            {
                randomRock = RNG.Next(300, 530);
                rockTimer = RNG.Next(300, 800);
                rock.Add(new Rock(Content.Load<Texture2D>("rockfixed"), 850, randomRock));          
            }

            for (int i = 0; i < shrub.Count; i++)
                shrub[i].updateme();
            shrubTimer--;
            if (shrubTimer <= 0)
            {
                randomShrub = RNG.Next(300, 530);
                shrubTimer = RNG.Next(300, 800);
                shrub.Add(new Shrub(Content.Load<Texture2D>("Shrubfixed"), 850, randomShrub));
            }

            for (int i = 0; i < cactus.Count; i++)
                cactus[i].updateme();
            cactusTimer--;
            if (cactusTimer <= 0)
            {
                randomCactus = RNG.Next(300, 530);
                cactusTimer = RNG.Next(300, 800);
                cactus.Add(new Cactus(Content.Load<Texture2D>("Cactusfixed"), 850, randomCactus));
            }

            for (int i = 0; i < rock.Count; i++)
            {
                if (rock[i].R_pos.X <= -30)
                {
                    rock.RemoveAt(i);
                }
            } 
            for (int i = 0; i < shrub.Count; i++)
            {
                if (shrub[i].S_pos.X <= -30)
                {
                    shrub.RemoveAt(i);
                }
            }
            for (int i = 0; i < cactus.Count; i++)
            {
                if (cactus[i].C_pos.X <= -30)
                {
                    cactus.RemoveAt(i);
                }
            }



            #endregion
            #region Background
            Wyoming.updateme();
            Wyomingback.updateme();
            Wyomingsky.updateme();

            Utah.updateme();
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
            #endregion
            for(int i = 0; i<rock.Count;i++)
            {
                if (horse.P_collisionRect.Intersects(rock[i].R_collisionRect))
                {
                    rock.RemoveAt(i);
                }
            }
            for (int i = 0; i < cactus.Count; i++)
            {
                if (horse.P_collisionRect.Intersects(cactus[i].C_collisionRect))
                {
                    cactus.RemoveAt(i);
                }
            }
            for (int i = 0; i < shrub.Count; i++)
            {
                if (horse.P_collisionRect.Intersects(shrub[i].S_collisionRect))
                {
                    shrub.RemoveAt(i);
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

           #region Rossdraw
            if (state == Gamestate.Main)
            {
                
            }
            else if (state == Gamestate.Level1)
            {
                Wyomingsky.drawme(spriteBatch);
                Wyomingback.drawme(spriteBatch);
                Wyoming.drawme(spriteBatch);
                for (int i = 0; i < rock.Count; i++)
                    rock[i].drawme(spriteBatch);
                for (int i = 0; i < shrub.Count; i++)
                    shrub[i].drawme(spriteBatch);
                for (int i = 0; i < cactus.Count; i++)
                    cactus[i].drawme(spriteBatch);
            }
            else if (state == Gamestate.Level2)
            {
                Utahsky.drawme(spriteBatch);
                Utah.drawme(spriteBatch);
                for (int i = 0; i < rock.Count; i++)
                    rock[i].drawme(spriteBatch);
                for (int i = 0; i < shrub.Count; i++)
                    shrub[i].drawme(spriteBatch);
                for (int i = 0; i < cactus.Count; i++)
                    cactus[i].drawme(spriteBatch);
            }
            else if (state == Gamestate.Level3)
            {
                Nevadasky.drawme(spriteBatch);
                Nevadaback.drawme(spriteBatch);
                Nevada.drawme(spriteBatch);
                for (int i = 0; i < rock.Count; i++)
                    rock[i].drawme(spriteBatch);
                for (int i = 0; i < shrub.Count; i++)
                    shrub[i].drawme(spriteBatch);
                for (int i = 0; i < cactus.Count; i++)
                    cactus[i].drawme(spriteBatch);
            }
            else if (state == Gamestate.Level4)
            {
                Newmexicosky.drawme(spriteBatch);
                Newmexicoback.drawme(spriteBatch);
                Newmexico.drawme(spriteBatch);
                for (int i = 0; i < rock.Count; i++)
                    rock[i].drawme(spriteBatch);
                for (int i = 0; i < shrub.Count; i++)
                    shrub[i].drawme(spriteBatch);
                for (int i = 0; i < cactus.Count; i++)
                    cactus[i].drawme(spriteBatch);
            }
            else if (state == Gamestate.Level5)
            {
                Boliviasky.drawme(spriteBatch);
                Boliviaclouds.drawme(spriteBatch);
                Boliviaback.drawme(spriteBatch);
                Bolivia.drawme(spriteBatch);
                for (int i = 0; i < rock.Count; i++)
                    rock[i].drawme(spriteBatch);
                for (int i = 0; i < shrub.Count; i++)
                    shrub[i].drawme(spriteBatch);
                for (int i = 0; i < cactus.Count; i++)
                    cactus[i].drawme(spriteBatch);
            }
            else if (state == Gamestate.Level6)
            {
                Utahsky.drawme(spriteBatch);
                Utah.drawme(spriteBatch);
                for (int i = 0; i < rock.Count; i++)
                    rock[i].drawme(spriteBatch);
                for (int i = 0; i < shrub.Count; i++)
                    shrub[i].drawme(spriteBatch);
                for (int i = 0; i < cactus.Count; i++)
                    cactus[i].drawme(spriteBatch);
            }
            horse.drawme(spriteBatch, gameTime);
            #endregion

            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
