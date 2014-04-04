﻿#region Using Statements
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
        public List<Level> levels { get; private set; }
        public Song maintheme { get; private set; }
        public int currentLevelIndex { get; private set; }
        public bool playing { get; private set; }
        //public bool Resize { get; set; }

        public LevelManager(List<Level> levels)
        {
            this.levels = levels;
            this.currentLevelIndex = 0;
            //this.Resize = false;
        }

        public void LoadContent(ContentManager content)
        {
            //do lists of songs later
            maintheme = content.Load<Song>("mainthemetheone.wav");  // Put the name of your song here instead of "song_title"
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.25f;
            playing = false;
            //this.levels[this.currentLevelIndex].LoadContent(content);
            foreach (Level lvl in levels)
            {
                lvl.LoadContent(content);
            }
        }

        public void Update(GameTime gameTime)
        {
            if (this.currentLevelIndex == 0)
            {
                if (playing == false)
                {
                    MediaPlayer.Stop();
                    MediaPlayer.Play(maintheme);
                    playing = true;
                }
            }
            if (this.levels[this.currentLevelIndex].isComplete)
            {
                if (this.currentLevelIndex + 1 != this.levels.Count)
                {
                    MediaPlayer.Stop();
                    MediaPlayer.Play(maintheme);
                    this.nextLevel();
                }
                else
                {
                    //show image and quit
                    this.levels[this.currentLevelIndex].imshow3.Width = this.levels[this.currentLevelIndex].map.TileWidth * this.levels[this.currentLevelIndex].map.Width;
                }
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
            //this.Resize = true;
        }
    }
}
