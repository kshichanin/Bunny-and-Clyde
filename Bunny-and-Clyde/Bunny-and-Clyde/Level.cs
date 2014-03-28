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
    class Level
    {
        private TmxMap map;
        private List<Sprite> worldSprites;
        private List<Sprite> platforms;
        private List<Sprite> items;
        private Vector2 bunnySpawn;
        private Vector2 clydeSpawn;
        private Sprite background;

        public Bunny Bunny { get; private set; }
        public Clyde Clyde { get; private set; }

        public Level(string mapFile, Bunny bunny, Clyde clyde)
        {
            this.map = new TmxMap(mapFile);

            // set the spawn point for each character
            this.bunnySpawn = new Vector2(Single.Parse(map.Properties["bunnySpawnX"]), Single.Parse(map.Properties["bunnySpawnY"]));
            this.clydeSpawn = new Vector2(Single.Parse(map.Properties["clydeSpawnX"]), Single.Parse(map.Properties["clydeSpawnY"]));

            this.worldSprites = new List<Sprite>();
            this.platforms = new List<Sprite>();
            this.items = new List<Sprite>();
        }
    }
}
