using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Bunny_and_Clyde
{
    class imageshow : Item
    {
        public imageshow(string name, float initialX, float initialY, int width, int height)
            : base(name, initialX, initialY, width, height)
        {

        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
        }
        public override void activate(Sprite collider)
        {

        }

    }
}


