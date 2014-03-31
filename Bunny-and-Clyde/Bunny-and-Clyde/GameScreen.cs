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
    class GameScreen
    {
        //public List<Sprite> WorldSprites { get; private set; }
        //private List<Sprite> platforms;
        //private List<Sprite> items;
        //private List<SoundEffect> sounds;
        //private InputManager inputManager;
        //private Bunny bunny;
        //private Clyde clyde;
        //private Physics physics;
        //private Sprite background;
        //private CollisionManager collisions;
        private Level lvl_1;
        private LevelManager levelManager;

        public GameScreen(GraphicsDeviceManager graphics)
        {
            //this.lvl_1 = new Level("Content\\lvl_1.tmx", graphics);
            List<Level> levels = new List<Level>();
            levels.Add(new Level("Content\\lvl_1.tmx", graphics));
            levels.Add(new Level("Content\\lvl_2.tmx", graphics));
            this.levelManager = new LevelManager(levels);

            //this.WorldSprites = new List<Sprite>();
            //this.platforms = new List<Sprite>();
            //this.items = new List<Sprite>();
            //this.sounds = new List<SoundEffect>();

            //// load each object to be drawn
            //TmxMap map = new TmxMap("Content\\lvl_1.tmx");
            //TmxObjectGroup mapObjectsDrawable = map.ObjectGroups["drawable"];
            //TmxObjectGroup mapObjectsNonDrawable = map.ObjectGroups["nondrawable"];

            //this.platforms.Add(new Region(0, 0, 0, 0));

            //// draw the nondrawable objects as Regions
            //foreach (TmxObjectGroup.TmxObject o in mapObjectsNonDrawable.Objects)
            //{
            //    Console.WriteLine("X:" + o.X);
            //    Console.WriteLine("Y:" + o.Y);
            //    Console.WriteLine("Width:" + o.Width);
            //    Console.WriteLine("Height:" + o.Height);

            //    Region currentRegion = new Region(o.X, o.Y, o.Width, o.Height);
            //    //Sprite currentRegion = new Sprite("ground", o.X, o.Y, o.Width, o.Height);
            //    this.WorldSprites.Add(currentRegion);
            //    this.platforms.Add(currentRegion);
            //}

            //// draw the drawable objects
            //foreach (TmxObjectGroup.TmxObject o in mapObjectsDrawable.Objects)
            //{
            //    Sprite currentObject = new Sprite(o.Properties["imageName"], o.X, o.Y, o.Width, o.Height);
            //    this.WorldSprites.Add(currentObject);
            //    this.items.Add(currentObject);
            //}

            //this.background = new Sprite("lvl_1.png", 0, 0, 1280, 448);

            //// hardcoding the world objects, this should be changed later
            ////Sprite ground1 = new Sprite("ground", 0, 400, 222, 50);
            ////Sprite ground2 = new Sprite("ground", 578, 400, 222, 50);
            ////Sprite platform = new Sprite("platform", 275, 250, 222, 15);
            ////this.WorldSprites.Add(new Sprite("goldkey", 350, 238, 25, 12));
            ////this.WorldSprites.Add(new Sprite("golddoor", 735, 315, 55, 85));
            ////Sprite water = new Sprite("water", 0, 450, 800, 195);
            ////this.WorldSprites.Add(ground1);
            ////this.WorldSprites.Add(ground2);
            ////this.WorldSprites.Add(water);
            ////this.WorldSprites.Add(platform);
            //this.bunny = new Bunny(50, 150);
            //this.WorldSprites.Add(bunny);
            //this.clyde = new Clyde(75, 150);
            //this.WorldSprites.Add(clyde);
            ////this.WorldSprites.Add(new Sprite("lvl_1.png", 0, 0, 1280, 448));

            ////platforms.Add(water);
            ////platforms.Add(ground1);
            ////platforms.Add(ground2);
            ////platforms.Add(platform);
            
            //this.inputManager = new InputManager(WorldSprites, bunny, clyde, platforms, sounds);

            ////this.inputManager = new InputManager(WorldSprites, bunny, clyde, platforms);
            
            //this.physics = new Physics();
            //this.physics.Add(this.bunny);
            //this.physics.Add(this.clyde);
            //this.collisions = new CollisionManager(platforms, items, new List<Sprite>());
            //this.collisions.addMoving(this.bunny);
            //this.collisions.addMoving(this.clyde);
            //this.WorldSprites.Add(new Sprite("inventory", 0, 0, 55, 55));
        }

        public void Update(GameTime gameTime)
        {
            //foreach (Sprite s in this.WorldSprites)
            //{
            //    s.Update(gameTime);
            //}
            //this.physics.Update(gameTime);
            //inputManager.Update(gameTime);
            //this.collisions.Update();

            this.levelManager.Update(gameTime);
        }

        public void LoadContent(ContentManager content)
        {
            //this.background.LoadContent(content);
            //SoundEffect jump;
            //jump = content.Load<SoundEffect>("bunny_jump.wav");
            //sounds.Add(jump);
            //SoundEffect jump2;
            //jump2 = content.Load<SoundEffect>("clyde_jump.wav");
            //sounds.Add(jump2);
            //foreach (Sprite s in this.WorldSprites)
            //{
            //    s.LoadContent(content);
            //}
            this.levelManager.LoadContent(content);
        }

        public void Draw(SpriteBatch sb)
        {
            //this.background.Draw(sb);

            //foreach (Sprite s in this.WorldSprites)
            //{
            //    s.Draw(sb);
            //}

            this.levelManager.Draw(sb);
        }
    }
}
