using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace Bunny_and_Clyde
{
    class Key : Item 
    {
        Color color;

        public Key(Color c, float x, float y, int width, int height) :
            base("key", x, y, width, height)
        {
            color = c;

        }
        public override void activate(Sprite s)
        {

        }
    }
}
