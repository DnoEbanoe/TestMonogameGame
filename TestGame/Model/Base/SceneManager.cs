using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TestGame.Model.Base
{
    class SceneManager
    {
        public GameTime DrowTime { get; set; }
        public GameTime UpdateTime { get; set; }
        public SpriteBatch SpriteBatch { get; set; }
        public GraphicsDeviceManager GraphicsDeviceManager { get; set; }
        public KeyboardState KeyboardState { get; set; }
        public MouseState MouseState { get; set; }
        public List<GameObject2D> Elements { get; set; } = new List<GameObject2D>();

    }
}
