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
    class GameScreen
    {
        private List<Sprite> worldSprites;

        public GameScreen()
        {
            this.worldSprites = new List<Sprite>();
            
            // hardcoding the world objects, this should be changed later
            this.worldSprites.Add(new Sprite("water", 0, 405, 40.0f));
            this.worldSprites.Add(new Sprite("ground", 0, 400, 2.0f));
            this.worldSprites.Add(new Sprite("ground", 578, 400, 2.0f));
            this.worldSprites.Add(new Sprite("bunny", 50, 327, 0.75f));
            this.worldSprites.Add(new Sprite("Turtle", 375, 375, 1.0f));
            this.worldSprites.Add(new Sprite("platform", 275, 250, 2.0f));
            this.worldSprites.Add(new Sprite("goldkey", 350, 238, 1.0f));
            this.worldSprites.Add(new Sprite("golddoor", 735, 315, 0.75f));
        }

        public void LoadContent(ContentManager content)
        {
            foreach (Sprite s in this.worldSprites)
            {
                s.LoadContent(content);
            }
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (Sprite s in this.worldSprites)
            {
                s.Draw(sb);
            }
        }
    }
}
