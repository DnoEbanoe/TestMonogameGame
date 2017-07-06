using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TestGame.Model;
using TestGame.Model.Base;
using TestGame.Model.GameElements.Obstacle;
using TestGame.Model.Player;

namespace TestGame
{
    public class Game1 : Game
    {
        private SceneManager SceneManager { get; set; } = new SceneManager();
        private Player Player { get; set; }
        public Game1()
        {
            SceneManager.GraphicsDeviceManager  = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            Player = new Player(){SceneManager = SceneManager, Size = new MyPoint(18,31), Tags = new List<string>(new []{"Player"})};
            Player.Show();


            base.Initialize();
        }
        protected override void LoadContent()
        {
            SceneManager.SpriteBatch =  new SpriteBatch(GraphicsDevice);
            Player.Texture =  Content.Load<Texture2D>("tank18_31");
            Player.BulletTexture = Content.Load<Texture2D>("bullet9_23");
            new Obstacle
            {
                Texture = Content.Load<Texture2D>("obstacle32_5"),
                Position = new MyPoint(200, 50),
                Size = new MyPoint(32, 5),
                SceneManager = SceneManager,
                Tags = new List<string>(new[] { "obstacle" })
            }.Show();
        }
        protected override void Update(GameTime gameTime)
        {
            SceneManager.UpdateTime = gameTime;
            SceneManager.KeyboardState = Keyboard.GetState();
            SceneManager.MouseState = Mouse.GetState(Window);
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            for (var index = 0; index < SceneManager.Elements.Count; index++)
            {
                var element = SceneManager.Elements[index];
                element.Update();
            }
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            SceneManager.DrowTime = gameTime;
            GraphicsDevice.Clear(Color.White);
            SceneManager.SpriteBatch.Begin();

            for (var index = 0; index < SceneManager.Elements.Count; index++)
            {
                var element = SceneManager.Elements[index];
                element.Draw();
            }

            SceneManager.SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
