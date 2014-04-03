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
        public SoundEffect soundeffect { get; set; }
        public Water(float x, float y, int width, int height) :
            base("blank", x, y, width, height)
        {

        }
        public override void activate(Sprite collider)
        {
            if (collider.GetType() == typeof(Clyde))
            {
                if (collider.state == State.Airbourne) { soundeffect.Play(); }
                collider.state = State.Swimming;
                collider.Velocity = Vector2.Zero;
            }
            else if (collider.GetType() == typeof(Bunny))
            {
                if (collider.state == State.Airbourne || collider.state == State.Default) { soundeffect.Play(); }
                Bunny bunny = (Bunny)collider;
                bunny.die.Width = 300;
                bunny.Position = bunny.SpawnPoint;
                bunny.Velocity = Vector2.Zero;
            }
        }
    }

}
