using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ButchCassidyandSundanceKid
{
    class Background_Ground
    {
        private Rectangle B_rect;
        private Texture2D B_txr;
        private Vector2 B_pos;

        public int paralaxspeed;

        public Background_Ground(Texture2D txr, int xpos, int ypos, int speed)
        {
            B_txr = txr;
            B_rect = new Rectangle(xpos, ypos, B_txr.Width, B_txr.Height);
            B_pos = new Vector2(xpos, ypos);
            paralaxspeed = speed;
        }

        public void updateme()
        {
            
          B_pos.X -= paralaxspeed;

          if (B_pos.X == -804)
              B_pos.X = 0;
            
        }

        public void drawme(SpriteBatch sb)
        {
            sb.Draw(B_txr, B_pos, Color.White);
        }
    }
}
