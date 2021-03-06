﻿

﻿
﻿﻿using Microsoft.Xna.Framework;


using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace Bunny_and_Clyde
{
    class Clyde : Sprite, Gravity
    {
        static int CLYDE_WIDTH = 58, CLYDE_HEIGHT = 48;
        private Texture2D image;

        public Vector2 SpawnPoint { get; private set; }
        public ClydesBack back { get; private set; }
        public bool isAirbourne() { return base.state == State.Airbourne; }
        public imageshow die { get; set; }
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
            this.SpawnPoint = new Vector2(initialX, initialY);
            Velocity = Vector2.Zero;
            base.state = State.Default;
            base.jump = 8.3f;
            back = new ClydesBack(this,initialX + 5, initialY - 3, CLYDE_WIDTH -20, 5);
        }


        public override void Draw(SpriteBatch sb)
        {

            int width = image.Width / 4;
            base.Width = width;
            int height = (image.Height / 3);
            base.Height = height;
            int row = (int)((float)currentFrame / (float)4);
            int column = currentFrame % 4;
            Rectangle sourceRectangle = new Rectangle((width * column), (height * row), width, height);
            sb.Draw(image, base.Position, sourceRectangle, Color.White);
            //sb.Draw(image, new Rectangle((int)base.Position.X, (int)base.Position.Y, base.Width, base.Height), Color.White);
        }

        public override void LoadContent(ContentManager content)
        {
            string imageName = "Clyde.png";
            image = content.Load<Texture2D>(imageName);
            currentFrame = 0;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            back.Position = this.Position + new Vector2(15, 5);
            HitBox = new Rectangle((int)Position.X, (int)Position.Y+10, Width, Height-10);
            back.Update(gameTime);
            if (Velocity.Y < -jump)
            {
                Velocity = new Vector2(Velocity.X, -jump);
            }
        }

        public override Rectangle testBox(float X, float Y)
        {
            float tempx = Position.X + X;
            float tempy = Position.Y + Y + 10;
            return new Rectangle((int)tempx, (int)tempy, Width, Height-10);
        }
    }
}

