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
    class LevelManager
    {
        private List<Level> levels;
        private int currentLevelIndex;

        public LevelManager(List<Level> levels)
        {
            this.levels = levels;
            this.currentLevelIndex = 0;
        }

        public void LoadContent(ContentManager content)
        {
            //this.levels[this.currentLevelIndex].LoadContent(content);
            foreach (Level lvl in levels)
            {
                lvl.LoadContent(content);
            }
        }

        public void Update(GameTime gameTime)
        {
            if (this.levels[this.currentLevelIndex].isComplete)
            {
                this.nextLevel();
            }
            this.levels[this.currentLevelIndex].Update(gameTime);
        }

        public void Draw(SpriteBatch sb)
        {
            this.levels[this.currentLevelIndex].Draw(sb);
        }

        public void nextLevel()
        {
            this.currentLevelIndex++;
        }
    }
}
