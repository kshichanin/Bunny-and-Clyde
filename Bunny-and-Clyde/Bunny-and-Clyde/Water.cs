using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
namespace Bunny_and_Clyde
{//
    class Water : Item
    {
        private Level level;
        public SoundEffect soundeffect { get; set; }
        public Water(float x, float y, int width, int height, Level l) :
            base("blank", x, y, width, height)
        {
            this.level = l;
        }
        public override void activate(Sprite collider)
        {
            if (collider.GetType() == typeof(Clyde))
            {
                if (collider.state == State.Airbourne) { soundeffect.Play(); }

                    collider.Velocity = Vector2.Zero;
                
                collider.state = State.Swimming;
                
            }
            else if (collider.GetType() == typeof(Bunny))
            {
                if (collider.state == State.Airbourne || collider.state == State.Default) { soundeffect.Play(); }
                Bunny bunny = (Bunny)collider;
                level.bunnydead = true;
                
                bunny.die.Width = bunny.mapwidth;
                bunny.Position = bunny.SpawnPoint;
                bunny.Velocity = Vector2.Zero;
            }
        }
    }

}
