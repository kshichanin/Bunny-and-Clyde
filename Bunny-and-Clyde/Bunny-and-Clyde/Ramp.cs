﻿using System;
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

        public PushBox leftPushBox { get; set; }
        public PushBox rightPushBox { get; set; }
        public Vector2 SpawnPoint { get; private set; }
        public SoundEffect soundeffect { get; set; }
        public Ramp(string imageName, float x, float y, int width, int height, Level l)
            : base(imageName, x, y, width, height)
        {

            this.SpawnPoint = new Vector2(x, y);
            leftPushBox = new PushBox(this, x - 3f, y + 3, 5, height - 6, true);
            rightPushBox = new PushBox(this, x + width, y + 3, 5, height - 6, false);
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
                leftPushBox.Position = new Vector2(-10, -10);
                rightPushBox.Position = new Vector2(-10, -10);
            }
            else
            {
                leftPushBox.Position = this.Position + new Vector2(-5, 3);
                rightPushBox.Position = this.Position + new Vector2(Width, 3);
            }
        }
    }
}
