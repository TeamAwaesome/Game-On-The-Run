using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ButchCassidyandSundanceKid
{
    class Player
    {
        public Rectangle P_rect;
        private Texture2D P_txr;
        private Vector2 P_pos;
        public Rectangle P_collisionRect;

        private Rectangle animBox;
        private float AnimframeTimer;
        private float Animfps;

        // Constructor
        public Player(Texture2D txr, int xpos, int ypos, int fps)
        {
            P_txr = txr;
            P_rect = new Rectangle(xpos, ypos, txr.Width/12, txr.Height/4);
            P_pos = new Vector2(xpos, ypos);
            P_collisionRect = new Rectangle(xpos+30, ypos+30, (txr.Width / 12)-30, (txr.Height / 4)-30);

            animBox = new Rectangle(0, 0, P_txr.Width/6, P_txr.Height/2);
            AnimframeTimer = 1;
            Animfps = fps;
        }

       
        public void updateme(GamePadState pad)
        {
            P_collisionRect.X = (int)P_rect.X;
            P_collisionRect.Y = (int)P_rect.Y;
            #region movement & screen edge
            if ((pad.DPad.Left == ButtonState.Pressed) || (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.A)))
            {
                P_rect.X -= 4;
            }
            if((pad.DPad.Right == ButtonState.Pressed) || (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.D)))
            {
                P_rect.X += 4;
            }
            if ((pad.DPad.Up == ButtonState.Pressed) || (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.W)))
            {
                P_rect.Y -= 4;
            }
            if ((pad.DPad.Down == ButtonState.Pressed) || (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.S)))
            { 
                P_rect.Y += 4;
            }

            if (P_rect.X <= -10)
                P_rect.X = -10;
            if (P_rect.X >= 680)
                P_rect.X = 680;
            if (P_rect.Y >= 530)
                P_rect.Y = 530;
            if (P_rect.Y <= 250)
                P_rect.Y = 250;

#endregion
            
        }

        public void drawme(SpriteBatch sb, GameTime gt)
        {
            if (AnimframeTimer <= 0) 
            {
                animBox.X = (animBox.X + animBox.Width);
                if ((animBox.X >= P_txr.Width) && (animBox.Y == 0))
                {
                    animBox.X = 0;
                    animBox.Y = 162;
                }

                if ((animBox.X >= P_txr.Width) && (animBox.Y == 162))
                {
                    animBox.X = 0;
                    animBox.Y = 0;
                }

                AnimframeTimer = 1;
            }
            else
            {
                AnimframeTimer -= (float)gt.ElapsedGameTime.TotalSeconds * Animfps;
            }

            sb.Draw(P_txr, P_rect, animBox, Color.White);
        }
    }
}
