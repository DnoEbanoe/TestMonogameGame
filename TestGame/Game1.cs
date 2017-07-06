using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TestGame.Model;
using TestGame.Model.Base;
using TestGame.Model.Player;

namespace TestGame
{
    public class Game1 : Game
    {
        private SceneManager SceneManager { get; set; } = new SceneManager();
        private GameObject2D _ball { get; set; }
        public Game1()
        {
            SceneManager.GraphicsDeviceManager  = new GraphicsDeviceManager(this);
            //graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            _ball = new Player(){SceneManager = SceneManager, Size = new Vector2(32,32), Tags = new List<string>(new []{"Player"})};
            
            base.Initialize();
        }
        protected override void LoadContent()
        {
            SceneManager.SpriteBatch =  new SpriteBatch(GraphicsDevice);
            _ball.Texture =  Content.Load<Texture2D>("ball32");
        }
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            SceneManager.UpdateTime = gameTime;
            SceneManager.KeyboardState = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
           
            _ball.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            SceneManager.DrowTime = gameTime;
            GraphicsDevice.Clear(Color.White);
            SceneManager.SpriteBatch.Begin();
            
            _ball.Draw();

            SceneManager.SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
