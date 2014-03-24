﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bunny_and_Clyde
{
    class Clyde : Sprite, Gravity 
    {
        static int CLYDE_WIDTH = 58, CLYDE_HEIGHT = 48;
        
        public bool isAirbourne() { return base.state == State.Airbourne; }
        //public enum State
        //{
        //    Default,
        //    Airbourne,
        //    Swimming,
        //    Diving
        //}
        //public State ClydeState { get; set; }

        public Clyde(float initialX, float initialY)
            : base("Turtle", initialX, initialY, CLYDE_WIDTH, CLYDE_HEIGHT)
        {
            Velocity = 0;
            base.state = State.Default;
            base.jump = 3f;
        }

    }
}