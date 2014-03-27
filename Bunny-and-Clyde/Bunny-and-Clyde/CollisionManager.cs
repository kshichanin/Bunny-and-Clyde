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
        List<Sprite> stationaryobjects;
        List<Sprite> movingObjects;
        public CollisionManager()
        {
            solids = new List<Sprite>();
            stationaryobjects = new List<Sprite>();
            movingObjects = new List<Sprite>();
        }
        public void addSolid(Sprite s)
        {
            solids.Add(s);
        }
        public void addStationary(Sprite s)
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
                resolveCollision(sprite, velocity);
            }
            else
            {
                sprite.Position += velocity;
            }
            if (checkPlatformCollision(sprite.testBox(0, velocity.Y)))
            {
                resolveCollision(sprite, velocity);
                sprite.Velocity = new Vector2(velocity.X, 0);
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
            foreach (Sprite s in solids)
            {
                if (r.Intersects(s.HitBox))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
