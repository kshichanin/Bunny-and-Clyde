using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
namespace Bunny_and_Clyde
{
    class Goal : Item
    {
        private Level level;
        private Color color;
        private bool bunnyTouching, clydeTouching;
        public Goal(Level l, Color c, float x, float y, int width, int height) :
            base("door", x, y, width, height)
        {
            this.bunnyTouching = false;
            this.clydeTouching = false;
            this.level = l;
            this.color = c;
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
            if (bunnyTouching && clydeTouching && level.inventory.containsKey(color))
            {
                //we won
                level.isComplete = true;
                Console.Out.WriteLine("we won");
            }
        }
        public override void Update(GameTime gt)
        {
            base.Update(gt);
            bunnyTouching = false;
            clydeTouching = false;
        }
    }
}
