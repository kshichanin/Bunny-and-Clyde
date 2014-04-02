using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Bunny_and_Clyde
{
    class Inventory : Sprite 
    {
        public List<Sprite> items{get; private set;}
        public Inventory(float initialX, float initialY, int width, int height)
            : base("inventory", initialX, initialY, width, height)
        {
            this.items = new List<Sprite>(); 
        }
        public void addItem(Sprite item)
        {
            this.items.Add(item);
        }
        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
            Vector2 nextItemPosition = this.Position;
            foreach (Sprite s in items)
            {
                s.Position = nextItemPosition;
                s.Draw(sb);
                nextItemPosition += new Vector2(50, 0);
            }
        }
    }
}