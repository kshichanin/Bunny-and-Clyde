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

#endregion

namespace Bunny_and_Clyde
{
    class InputManager
    {
        private List<Sprite> worldSprites;
        private KeyboardState currentKeyboard, previousKeyboard;
        public Sprite ActiveCharacter { get; private set; }
        public Sprite InactiveCharacter { get; private set; }
        public Sprite.State previousState { get; set; }
        public List<Sprite> Platforms { get; private set; }
        public List<SoundEffect> sounds { get; private set; }
        private bool check = false;
        private bool bunny = true;
        public InputManager(List<Sprite> worldSprites, Sprite activeCharacter, Sprite inactiveCharacter,List<Sprite> platforms, List<SoundEffect> sounds)
        {
            this.worldSprites = worldSprites;
            ActiveCharacter = activeCharacter;
            InactiveCharacter = inactiveCharacter;
            this.Platforms = platforms;
            previousState = InactiveCharacter.state;
            this.sounds = sounds;
        }

        public void Update(GameTime gameTime)
        {
            //Left Right Direction check
            currentKeyboard = Keyboard.GetState();
            Vector2 direction;
            if (currentKeyboard.IsKeyDown(Keys.Left) || GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed)
                ActiveCharacter.Velocity = new Vector2(-ActiveCharacter.Speed, ActiveCharacter.Velocity.Y);
            else if (currentKeyboard.IsKeyDown(Keys.Right) || GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed)
                ActiveCharacter.Velocity = new Vector2(ActiveCharacter.Speed, ActiveCharacter.Velocity.Y);
            else
                ActiveCharacter.Velocity = new Vector2(0, ActiveCharacter.Velocity.Y);
            
            //Switch active characters
            if ((currentKeyboard.IsKeyDown(Keys.RightShift) || GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Pressed) && !check)
            {
                //InactiveCharacter.state = previousState;
                Sprite temp = ActiveCharacter;
                ActiveCharacter = InactiveCharacter;
                InactiveCharacter = temp;
                check = true;
                //InactiveCharacter.state = Sprite.State.Default;
                bunny = !bunny;
            }
            if ((currentKeyboard.IsKeyDown(Keys.Up) || GamePad.GetState(PlayerIndex.One).DPad .Up  == ButtonState.Pressed) )
            {
                if (ActiveCharacter.state == Sprite.State.Swimming)
                {
                    ActiveCharacter.Velocity += new Vector2(0, -ActiveCharacter.Speed);
                }
            }
            if ((currentKeyboard.IsKeyDown(Keys.Down) || GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed))
            {
                if (ActiveCharacter.state == Sprite.State.Swimming)
                {
                    ActiveCharacter.Velocity += new Vector2(0, ActiveCharacter.Speed);
                }
            }
            //Vertical position change


            
            if ((currentKeyboard.IsKeyDown(Keys.Space) || GamePad .GetState (PlayerIndex.One).Buttons .A == ButtonState.Pressed) && ActiveCharacter.state != Sprite.State.Airbourne)
            {
                if (bunny)
                 {
                    sounds[0].Play();
                }
                else
                {
                    sounds[1].Play();
                }
                ActiveCharacter.state = Sprite.State.Airbourne;
                ActiveCharacter.Velocity -= new Vector2 (0, ActiveCharacter.jump);
            }
            /*
            if (ActiveCharacter.HitBox.Intersects(worldSprites[0].HitBox))
            {
                worldSprites[0].Position = new Vector2(12, 20);
            }

            if (ActiveCharacter.HitBox.Intersects(worldSprites[1].HitBox) && InactiveCharacter.HitBox.Intersects(worldSprites[1].HitBox) && worldSprites[0].Position.X == 12 && worldSprites[0].Position.Y == 20)
            {
                ActiveCharacter.Position = new Vector2(50, 325);
                InactiveCharacter.Position = new Vector2(60, 325);
                worldSprites[0].Position = new Vector2(352, 238);
                
            }
            */
            //create test positions
            /*
            Vector2 newPosition;// = ActiveCharacter.Position + (ActiveCharacter.Speed * direction);
            //Console.WriteLine("Inactive= " + InactiveCharacter.Velocity);
            //Console.WriteLine("Inactive= " + ActiveCharacter.Velocity);
            //Checks for collision and determines if position should be changed
            if (!checkScreenEdgeCollision(newPosition) && !checkPlatformCollision(newPosition, Platforms))
            {
                ActiveCharacter.Position = newPosition;
                if (ActiveCharacter.Velocity.Y >= 0)
                {
                    ActiveCharacter.state = Sprite.State.Airbourne;
                }
            }
            else if (checkScreenEdgeCollision(newPosition) && !checkPlatformCollision(newPosition, Platforms))
            {
                float newY = newPosition.Y;
                float currentX = ActiveCharacter.Position.X;
                newPosition = new Vector2(currentX, newY);
                ActiveCharacter.Position = newPosition;
                if (ActiveCharacter.Velocity.Y >= 0)
                {
                    ActiveCharacter.state = Sprite.State.Airbourne;
                }
            }
            */
            //checkItemCollision();
        }
/*
        private bool checkScreenEdgeCollision(Vector2 newPosition)
        {
            if (newPosition.X < 0 ||newPosition.X > GameGlobals.WINDOW_WIDTH - ActiveCharacter.Width)
                return true;
            else return false;
        }

        private bool checkPlatformCollision(Vector2 newPosition, List<Sprite> platforms)
        {
            int count = 0;
            foreach (Sprite platform in platforms)
            {
                if (count == 4) // platform = water***
                {
                    if (ActiveCharacter.testBox(newPosition.X, newPosition.Y).Intersects(platform.HitBox))
                    {
                        if (bunny)
                        {
                            ActiveCharacter.Position = new Vector2(50, 225);
                            ActiveCharacter.Velocity = 0;
                            return true;
                        }
                        else
                        {
                            if (ActiveCharacter.state == Sprite.State.Airbourne && ActiveCharacter.Velocity != 0)
                            {
                                ActiveCharacter.state = Sprite.State.Default;
                                ActiveCharacter.Velocity = 0;
                            }
                            return true;
                        }
                    }
                }
                else if (ActiveCharacter.testBox(newPosition.X, newPosition.Y).Intersects(platform.HitBox))
                {
                    //Console.WriteLine("Intersect");
                    if (ActiveCharacter.state == Sprite.State.Airbourne && ActiveCharacter.Velocity != 0)
                    {
                        ActiveCharacter.state = Sprite.State.Default;
                        ActiveCharacter.Velocity = 0;
                    }
                    return true;
                }
                count++;
            }

            return false;
        }
        */
        //private bool checkItemCollision()
        //{
        //}
    }
}
