﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace Bunny_and_Clyde
{
    class Bunny : Sprite, Gravity 
    {
        static int BUNNY_WIDTH = 74, BUNNY_HEIGHT = 73;
        public Vector2 SpawnPoint{get; private set;}
        public imageshow die { get; set; }
        public int mapwidth { get; set; }
        public bool isAirbourne() { return base.state == State.Airbourne; }

        private Texture2D image;

        //public State BunnyState { get; set; }
        //public enum State { Default, Riding, Airbourne }

        public Bunny(float initialX, float initialY)
            : base("bunny", initialX, initialY, BUNNY_WIDTH, BUNNY_HEIGHT)
        {
            this.SpawnPoint = new Vector2(initialX, initialY);
            Velocity = new Vector2 (0,0);
            base.state = State.Default;
            base.jump = 13f;
        }

        public override void Draw(SpriteBatch sb)
        {

            int width = image.Width / 3;
            base.Width = width;
            int height = (image.Height / 2);
            base.Height = height;
            int row = (int)((float)currentFrame / (float)3);
            int column = currentFrame % 3;
            Rectangle sourceRectangle = new Rectangle((width * column), (height * row), width, height);
            sb.Draw(image, base.Position, sourceRectangle, Color.White);
            //sb.Draw(image, new Rectangle((int)base.Position.X, (int)base.Position.Y, base.Width, base.Height), Color.White);
        }

        public override void LoadContent(ContentManager content)
        {
            string imageName = "bunny.png";
            image = content.Load<Texture2D>(imageName);
            currentFrame = 4;
        }
    }
}
