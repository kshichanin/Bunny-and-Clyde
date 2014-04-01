using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
namespace Bunny_and_Clyde
{
    class Water : Item
    {
        public Water(float x, float y, int width, int height) :
            base("blank", x, y, width, height)
        {

        }
        public override  void activate(Sprite collider)
        {
           
        }
    }

}
