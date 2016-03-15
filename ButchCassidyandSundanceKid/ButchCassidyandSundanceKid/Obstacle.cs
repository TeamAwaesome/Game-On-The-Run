using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ButchCassidyandSundanceKid
{
    class Obstacle
    {
        private Rectangle O_rect;
        private Texture2D O_txr;

        public Rectangle colrect;

        public Obstacle(Texture2D txr, int xpos, int ypos)
        {
            O_txr = txr;
            O_rect = new Rectangle(xpos, ypos, O_txr.Width, O_txr.Height);

            colrect = new Rectangle(xpos, ypos, O_txr.Width, O_txr.Height);
        }

        public void drawme(SpriteBatch sb)
        {
            sb.Draw(O_txr, O_rect, Color.White);
        }
    }
}
