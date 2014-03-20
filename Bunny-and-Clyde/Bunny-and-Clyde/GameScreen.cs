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
        public List<Sprite> WorldSprites { get; private set; }

        public GameScreen()
        {
            this.WorldSprites = new List<Sprite>();
            
            // hardcoding the world objects, this should be changed later
            this.WorldSprites.Add(new Sprite("water", 0, 405, 800, 195));
            this.WorldSprites.Add(new Sprite("ground", 0, 400, 222, 10));
            this.WorldSprites.Add(new Sprite("ground", 578, 400, 222, 10));
            this.WorldSprites.Add(new Sprite("bunny", 50, 327, 74, 73));
            this.WorldSprites.Add(new Sprite("Turtle", 375, 375, 58, 48));
            this.WorldSprites.Add(new Sprite("platform", 275, 250, 222, 10));
            this.WorldSprites.Add(new Sprite("goldkey", 350, 238, 25, 12));
            this.WorldSprites.Add(new Sprite("golddoor", 735, 315, 55, 85));
        }

        public void LoadContent(ContentManager content)
        {
            foreach (Sprite s in this.WorldSprites)
            {
                s.LoadContent(content);
            }
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (Sprite s in this.WorldSprites)
            {
                s.Draw(sb);
            }
        }
    }
}
