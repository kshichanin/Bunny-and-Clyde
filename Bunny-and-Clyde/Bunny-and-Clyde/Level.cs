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
        public TmxMap map { get; private set; }

        // sprites
        private List<Sprite> worldSprites;
        public List<Sprite> platforms{get; private set;}
        public List<Item> items {get; private set;}
        public Inventory inventory { get; private set; }
        private Sprite background;
        public imageshow imshow { get; private set; }
        public imageshow imshow2 { get; private set; }

        private List<SoundEffect> sounds;

        // map objects
        private TmxObjectGroup mapObjectsDrawable;
        private TmxObjectGroup mapObjectsNonDrawable;

        // engine modules
        private Physics physics;
        private CollisionManager collisions;
        private InputManager inputManager;
        public GraphicsDeviceManager graphics { get; private set; }

        public bool isComplete { get; set; }

        public Bunny Bunny { get; private set; }
        public Clyde Clyde { get; private set; }

        public Level(string mapFile, GraphicsDeviceManager graphicsManager)
        {
            this.isComplete = false;

            this.graphics = graphicsManager;
            this.map = new TmxMap(mapFile);

            this.Bunny = new Bunny(
                Single.Parse(map.Properties["bunnySpawnX"]),
                Single.Parse(map.Properties["bunnySpawnY"]));
            this.Clyde = new Clyde(
                Single.Parse(map.Properties["clydeSpawnX"]),
                Single.Parse(map.Properties["clydeSpawnY"]));

            this.inventory = new Inventory(0, 0, 55, 55);
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
                Key whiteKey = new Key(Color.AliceBlue, this, 0, 0, 0, 0);
                if (o.Properties["type"] == "water")
                {
                    currentObject = new Water( o.X, o.Y, o.Width, o.Height);
                }
                else if (o.Properties["type"] == "key")
                {
                    System.Drawing.Color drawColor = System.Drawing.Color.FromName(o.Properties["color"]);
                    Color c = new Color(drawColor.R, drawColor.G, drawColor.B, drawColor.A);
                    whiteKey  = new Key(c, this, o.X, o.Y, o.Width, o.Height);
                    currentObject  = whiteKey;
                }
                else if (o.Properties["type"] == "goal_door")
                {
                    System .Drawing .Color drawColor = System .Drawing .Color.FromName (o.Properties["color"]);
                    Color c = new Color (drawColor .R ,drawColor .G ,drawColor .B ,drawColor .A);
                    currentObject = new Goal(this, c, o.X, o.Y, o.Width, o.Height);
                }
                else if (o.Properties["type"] == "switch_button")
                {
                    System.Drawing.Color drawColor = System.Drawing.Color.FromName(o.Properties["color"]);
                    Color c = new Color(drawColor.R, drawColor.G, drawColor.B, drawColor.A);
                    currentObject = new Switch(c,this, o.X, o.Y, o.Width, o.Height);
                }
                else if (o.Properties["type"] == "switch_gate")
                {
                    System.Drawing.Color drawColor = System.Drawing.Color.FromName(o.Properties["color"]);
                    Color c = new Color(drawColor.R, drawColor.G, drawColor.B, drawColor.A);
                    currentObject = new Gate(c, o.X, o.Y, o.Width, o.Height);
                    this.platforms.Add(currentObject);
                }
                else if (o.Properties["type"] == "door")
                {
                    System.Drawing.Color drawColor = System.Drawing.Color.FromName(o.Properties["color"]);
                    Color c = new Color(drawColor.R, drawColor.G, drawColor.B, drawColor.A);
                    currentObject = new Door(this, c, o.X, o.Y, o.Width, o.Height);
                    this.platforms.Add(currentObject);
                }
                else
                {
                    //this shouldn't happen
                    currentObject = new Water(o.X, o.Y, o.Width, o.Height);
                    Console.WriteLine(o.Properties["imageName"]);
                }
                this.worldSprites.Add(currentObject);
                this.items.Add(currentObject);
            }

            this.background = new Sprite(map.Properties["backgroundImage"], 0, 0,
                GameGlobals.WINDOW_WIDTH, GameGlobals.WINDOW_HEIGHT);

            this.worldSprites.Add(this.Bunny);
            this.worldSprites.Add(this.Clyde);

            this.inputManager = new InputManager(worldSprites, this.Bunny, this.Clyde, platforms, sounds);
            this.physics = new Physics();
            this.physics.Add(this.Bunny);
            this.physics.Add(this.Clyde);
            this.collisions = new CollisionManager(platforms, new List<Item>(items), new List<Sprite>());
            this.collisions.addMoving(this.Bunny);
            this.collisions.addMoving(this.Clyde);
            this.worldSprites.Add(inventory);
            this.imshow2 = new imageshow("bunnydies", 470, 70, 0, 300);
            this.worldSprites.Add(imshow2);
            this.Bunny.die = imshow2;
            this.imshow = new imageshow("mainlogo", 250, 10, 800, 400);
            this.worldSprites.Add(imshow);
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
        public Gate getGate(Color c)
        {
            foreach (Item i in this.items)
            {
                if(i.GetType () == typeof (Gate)){
                    Gate gate = (Gate)i;
                    if(gate.color == c){
                        return gate ;
                    }
                }
            }
            return null;
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
