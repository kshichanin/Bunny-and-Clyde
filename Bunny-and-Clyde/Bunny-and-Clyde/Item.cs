using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bunny_and_Clyde
{
    abstract class Item : Sprite 
    {
        public abstract  void activate(Sprite collider);
    }
}
