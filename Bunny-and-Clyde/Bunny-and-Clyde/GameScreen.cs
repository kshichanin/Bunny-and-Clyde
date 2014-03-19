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
            Sprite ground = new Sprite("ground", 0, 400, 2.0f);
            Sprite ground2 = new Sprite("ground", 578, 400, 2.0f);
            Sprite bunny = new Sprite("bunny", 100, 100, 1.0f);
            this.worldSprites.Add(ground);
            this.worldSprites.Add(bunny);
            this.worldSprites.Add(ground2);
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
