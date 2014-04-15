using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bunny_and_Clyde
{
    class PlayerIcon
    {
        protected Texture2D[] images { get; private set; }
        protected Texture2D current { get; set; }
        protected Vector2 Position { get; set; }
        private String ImageName1, ImageName2;
        private int Width, Height;
        public bool bunny { get; set; }

        public PlayerIcon(String imageName1, String imageName2)
        {
            this.ImageName1 = imageName1;
            this.ImageName2 = imageName2;
            this.Position = new Vector2(1072, 0);
            this.bunny = true;
        }

        public void LoadContent(ContentManager content)
        {
            this.images = new Texture2D[] {content.Load<Texture2D>(ImageName1), content.Load<Texture2D>(ImageName2)};
            current = images[0];
            this.Width = images[0].Width;
            this.Height = images[0].Height;
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(current, new Rectangle((int)Position.X, (int)Position.Y, Width, Height), Color.White);
        }

        public void ChangeImage()
        {
            if (!bunny)
            {
                current = images[0];
            }
            else
            {
                current = images[1];
            }
            bunny = !bunny;
        }

    }
}
