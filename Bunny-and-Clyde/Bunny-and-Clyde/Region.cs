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
    class Region : Sprite
    {
        public Region(float initialX, float initialY, int width, int height)
            : base("blank", initialX, initialY, width, height)
        {
        }
    }
}
