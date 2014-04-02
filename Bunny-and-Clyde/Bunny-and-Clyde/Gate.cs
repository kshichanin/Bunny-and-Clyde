using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
namespace Bunny_and_Clyde
{
    class Gate : Item
    {
        private int fullwidth;
        public Color color { get; private set; }
        public Gate(Color c, float x, float y, int width, int height)
            : base("switch_block_placeholder.png", x, y, width, height)
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
            Width = 0;
        }
        public void close()
        {
            Width = fullwidth;
        }
    }
}
