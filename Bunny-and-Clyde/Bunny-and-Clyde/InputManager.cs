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
        public Level level { get; private set; }
        public Ramp pushedRamp { get; set; }
        public PlayerIcon playerIcon { get; set; }
        private bool check = false;
        private bool rKeyEdge = false;
        private TimeSpan sum;
        private bool bunny = true;
        public InputManager(List<Sprite> worldSprites, Sprite activeCharacter, Sprite inactiveCharacter,List<Sprite> platforms, List<SoundEffect> sounds, Level l)
        {
            this.level = l;
            this.worldSprites = worldSprites;
            ActiveCharacter = activeCharacter;
            InactiveCharacter = inactiveCharacter;
            this.Platforms = platforms;
            previousState = InactiveCharacter.state;
            this.sounds = sounds;
            sum = TimeSpan.Zero;
            this.playerIcon = playerIcon;
        }

        public void Update(GameTime gameTime)
        {
            sum += gameTime.ElapsedGameTime;
            //Left Right Direction check
            currentKeyboard = Keyboard.GetState();
            Vector2 direction;
            InactiveCharacter.Velocity -= new Vector2(InactiveCharacter.Velocity.X, 0);
            if (currentKeyboard.IsKeyDown(Keys.Enter) || GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed){
                worldSprites[worldSprites.Count - 2].Width = 0;
            }
            if (!rKeyEdge && (currentKeyboard.IsKeyDown(Keys.R) || GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed))
            {
                rKeyEdge = true;
                this.level.restart();
            }
            else if (currentKeyboard.IsKeyUp(Keys.R) && GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Released)
            {
                rKeyEdge = false;
            }
            if (worldSprites[worldSprites.Count - 2].Width == 0)
            {
                if (currentKeyboard.IsKeyDown(Keys.Left) || GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed)
                {
                    worldSprites[worldSprites.Count - 1].Width = 0;
                    ActiveCharacter.Velocity = new Vector2(-ActiveCharacter.Speed, ActiveCharacter.Velocity.Y);
                    if (InactiveCharacter.state == Sprite.State.Riding)
                    {
                        InactiveCharacter.Velocity = new Vector2(-ActiveCharacter.Speed, ActiveCharacter.Velocity.Y);
                    }

                }
                else if (currentKeyboard.IsKeyDown(Keys.Right) || GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed)
                {
                    worldSprites[worldSprites.Count - 1].Width = 0;
                    ActiveCharacter.Velocity = new Vector2(ActiveCharacter.Speed, ActiveCharacter.Velocity.Y);
                    if (InactiveCharacter.state == Sprite.State.Riding)
                    {
                        InactiveCharacter.Velocity = new Vector2(ActiveCharacter.Speed, ActiveCharacter.Velocity.Y);
                    }
                }
                else
                    ActiveCharacter.Velocity = new Vector2(0, ActiveCharacter.Velocity.Y);

                //Switch active characters
                if ((currentKeyboard.IsKeyDown(Keys.RightShift) || currentKeyboard.IsKeyDown(Keys.LeftShift) || GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Pressed) && !check)
                {
                    worldSprites[worldSprites.Count - 1].Width = 0;
                    //InactiveCharacter.state = previousState;
                    Sprite temp = ActiveCharacter;
                    ActiveCharacter = InactiveCharacter;
                    InactiveCharacter = temp;
                    check = true;
                    level.PlayerIcon.ChangeImage();
                    //InactiveCharacter.state = Sprite.State.Default;
                    bunny = !bunny;
                }
                else if (currentKeyboard.IsKeyUp(Keys.RightShift) && currentKeyboard.IsKeyUp(Keys.LeftShift) && GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Released)
                {
                    check = false;
                }
                if ((currentKeyboard.IsKeyDown(Keys.Up) || GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed))
                {
                    worldSprites[worldSprites.Count - 1].Width = 0;
                    if (ActiveCharacter.state == Sprite.State.Swimming)
                    {
                        ActiveCharacter.Velocity += new Vector2(0, -ActiveCharacter.Speed);
                    }
                }
                if ((currentKeyboard.IsKeyDown(Keys.Down) || GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed))
                {
                    worldSprites[worldSprites.Count - 1].Width = 0;

                    if (ActiveCharacter.state == Sprite.State.Swimming)
                    {
                        ActiveCharacter.Velocity += new Vector2(0, ActiveCharacter.Speed);
                    }
                }
                //Vertical position change



                if ((currentKeyboard.IsKeyDown(Keys.Space) || GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed) && (ActiveCharacter.state == Sprite.State.Default || ActiveCharacter.state == Sprite.State.Riding))
                {
                    worldSprites[worldSprites.Count - 1].Width = 0;

                    if (bunny)
                    {
                        sounds[0].Play();
                    }
                    else
                    {
                        sounds[1].Play();
                    }
                    ActiveCharacter.state = Sprite.State.Airbourne;
                    ActiveCharacter.Velocity -= new Vector2(0, ActiveCharacter.jump);
                }
                if (InactiveCharacter.state == Sprite.State.Riding)
                {
                    InactiveCharacter.Velocity = ActiveCharacter.Velocity;
                }
                if (ActiveCharacter.state == Sprite.State.Riding)
                {
                    ActiveCharacter.Velocity = new Vector2(ActiveCharacter.Velocity.X, InactiveCharacter.Velocity.Y);
                }

                // determine sprite animation
                if (currentKeyboard.IsKeyDown(Keys.Left) || GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed && ActiveCharacter.state != Sprite.State.Airbourne)
                {
                    // turn left
                    if (bunny)
                    {
                        if (ActiveCharacter.currentFrame == 1 && sum.Milliseconds > 100)
                        {
                            ActiveCharacter.currentFrame = 2;
                            sum = TimeSpan.Zero;
                        }
                        else if (sum.Milliseconds > 100)
                        {
                            ActiveCharacter.currentFrame = 1;
                            sum = TimeSpan.Zero;
                        }
                    }
                    else
                    {
                        if (ActiveCharacter.currentFrame == 3 && sum.Milliseconds > 100)
                        {
                            ActiveCharacter.currentFrame = 2;
                            sum = TimeSpan.Zero;
                        }
                        else if (sum.Milliseconds > 100)
                        {
                            ActiveCharacter.currentFrame = 3;
                            sum = TimeSpan.Zero;
                        }
                    }
                }
                else if (currentKeyboard.IsKeyDown(Keys.Right) || GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed && ActiveCharacter.state != Sprite.State.Airbourne)
                {
                    // turn right
                    if (bunny)
                    {
                        if (ActiveCharacter.currentFrame == 4 && sum.Milliseconds > 100)
                        {
                            ActiveCharacter.currentFrame = 3;
                            sum = TimeSpan.Zero;
                        }
                        else if (sum.Milliseconds > 100)
                        {
                            ActiveCharacter.currentFrame = 4;
                            sum = TimeSpan.Zero;
                        }

                    }
                    else
                    {
                        if (ActiveCharacter.currentFrame == 0 && sum.Milliseconds > 100)
                        {
                            ActiveCharacter.currentFrame = 1;
                            sum = TimeSpan.Zero;
                        }
                        else if (sum.Milliseconds > 100)
                        {
                            ActiveCharacter.currentFrame = 0;
                            sum = TimeSpan.Zero;
                        }
                    }
                }
                if (ActiveCharacter.state == Sprite.State.Airbourne) // jumping
                {
                    // jump
                    if (bunny)
                    {
                        if (ActiveCharacter.currentFrame == 4 || ActiveCharacter.currentFrame == 3 || ActiveCharacter.currentFrame == 5)
                        {
                            ActiveCharacter.currentFrame = 5;
                        }
                        else
                        {
                            ActiveCharacter.currentFrame = 0;
                        }
                    }
                    else
                    {
                        if (ActiveCharacter.currentFrame == 0 || ActiveCharacter.currentFrame == 1 || ActiveCharacter.currentFrame == 4)
                        {
                            ActiveCharacter.currentFrame = 4;
                        }
                        else
                        {
                            ActiveCharacter.currentFrame = 7;
                        }
                    }
                }
                if (ActiveCharacter.state != Sprite.State.Airbourne)
                {
                    // land from jump
                    if (bunny)
                    {
                        if (ActiveCharacter.currentFrame == 5)
                        {
                            ActiveCharacter.currentFrame = 3;
                        }
                        else if (ActiveCharacter.currentFrame == 0)
                        {
                            ActiveCharacter.currentFrame = 1;
                        }
                    }
                    else
                    {
                        if (ActiveCharacter.currentFrame == 4)
                        {
                            ActiveCharacter.currentFrame = 0;
                        }
                        else if (ActiveCharacter.currentFrame == 7)
                        {
                            ActiveCharacter.currentFrame = 3;
                        }
                    }
                }
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
