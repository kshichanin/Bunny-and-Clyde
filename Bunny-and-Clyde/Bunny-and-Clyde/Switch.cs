#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using TiledSharp;
#endregion

namespace Bunny_and_Clyde
{
    class Switch : Item 
    {

        public SoundEffect soundeffect { get; set; }
        public Color color { get; private set; }
        private Level level;
        private bool activated;
        private bool activatedonce;
        private ContentManager contentManager;
        public Switch (Color c, Level l, float x, float y, int width, int height)
            :base("switch_button.png", x, y, width, height){
                color = c;
                activated = false;
                activatedonce = false;
                level = l;
        }

        public override void LoadContent(ContentManager content)
        {
            this.contentManager = content;
            base.LoadContent(content);
        }

        public override void activate(Sprite collider)
        {
            activated = true;
            if (activatedonce == false)
            {
                activatedonce = true;
          //not working for some reason      soundeffect.Play();
            }
            level.getGate(color).open();
            this.imageName = "switch_button_pressed.png";
            this.LoadContent(this.contentManager);
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (!activated && level.getGate(color) != null)
            {
                level.getGate(color).close();
                this.imageName = "switch_button.png";
                this.LoadContent(this.contentManager);
            }
            activated = false;
        }
        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(image, new Rectangle((int)Position.X, (int)Position.Y, Width, Height), this.color);
        }
    }
}
