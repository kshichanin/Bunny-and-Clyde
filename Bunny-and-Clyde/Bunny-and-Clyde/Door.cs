using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bunny_and_Clyde
{
    class Door : Item
    {
        public Door(float x, float y, int width, int height) :
            base("door", x, y, width, height)
        {

        }
        public override  void activate (Sprite collider){
    
    }

    }
}
