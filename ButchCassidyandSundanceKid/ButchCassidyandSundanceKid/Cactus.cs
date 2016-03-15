using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ButchCassidyandSundanceKid
{
    class Cactus
    {
        public Rectangle C_collisionRect;
        private Texture2D C_txr;
        public Vector2 C_pos;
              
        public Cactus(Texture2D txr, int xpos, int ypos)
        {
            C_txr = txr;
            C_collisionRect = new Rectangle(xpos+20, ypos+20, txr.Width-20, txr.Height-20);
            C_pos = new Vector2(xpos, ypos);
            
        }

        public void updateme()
        {
            C_collisionRect.X = (int)C_pos.X;
            C_collisionRect.Y = (int)C_pos.Y;
            C_pos.X -= 4;
        }

      
        public void drawme(SpriteBatch sb)
        {
            sb.Draw(C_txr, C_pos, Color.White);
        }
    }
}
