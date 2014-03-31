using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bunny_and_Clyde
{
    abstract class Item : Sprite 
    {
        public Item(string imageName, float initialX, float initialY, int width, int height)
        : base(imageName , initialX, initialY, width, height){
           
        }
        public abstract  void activate(Sprite collider);
    }
}
