using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Bunny_and_Clyde
{
    class Switch : Item 
    {
        public Color color { get; private set; }
        private Level level;
        private bool activated;
        public Switch (Color c, Level l, float x, float y, int width, int height)
            :base("switch_block_placeholder.png", x, y, width, height){
                color = c;
                activated = false;
                level = l;
        }
        public override void activate(Sprite collider)
        {
            activated = true;
            level.getGate(color).open();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (!activated && level.getGate(color) != null)
            {
                level.getGate(color).close();
            }
            activated = false;
        }
        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(image, new Rectangle((int)Position.X, (int)Position.Y, Width, Height), this.color);
        }
    }
}
