using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame_Project1.Content.Sprites;
using System;
using System.Diagnostics;

namespace Project1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch Screen;
        player Player1;
        player Player2;
        Ball ball;
        Random random;
        SpriteFont font;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Player1 = new player(100);
            Player2 = new player(900);
            ball = new Ball(450, 450);
            random = new Random();
 
            ball.Start(random.Next(1, 4));

            base.Initialize();
            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = 1000;
            _graphics.PreferredBackBufferHeight = 700;
            _graphics.ApplyChanges();
        }

        protected override void LoadContent()
        {
            Screen = new SpriteBatch(GraphicsDevice);
            Player1.image = Content.Load<Texture2D>("paddle");
            Player2.image = Content.Load<Texture2D>("paddle");
            ball.image = Content.Load<Texture2D>("ball");
            font = Content.Load<SpriteFont>("Font");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            Mouse.GetState();
            // TODO: Add your update logic here
            Player1.Update(gameTime, Keys.W, Keys.S);
            Player2.Update(gameTime, Keys.Up, Keys.Down);
            ball.Update(gameTime, Player1.Rect, Player2.Rect);
            if (ball.Position.X >= 1100)
            {
                if (!Player2.win)
                {
                    ball.Start(random.Next(1, 4));
                    Player1.Score += 1;
                }
            }
            else if (ball.Position.X <= 0)
            {
                if (!Player1.win)
                {
                    ball.Start(random.Next(1, 4));
                    Player2.Score += 1;
                }
            }
            if (Player1.Score == 3) { Player1.win = true; }
            if (Player2.Score == 3) { Player2.win = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                if (Player1.win || Player2.win)
                {
                    Player1.Score = 0;
                    Player2.Score = 0;
                    Player1.win = false;
                    Player2.win = false;
                    ball.Start(random.Next(1, 4));
                }
            }
            base.Update(gameTime);
            Debug.WriteLine(Player1.Score);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            Screen.Begin();
            Screen.Draw(Player1.image, Player1.Rect, Color.White);
            Screen.Draw(Player2.image, Player2.Rect, Color.White);
            Screen.Draw(ball.image, ball.Rect, Color.White);
            if (!Player1.win) { Screen.DrawString(font, Convert.ToString(Player1.Score), new Vector2(100, 50), Color.White); }
            if (!Player2.win) { Screen.DrawString(font, Convert.ToString(Player2.Score), new Vector2(900, 50), Color.White); }
            if (Player1.win) { Screen.DrawString(font, "Player 1 has won!", new Vector2(100, 50), Color.White); }
            if (Player2.win) { Screen.DrawString(font, "Player 2 has won!", new Vector2(700, 50), Color.White); }
            if (Player1.win  || Player2.win) { Screen.DrawString(font, "Press SPACE to restart", new Vector2(360, 500), Color.White); }
            Screen.End();
            base.Draw(gameTime);
        }
    }
}
