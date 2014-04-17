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
        private Vector2  defaultPosition;
        bool isopen;
        public SoundEffect soundeffect1 { get; set; }
        public SoundEffect soundeffect2 { get; set; }
        public Color color { get; private set; }
        private int numPressed;
        public Gate(String imagename, Color c, float x, float y, int width, int height)
            : base(imagename, x, y, width, height)
        {
            defaultPosition = this.Position;
            color = c;
            numPressed = 0;
        }
        public override void activate(Sprite collider)
        {
            //oh well...
        }
        public void open()
        {
            numPressed++;
            if (!isopen)
            {
                soundeffect1.Play();
            }
            this.Position  = new Vector2 (GameGlobals.OFFSCREEN_X, GameGlobals.OFFSCREEN_Y);
            isopen = true;
        }
        public void close()
        {
            numPressed--;
            if (numPressed < 0) { numPressed = 0; }
            if (numPressed != 0) { return; }
            if (isopen)
            {
                soundeffect2.Play();
            }
            isopen = false;
            this.Position  = this.defaultPosition;
        }
        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(image, new Rectangle((int)Position.X, (int)Position.Y, Width, Height), this.color);
        }
    }
}
