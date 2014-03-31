using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
namespace Bunny_and_Clyde
{
    class CollisionManager
    {
        List<Sprite> solids;
        List<Item> stationaryobjects;
        List<Sprite> movingObjects;
        public void checkItemCollisions(Sprite active) { 
            foreach(Item item in stationaryobjects ){
                if(item.HitBox .Intersects (active .HitBox )){
                    item.activate(active);
                }
            }
        }
        public CollisionManager()
        {
            solids = new List<Sprite>();
            stationaryobjects = new List<Item>();
            movingObjects = new List<Sprite>();
        }
        public CollisionManager(List<Sprite> sld, List<Item> stationary, List<Sprite> moving)
        {
            solids = sld;
            stationaryobjects = stationary;
            movingObjects = moving;
        }
        public void addSolid(Sprite s)
        {
            solids.Add(s);
        }
        public void addStationary(Item s)
        {
            stationaryobjects.Add(s);
        }
        public void addMoving(Sprite s)
        {
            movingObjects.Add(s);
        }
        public void Update()
        {
            foreach (Sprite mover in movingObjects)
            {
                moveSprite(mover);
            }
        }
        public void moveSprite(Sprite sprite)
        {
            Vector2 velocity = sprite.Velocity;
            if (checkPlatformCollision(sprite.testBox(velocity.X, 0)))
            {
                resolveCollision(sprite, new Vector2  (velocity.X, 0));
            }
            else
            {
                sprite.Position += new Vector2 (velocity.X, 0);
            }
            if (checkPlatformCollision(sprite.testBox(0, velocity.Y)))
            {
                resolveCollision(sprite, new Vector2(0,velocity.Y));
                sprite.Velocity = new Vector2(velocity.X, 0);

                Console.WriteLine(sprite.Velocity);
                if (velocity.Y > 0)
                {
                    sprite.state = Sprite.State.Default;
                }
                else
                {

                }

                

            }
            else
            {
                sprite.Position += new Vector2 (0, velocity .Y);
            }
        }
        public void resolveCollision(Sprite s, Vector2 velocity)
        {
            return;
            float time = 0.5f;
            int i = 1;
            bool collides = true;
            while (i <= 5 )
            {
                collides = checkPlatformCollision(s.testBox(velocity.X * time, velocity.Y * time));
                i++;
                if (collides)
                {
                    time -= 1 / (float)Math.Pow (2,i);
                }
                else
                {
                    time += 1 / (float)Math.Pow (2,i);
                }

            }
            if (time == 0.015625f)
            {
                time = 0;
            }
            s.Position += velocity * time;
            s.Speed = s.Speed;
        }
        public bool checkPlatformCollision(Rectangle r)
        {
            foreach (Sprite s in solids)
            {
                if (r.Intersects(s.HitBox))
                {
                    return true;
                }
            }
            if (r.X < 0 || r.X + r.Width > GameGlobals.WINDOW_WIDTH) return true;
            return false;
        }

    }
}
