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
    class GameGlobals
    {
        public static int WINDOW_HEIGHT = 640;
        public static int WINDOW_WIDTH = 1120;

        public static int BUNNY_MOVE_SPEED = 5;
        public static int CLYDE_MOVE_SPEED = 5;

        public static int OFFSCREEN_X = -500;
        public static int OFFSCREEN_Y = 0;
    }
}
