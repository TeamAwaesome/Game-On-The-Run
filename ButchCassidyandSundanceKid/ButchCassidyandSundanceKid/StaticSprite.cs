using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ButchCassidyandSundanceKid
{
    class StaticSprite
    {
        private Rectangle S_rect;
        private Texture2D S_txr;

        public StaticSprite(Texture2D txr, int xpos, int ypos)
        {
            S_txr = txr;
            S_rect = new Rectangle(xpos, ypos, 2000, 1000);
        }

        public void drawme(SpriteBatch sb)
        {
            sb.Draw(S_txr, S_rect, Color.White);
        }
    }
}
