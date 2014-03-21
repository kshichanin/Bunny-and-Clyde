#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace Bunny_and_Clyde
{
    class Bunny : Sprite, Gravity 
    {
        static int BUNNY_WIDTH = 74, BUNNY_HEIGHT = 73;

        public bool isAirbourne() { return base.state == State.Airbourne; }
        //public State BunnyState { get; set; }
        //public enum State { Default, Riding, Airbourne }

        public Bunny(float initialX, float initialY)
            : base("bunny", initialX, initialY, BUNNY_WIDTH, BUNNY_HEIGHT)
        {
            Velocity = 0;
            base.state = State.Default;
        }
    }
}
