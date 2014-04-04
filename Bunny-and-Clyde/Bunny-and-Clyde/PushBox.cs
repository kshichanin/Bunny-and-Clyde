using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
namespace Bunny_and_Clyde
{
    class PushBox : Item
    {
        private Ramp connectedRamp;
        
        public PushBox( Ramp r, float x, float y, int width, int height)
            : base("blank",x, y, width, height)
        {
            connectedRamp = r;
          
        }
        public override void activate(Sprite collider)
        {
            if (collider.Velocity.X > 0 && collider .GetType ()==typeof (Bunny))
            {
                connectedRamp.Velocity = new Vector2(collider.Velocity.X, connectedRamp.Velocity.Y);
                collider.state = State.Pushing;
            }
        }
    }
}
