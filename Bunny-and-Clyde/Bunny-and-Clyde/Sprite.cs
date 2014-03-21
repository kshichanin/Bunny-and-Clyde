using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace Bunny_and_Clyde
{
    class Sprite
    {
        private Texture2D image;
        private string imageName;
        public int Width { get; private set; }
        public int Height { get; private set; }
        public float Velocity { get; set; }
        public Rectangle HitBox { get; private set; }
        //private float scale;

        public Vector2 Position { get; set; }

        //public Sprite(string imageName, float initialX, float initialY, float scale)
        //{
        //    Position = new Vector2(initialX, initialY);
        //    //this.scale = scale;
        //    this.imageName = imageName;
        //}

        public Sprite(string imageName, float initialX, float initialY, int width, int height)
        {
            Position = new Vector2(initialX, initialY);
            Width = width;
            Height = height;
            this.imageName = imageName;
            HitBox = new Rectangle((int)initialX, (int)initialY, width, height);
        }

        public void LoadContent(ContentManager content)
        {
            image = content.Load<Texture2D>(imageName);
        }

        public void Update(GameTime gameTime)
        {
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
        }

        //public void Draw(SpriteBatch sb)
        //{
        //    sb.Draw(image, this.Position, null, Color.White, 0f, Vector2.Zero, this.scale, SpriteEffects.None, 0);
        //}

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(image, new Rectangle((int)Position.X, (int)Position.Y, Width, Height), Color.White);
        }
    }
}
