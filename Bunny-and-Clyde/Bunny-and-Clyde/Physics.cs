﻿using System;
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
    class Physics
    {
        const float gravityStrength = 1.0f;
        List<Gravity> worldObjects;
        public Physics(List<Gravity> objects)
        {
            worldObjects = objects;
        }
        public void Update(GameTime time)
        {
            foreach (Gravity worldObject in worldObjects)
            {
                if (worldObject.isAirbourne())
                {
                    worldObject.Velocity -= gravityStrength;
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
