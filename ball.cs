using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame_Project1.Content.Sprites;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Project1
{
    class Ball : sprite
    {
        float xSpeed = -3;
        float ySpeed = -3;
        Random r;

        internal Ball(int x, int y)
        {
            Position.X = x;
            Position.Y = y;
        }

        public void Start(int var)
        {
            Position.X = 500;
            Position.Y = 450;
            switch (var)
            {
                case 1:
                    xSpeed = -3;
                    ySpeed = -3;
                    break;
                case 2:
                    xSpeed = -3;
                    ySpeed = 3;
                    break;
                case 3:
                    xSpeed = 3;
                    ySpeed = -3;
                    break;
                case 4:
                    xSpeed = 3;
                    ySpeed = 3;
                    break;
            }
        }

        public void Update(GameTime gameTime, Rectangle p1, Rectangle p2)
        {
            r = new Random();
            Position.X += xSpeed;
            Position.Y += ySpeed;
            if (Position.Y <= 0)
            {
               if (ySpeed < 0)
               {
                    ySpeed = r.Next(2, 6);
               }
            }
            if (Position.Y >= 690)
            {
                if (ySpeed > 0)
                {
                    ySpeed = r.Next(-6, -2);
                }
            }
            if (Rect.Intersects(p1))
            {
                if (xSpeed < 0)
                {
                    xSpeed = r.Next(6, 10);
                }
            }
            if (Rect.Intersects(p2))
            {
                if (xSpeed > 0)
                {
                    xSpeed = r.Next(-10, -6);
                }
            }
            base.Update(gameTime);
        }
    }
}
