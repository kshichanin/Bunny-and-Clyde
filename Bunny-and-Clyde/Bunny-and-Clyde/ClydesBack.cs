﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bunny_and_Clyde
{
    class ClydesBack : Item 
    {
        public ClydesBack(float x, float y, int width, int height)
            : base("blank.png", x, y, width, height)
        {

        }
        public override void activate(Sprite collider)
        {
            collider.state = State.Riding;
        }
    }
}
