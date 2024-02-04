using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Project1.Content.Sprites
{
    class sprite
    {
        public Texture2D image;

        public Vector2 Position;

        public bool Dead = false;

        public Rectangle Rect
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, image.Width, image.Height);
            }
        }

        public virtual bool collsion(Rectangle rectangle1, Rectangle rectangle2)
        {
            if (rectangle1.Intersects(rectangle2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public virtual void Update(GameTime gameTime)
        {

        }
    }
}
