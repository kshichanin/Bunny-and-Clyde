using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
namespace Bunny_and_Clyde
{
    interface Gravity
    {
        bool isAirbourne();
        Vector2 Velocity { get; set; }


    }
}
