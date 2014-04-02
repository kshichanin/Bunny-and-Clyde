using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Bunny_and_Clyde
{
    class Door : Item
    {
		private Level level;
        private Color color;
        private bool opened;
        public Door(Level l, Color c, float x, float y, int width, int height) :
            base("door", x, y, width, height)
        {
            this.opened = false;
            this.level = l;
            this.color = c;
        }
        public override void activate(Sprite collider)
        {
           //oh well
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
			if(level .inventory .containsKey (color) && !this.opened ){
                level.platforms.Remove(this);
            }
        }
    }
}
