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
        private bool direction;
        public PushBox( Ramp r, float x, float y, int width, int height, bool direction)
            : base("door_tile",x, y, width, height)
        {
            connectedRamp = r;
            this.direction = direction;
        }
        public override void activate(Sprite collider)
        {
            if (((collider.Velocity.X > 0 && direction) || (collider.Velocity.X < 0 && !direction)) && collider.GetType() == typeof(Bunny))
            {
                connectedRamp.Velocity = new Vector2(collider.Velocity.X, connectedRamp.Velocity.Y);
                collider.state = State.Pushing;
            }
            else 
            {
                connectedRamp.Velocity = new Vector2(0, connectedRamp.Velocity.Y);
            }
        }
    }
}
