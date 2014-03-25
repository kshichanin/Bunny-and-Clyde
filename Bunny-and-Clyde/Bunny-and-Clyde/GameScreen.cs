#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using TiledSharp;
#endregion

namespace Bunny_and_Clyde
{
    class GameScreen
    {
        public List<Sprite> WorldSprites { get; private set; }
        private List<Sprite> platforms;
        private InputManager inputManager;
        private Bunny bunny;
        private Clyde clyde;
        private Physics physics;

        public GameScreen()
        {
            this.WorldSprites = new List<Sprite>();
            this.platforms = new List<Sprite>();
            
            // load each tile to be drawn
            TmxMap map = new TmxMap("Content\\lvl_1.tmx");
            

            // hardcoding the world objects, this should be changed later
            Sprite ground1 = new Sprite("ground", 0, 400, 222, 50);
            Sprite ground2 = new Sprite("ground", 578, 400, 222, 50);
            Sprite platform = new Sprite("platform", 275, 250, 222, 15);
            this.WorldSprites.Add(new Sprite("goldkey", 350, 238, 25, 12));
            this.WorldSprites.Add(new Sprite("golddoor", 735, 315, 55, 85));
            Sprite water = new Sprite("water", 0, 450, 800, 195);
            this.WorldSprites.Add(ground1);
            this.WorldSprites.Add(ground2);
            this.WorldSprites.Add(water);
            this.bunny = new Bunny(50, 325);
            this.WorldSprites.Add(bunny);
            this.clyde = new Clyde(75, 350);
            this.WorldSprites.Add(clyde);
            this.WorldSprites.Add(platform);
           

            platforms.Add(water);
            platforms.Add(ground1);
            platforms.Add(ground2);
            platforms.Add(platform);
            this.inputManager = new InputManager(WorldSprites, bunny, clyde, platforms);

            this.physics = new Physics();
            this.physics.Add(this.bunny);
            this.physics.Add(this.clyde);
            this.WorldSprites.Add(new Sprite("inventory", 0, 0, 55, 55));
        }

        public void Update(GameTime gameTime)
        {
            foreach (Sprite s in this.WorldSprites)
            {
                s.Update(gameTime);
            }
            this.physics.Update(gameTime);
            inputManager.Update(gameTime);
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
