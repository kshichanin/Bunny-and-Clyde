using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
namespace Bunny_and_Clyde
{
    class Ramp : Item, Gravity
    {
        public SoundEffect soundeffect { get; set; }
        public Ramp(float x, float y, int width, int height)
        :base("gate_block",x,y,width,height)
        {
        }
        public override void activate(Sprite collider)
        {
            //oh well...
            
         //working buy is annoying right now since it plays during every collision   soundeffect.Play();
        }
    }
}
