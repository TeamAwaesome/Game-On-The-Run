using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ButchCassidyandSundanceKid
{
    class Shrub
    {
        public Rectangle S_collisionRect;
        private Texture2D S_txr;
        public Vector2 S_pos;
        

       

        public Shrub(Texture2D txr, int xpos, int ypos)
        {
            S_txr = txr;
            S_collisionRect = new Rectangle(xpos+20, ypos+20, txr.Width-20, txr.Height-20);
            S_pos = new Vector2(xpos, ypos);
            
        }

        public void updateme()
        {
            S_collisionRect.X = (int)S_pos.X;
            S_collisionRect.Y = (int)S_pos.Y;
            S_pos.X -= 4;
        }

      
        public void drawme(SpriteBatch sb)
        {
            sb.Draw(S_txr, S_pos, Color.White);
        }
    }
}
