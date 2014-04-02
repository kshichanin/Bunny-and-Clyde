using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
namespace Bunny_and_Clyde
{
    class Door : Item
    {
        private Level level;
        private Key key;
        private bool bunnyTouching, clydeTouching;
        public Door(Level l, Key k, float x, float y, int width, int height) :
            base("door", x, y, width, height)
        {
            this.bunnyTouching = false;
            this.clydeTouching = false;
            this.level = l;
            this.key = k;
        }
        public override  void activate (Sprite collider){
            if (collider.GetType() == typeof(Clyde))
            {
                clydeTouching = true;
            }
            else if (collider.GetType() == typeof(Bunny))
            {
                bunnyTouching = true;
            }
            if (bunnyTouching && clydeTouching && level.inventory.items.Contains(key))
            {
                //we won
                Console.Out.WriteLine("we won");
            }
        }
        public void Update(GameTime gt)
        {
            base.Update(gt);
            bunnyTouching = false;
            clydeTouching = false;
        }
    }
}
