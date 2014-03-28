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

        // sprites
        private List<Sprite> worldSprites;
        private List<Sprite> platforms;
        private List<Sprite> items;
        private Sprite background;

        // spawn points
        private Vector2 bunnySpawn;
        private Vector2 clydeSpawn;

        // map objects
        private TmxObjectGroup mapObjectsDrawable;
        private TmxObjectGroup mapObjectsNonDrawable;

        // sounds
        private List<SoundEffect> sounds;

        // physics
        private Physics physics;

        // collisions
        private CollisionManager collisions;

        // input
        private InputManager inputManager;

        public Bunny Bunny { get; private set; }
        public Clyde Clyde { get; private set; }

        public Level(string mapFile)
        {
            this.map = new TmxMap(mapFile);

            this.Bunny = new Bunny(Single.Parse(map.Properties["bunnySpawnX"]), Single.Parse(map.Properties["bunnySpawnY"]));
            this.Clyde = new Clyde(Single.Parse(map.Properties["clydeSpawnX"]), Single.Parse(map.Properties["clydeSpawnY"]));

            this.worldSprites = new List<Sprite>();
            this.physics = new Physics();
            this.physics.Add(this.Bunny);
            this.physics.Add(this.Clyde);
            this.collisions = new CollisionManager(platforms, items, new List<Sprite>());
            this.collisions.addMoving(this.Bunny);
            this.collisions.addMoving(this.Clyde);

            this.mapObjectsDrawable = map.ObjectGroups["drawable"];
            this.mapObjectsNonDrawable = map.ObjectGroups["nondrawable"];

            // draw the nondrawable objects as Regions
            foreach (TmxObjectGroup.TmxObject o in mapObjectsNonDrawable.Objects)
            {
                Console.WriteLine("X:" + o.X);
                Console.WriteLine("Y:" + o.Y);
                Console.WriteLine("Width:" + o.Width);
                Console.WriteLine("Height:" + o.Height);

                Region currentRegion = new Region(o.X, o.Y, o.Width, o.Height);
                //Sprite currentRegion = new Sprite("ground", o.X, o.Y, o.Width, o.Height);
                this.worldSprites.Add(currentRegion);
                this.platforms.Add(currentRegion);
            }

            // draw the drawable objects
            foreach (TmxObjectGroup.TmxObject o in mapObjectsDrawable.Objects)
            {
                Sprite currentObject = new Sprite(o.Properties["imageName"], o.X, o.Y, o.Width, o.Height);
                this.worldSprites.Add(currentObject);
                this.items.Add(currentObject);
            }

            this.background = new Sprite("lvl_1.png", 0, 0, 1280, 448);

            this.worldSprites.Add(this.Bunny);
            this.worldSprites.Add(this.Clyde);

        }
    }
}
