using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
namespace Bunny_and_Clyde
{
    class Key : Item 
    {
        public Color color { get; private set; }
        Level level;
        public Vector2 SpawnPoint { get; private set; }
        public SoundEffect soundeffect { get; set; }
        public Key(Color c, Level l, float x, float y, int width, int height) :
            base("key_tile", x, y, width, height)
        {
            this.SpawnPoint = new Vector2(x, y);
            color = c;
            level = l;
        }
        public override void activate(Sprite s)
        {
            if(!level .inventory .items .Contains (this)){
                //level.items.Remove(this);
                level.inventory.addItem(this);
                soundeffect.Play();
            }
        }
        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(image, new Rectangle((int)Position.X, (int)Position.Y, Width, Height), this.color );
        }
    }
}
