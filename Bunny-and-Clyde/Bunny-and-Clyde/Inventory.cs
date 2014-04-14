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
        public void removeItem(Sprite item)
        {
            this.items.Remove(item);
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
        public bool containsKey(Color c)
        {
            foreach (Item i in items)
            {
                if (i.GetType() == typeof(Key))
                {
                    Key k = (Key)i;
                    if (k.color == c)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}