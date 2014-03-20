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
    class InputManager
    {
        private List<Sprite> worldSprites;
        private KeyboardState currentKeyboard, previousKeyboard;
        public Sprite ActiveCharacter { get; private set; }
        public List<Sprite> Platforms { get; private set; }

        public InputManager(List<Sprite> worldSprites, Sprite activeCharacter, List<Sprite> platforms)
        {
            this.worldSprites = worldSprites;
            ActiveCharacter = activeCharacter;
        }

        public void Update(GameTime gameTime)
        {
            currentKeyboard = Keyboard.GetState();

            //checkScreenEdgeCollision();
            //checkPlatformCollision();
            //checkItemCollision();
        }

        private bool checkScreenEdgeCollision(Vector2 newPosition)
        {
            if (newPosition.X < 0 || newPosition.X > GameGlobals.WINDOW_WIDTH - ActiveCharacter.Width)
                return true;
            else return false;
        }

        //private bool checkPlatformCollision(Vector2 newPosition)
        //{
        //    //if (newPosition.X <= 222 && newPosition.Y >= (400 - ActiveCharacter.Height)
        //    //    return true;
        //    //else if (newPosition.X >= (275 - ActiveCharacter.Width) && newPosition.X <= 497 && newPosition.Y 
        //}

        //private bool checkItemCollision()
        //{
        //}
    }
}
