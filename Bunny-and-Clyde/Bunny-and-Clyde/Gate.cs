using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Bunny_and_Clyde
{
    class Gate : Item
    {
        private int fullwidth;

        public SoundEffect soundeffect1 { get; set; }
        public SoundEffect soundeffect2 { get; set; }
        public Color color { get; private set; }
        public Gate(Color c, float x, float y, int width, int height)
            : base("stone_block_4x1", x, y, width, height)
        {
            fullwidth = width;
            color = c;
        }
        public override void activate(Sprite collider)
        {
            //oh well...
        }
        public void open()
        {
            if (Width != 0)
            {
                soundeffect1.Play();
            }
            Width = 0;
            
        }
        public void close()
        {
            if (Width == 0)
            {
                soundeffect2.Play();
            }
            Width = fullwidth;
        }
        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(image, new Rectangle((int)Position.X, (int)Position.Y, Width, Height), this.color);
        }
    }
}
