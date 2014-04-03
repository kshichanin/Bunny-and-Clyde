using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bunny_and_Clyde
{
    class PushBox : Item
    {
        private Ramp connectedRamp;
        public PushBox(Ramp r, float x, float y, int width, int height)
            : base("blank",x, y, width, height)
        {
            connectedRamp = r;
        }
        public override void activate(Sprite collider)
        {
            collider.state = State.Pushing;
        }
    }
}
