using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bunny_and_Clyde
{
    class ClydesBack : Item 
    {
        public Clyde clyde;
        public ClydesBack(Clyde c, float x, float y, int width, int height)
            : base("blank.png", x, y, width, height)
        {
            clyde = c;
        }
        public override void activate(Sprite collider)
        {
            if(!collider.HitBox .Intersects(clyde.HitBox )){
                collider.state = State.Riding;
            }
        }
    }
}
