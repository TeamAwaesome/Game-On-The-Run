using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ButchCassidyandSundanceKid
{
    class Rock
    {
        public Rectangle R_collisionRect;
        private Texture2D R_txr;
        public Vector2 R_pos;



        public Rock(Texture2D txr, int xpos, int ypos)
        {
            R_txr = txr;
            R_collisionRect = new Rectangle(xpos+20, ypos+20, txr.Width-20, txr.Height-20);
            R_pos = new Vector2(xpos, ypos);

        }

        public void updateme()
        {
            R_collisionRect.X = (int)R_pos.X;
            R_collisionRect.Y = (int)R_pos.Y;
            R_pos.X -= 4;
        }


        public void drawme(SpriteBatch sb)
        {
            sb.Draw(R_txr, R_pos, Color.White);
        }
    }
}
