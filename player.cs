using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Project1.Content.Sprites
{
    class player : sprite
    {
        public int Score;
        public bool win;
        public player(int x)
        {
            Position = new Microsoft.Xna.Framework.Vector2 (x, 300);
            Score = 0;
            win = false;
        }

        public void Update(GameTime gameTime, Keys up, Keys down)
        {
            float[] movement = { 0, 0 };
            base.Update(gameTime);
            var Kstate = Keyboard.GetState();

            if (Kstate.IsKeyDown(up) && Position.Y >= 0) { movement[0] = 1; }
            else { movement[0] = 0;}
            if (Kstate.IsKeyDown(down) && Position.Y <= 624) { movement[1] = 1;}
            else { movement[1] = 0;}
            Position.Y += ((movement[1] - movement[0]) / 2) * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        }

    }
}
