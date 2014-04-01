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
        private List<Item> items;
        private Sprite background;

        private List<SoundEffect> sounds;

        // map objects
        private TmxObjectGroup mapObjectsDrawable;
        private TmxObjectGroup mapObjectsNonDrawable;

        // engine modules
        private Physics physics;
        private CollisionManager collisions;
        private InputManager inputManager;
        private GraphicsDeviceManager graphics;

        public Bunny Bunny { get; private set; }
        public Clyde Clyde { get; private set; }

        public Level(string mapFile, GraphicsDeviceManager graphicsManager)
        {
            this.graphics = graphicsManager;
            this.map = new TmxMap(mapFile);

            this.Bunny = new Bunny(
                Single.Parse(map.Properties["bunnySpawnX"]),
                Single.Parse(map.Properties["bunnySpawnY"]));
            this.Clyde = new Clyde(
                Single.Parse(map.Properties["clydeSpawnX"]),
                Single.Parse(map.Properties["clydeSpawnY"]));

            this.worldSprites = new List<Sprite>();
            this.platforms = new List<Sprite>();
            this.items = new List<Item>();
            this.sounds = new List<SoundEffect>();

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
                Item currentObject;
                if (o.Properties["type"] == "water")
                {
                    currentObject = new Water( o.X, o.Y, o.Width, o.Height);
                }
                else if (o.Properties["imageName"] == "key_tile.png")
                {
                    currentObject = new Key(Color.AliceBlue, o.X, o.Y, o.Width, o.Height);
                }
                else if (o.Properties["imageName"] == "door_tile.png")
                {
                    currentObject = new Door(o.X, o.Y, o.Width, o.Height);
                }
                else
                {
                    //this shouldn't happen
                    currentObject = new Door(o.X, o.Y, o.Width, o.Height);
                    Console.WriteLine(o.Properties["imageName"]);
                }
                this.worldSprites.Add(currentObject);
                this.items.Add(currentObject);
            }

            this.background = new Sprite(map.Properties["backgroundImage"], 0, 0,
                int.Parse(map.Properties["width"]), int.Parse(map.Properties["height"]));

            this.worldSprites.Add(this.Bunny);
            this.worldSprites.Add(this.Clyde);

            this.inputManager = new InputManager(worldSprites, this.Bunny, this.Clyde, platforms, sounds);
            this.physics = new Physics();
            this.physics.Add(this.Bunny);
            this.physics.Add(this.Clyde);
            this.collisions = new CollisionManager(platforms, items, new List<Sprite>());
            this.collisions.addMoving(this.Bunny);
            this.collisions.addMoving(this.Clyde);
            this.worldSprites.Add(new Sprite("inventory", 0, 0, 55, 55));
        }

        public void LoadContent(ContentManager content)
        {
            this.background.LoadContent(content);
            SoundEffect jumpBunny = content.Load<SoundEffect>("bunny_jump.wav");
            SoundEffect jumpClyde = content.Load<SoundEffect>("clyde_jump.wav");
            sounds.Add(jumpBunny);
            sounds.Add(jumpClyde);
            foreach (Sprite s in this.worldSprites)
            {
                s.LoadContent(content);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (Sprite s in this.worldSprites)
            {
                s.Update(gameTime);
            }
            this.physics.Update(gameTime);
            this.inputManager.Update(gameTime);
            this.collisions.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            this.background.Draw(sb);

            foreach (Sprite s in this.worldSprites)
            {
                s.Draw(sb);
            }
        }
    }
}
