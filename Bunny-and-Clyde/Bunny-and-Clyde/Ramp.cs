﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bunny_and_Clyde
{
    class Ramp : Item
    {
        public Ramp(float x, float y, int width, int height)
        :base("gate_block",x,y,width,height)
        {
        }
        public override void activate(Sprite collider)
        {
            //oh well...
        }
    }
}