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

        private Rectangle animBox;
        private float AnimframeTimer;
        private float Animfps;

        // Constructor
        public Player(Texture2D txr, int xpos, int ypos, int fps)
        {
            P_txr = txr;
            P_rect = new Rectangle(xpos, ypos, txr.Width/12, txr.Height/4);
            P_pos = new Vector2(xpos, ypos);

            animBox = new Rectangle(0, 0, P_txr.Width/6, P_txr.Height/2);
            AnimframeTimer = 1;
            Animfps = fps;
        }

        // Movement
        public void updateme(GamePadState pad)
        {
            if (pad.DPad.Left == ButtonState.Pressed)
            {
                P_rect.X -= 8;
            }
            else if(pad.DPad.Right == ButtonState.Pressed)
            {
                P_rect.X += 8;
            }
            else if (pad.DPad.Up == ButtonState.Pressed)
            {
                P_rect.Y -= 8;
            }
            else if (pad.DPad.Down == ButtonState.Pressed)
            {
                P_rect.Y += 8;
            }
            
        }

        public void drawme(SpriteBatch sb, GameTime gt)
        {
            if (AnimframeTimer <= 0) //same animation code as the Boss class
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
