﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
namespace Bunny_and_Clyde
{
    class PushBox : Item
    {
        private Ramp connectedRamp;
        private bool direction;

        public SoundEffect soundeffect { get; set; }
        public Vector2 SpawnPoint { get; private set; }
        public PushBox( Ramp r, float x, float y, int width, int height, bool direction)
            : base("blank",x, y, width, height)
        {
            this.SpawnPoint = new Vector2(x, y);
            connectedRamp = r;
            this.direction = direction;
        }
        public override void activate(Sprite collider)
        {
            if (((collider.Velocity.X > 0 && direction) || (collider.Velocity.X < 0 && !direction)) && collider.GetType() == typeof(Bunny))
            {
                connectedRamp.Velocity = new Vector2(collider.Velocity.X, connectedRamp.Velocity.Y);
                collider.state = State.Pushing;

                soundeffect.Play();
            }
            else 
            {
                connectedRamp.Velocity = new Vector2(0, connectedRamp.Velocity.Y);
            }
        }
    }
}
