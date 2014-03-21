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
            this.Platforms = platforms;
        }

        public void Update(GameTime gameTime)
        {
            currentKeyboard = Keyboard.GetState();
            Vector2 direction;
            if (currentKeyboard.IsKeyDown(Keys.Left))
                direction = Vector2.Normalize(new Vector2(-1, 0));
            else if (currentKeyboard.IsKeyDown(Keys.Right))
                direction = Vector2.Normalize(new Vector2(1, 0));
            else
                direction = Vector2.Zero;

            
            direction += new Vector2(0, -ActiveCharacter.Velocity);

            if (currentKeyboard.IsKeyDown(Keys.Space) && ActiveCharacter.state != Sprite.State.Airbourne)
            {
                ActiveCharacter.state = Sprite.State.Airbourne;
                ActiveCharacter.Velocity = 0.5f;
            }
            
            Vector2 newPosition = ActiveCharacter.Position + (GameGlobals.BUNNY_MOVE_SPEED * direction);

            if (!checkScreenEdgeCollision(newPosition) && !checkPlatformCollision(newPosition, Platforms))
            {
                ActiveCharacter.Position = newPosition;
            }
                
            //checkItemCollision();
        }

        private bool checkScreenEdgeCollision(Vector2 newPosition)
        {
            if (newPosition.X < 0 || newPosition.X > GameGlobals.WINDOW_WIDTH - ActiveCharacter.Width)
                return true;
            else return false;
        }

        private bool checkPlatformCollision(Vector2 newPosition, List<Sprite> platforms)
        {
            foreach (Sprite platform in platforms)
            {
                if (ActiveCharacter.HitBox.Intersects(platform.HitBox))
                {
                    Console.WriteLine("Intersect");
                    if (ActiveCharacter.state == Sprite.State.Airbourne && ActiveCharacter.Velocity != 0)
                    {
                        ActiveCharacter.state = Sprite.State.Default;
                        ActiveCharacter.Velocity = 0;
                    }
                    return true;
                }
            }

            return false;
        }

        //private bool checkItemCollision()
        //{
        //}
    }
}
