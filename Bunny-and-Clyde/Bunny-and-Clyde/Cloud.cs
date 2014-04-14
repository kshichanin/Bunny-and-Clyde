using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bunny_and_Clyde
{
    class Cloud : Item
    {
        public Cloud(string imageName, int x, int y, int width, int height) : base(imageName, x, y, width, height) { }

        public override void activate(Sprite collider) { }
    }
}
