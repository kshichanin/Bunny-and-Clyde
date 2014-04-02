using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
namespace Bunny_and_Clyde
{
    enum Action { BunnyMoveLeft, BunnyMoveRight, BunnyJump, ClydeMoveLeft, ClydeMoveRight, ClydeJump }
    class Physics
    {
        private Bunny bunny;
        private Clyde clyde;
        const float gravityStrength = 0.6f;
        const float buoyancy = 0.1f;
        List<Sprite> platforms;
        List<Gravity> worldObjects;
        public Physics()
        {
            worldObjects = new List<Gravity>();
        }
        public Physics(List<Gravity> objects)
        {
            worldObjects = objects;
        }
       /* public void Update2(GameTime time, List<Action> actions)
        {
            Vector2 bunnyHvec = new Vector2(0, 0);
            Vector2 clydeHvec = new Vector2(0, 0);

            if (actions.Contains(Action.BunnyMoveLeft))
            {
                bunnyHvec.X = bunny.Speed;
            }
            if(actions.Contains (Action.BunnyMoveLeft)){
                bunnyHvec.X = -bunny.Speed ;
            }
            moveSprite(bunny, bunnyHvec);
            if(actions.Contains(Action.ClydeMoveLeft){
            
            }
        }*/
        public void moveSprite(Sprite sprite, Vector2 velocity)
        {
            if (checkPlatformCollision(sprite.testBox(velocity.X, velocity.Y)))
            {
                resolveCollision(sprite, velocity);
            }
            else
            {
                sprite.Position += velocity;
            }
        }
        public void resolveCollision(Sprite s, Vector2 velocity)
        {
            float time = 0.5f;
            int i = 1;
            bool collides = true;
            while (i <= 5 || collides)
            {
                collides = checkPlatformCollision(s.testBox(velocity.X * time, velocity.Y * time));
                i++;
                if (collides)
                {
                    time -= 1 / (2 ^ i);
                }
                else
                {
                    time += 1 / (2 ^ i);
                }

            }
            s.Position += velocity * time;
        }
        public bool checkPlatformCollision(Rectangle r)
        {
            foreach (Sprite s in platforms)
            {
                if (r.Intersects(s.HitBox))
                {
                    return true;
                }
            }
            return false;
        }//
        public void Update(GameTime time)
        {
            foreach (Gravity worldObject in worldObjects)
            {
                if (worldObject.state != Sprite.State.Swimming )
                {
                    worldObject.Velocity += new Vector2(0, gravityStrength);
                }
                if (worldObject.state == Sprite.State.Swimming)
                {
                    worldObject.Velocity -= new Vector2(0, buoyancy);
                }
            }
        }
        public void Remove(Gravity g)
        {
            worldObjects.Remove(g);
        }
        public void Add(Gravity g)
        {
            worldObjects.Add(g);
        }
    }
}
