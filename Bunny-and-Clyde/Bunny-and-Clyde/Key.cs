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
        GameScreen screen;
        public Key(Color c, GameScreen gs)
        {
            color = c;
            screen = gs;
        }
        public override void activate(Sprite s)
        {

        }
    }
}
