#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using TiledSharp;
#endregion

namespace Bunny_and_Clyde
{
    class TiledTest
    {
        public TiledTest()
        {
            TmxMap map = new TmxMap("Content\\lvl_1.tmx");

            //foreach (TmxObjectGroup.TmxObject o in map.ObjectGroups["objects"].Objects)
            //{
            //    //Console.WriteLine("x:" + o.X);
            //    //Console.WriteLine("y:" + o.Y);

            //}

            Console.WriteLine(map.Tilesets["ground_tile"].Image.Source);
        }
    }
}
