using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;
namespace Bunny_and_Clyde
{
    class Ramp : Item, Gravity
    {
        public SoundEffect soundeffect { get; set; }
        public PushBox pushBox { get; set; }
        public Ramp( float x, float y, int width, int height)
        :base("gate_block",x,y,width,height)
        {
            pushBox = new PushBox( this, x - 3f, y, 3, height);
        }
        public override void activate(Sprite collider)
        {
            //oh well...
            
         //working buy is annoying right now since it plays during every collision   soundeffect.Play();
        }
        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);

            if (this.Velocity.Y != 0)
            {
                this.Velocity = new Vector2(0, this.Velocity.Y);
                pushBox.Position = new Vector2(-10, -10);
            }
            else
            {
                pushBox.Position = this.Position - new Vector2(3, 0);
            }
        }
    }
}
