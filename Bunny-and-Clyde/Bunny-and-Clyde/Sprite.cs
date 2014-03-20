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
        private int width, height;
        private float scale;

        public Vector2 Position
        {
            get;
            set;
        }

        public Sprite(string imageName, float initialX, float initialY, float scale)
        {
            this.Position = new Vector2(initialX, initialY);
            this.scale = scale;
            this.imageName = imageName;
        }

        public Sprite(string imageName, float initialX, float initialY, int width, int height)
        {
            this.Position = new Vector2(initialX, initialY);
            this.width = width;
            this.height = height;
            this.imageName = imageName;
        }

        public void LoadContent(ContentManager content)
        {
            image = content.Load<Texture2D>(imageName);
        }

        //public void Draw(SpriteBatch sb)
        //{
        //    sb.Draw(image, this.Position, null, Color.White, 0f, Vector2.Zero, this.scale, SpriteEffects.None, 0);
        //}

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(image, new Rectangle((int)this.Position.X, (int)this.Position.Y, width, height), Color.White);
        }
    }
}
