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
        public Color color { get; private set; }
        Level level;
        public Key(Color c, Level l, float x, float y, int width, int height) :
            base("key", x, y, width, height)
        {
            color = c;
            level = l;
        }
        public override void activate(Sprite s)
        {
            level.items.Remove(this);
            level.inventory.addItem(this);
        }
    }
}
