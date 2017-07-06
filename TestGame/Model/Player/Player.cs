using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using TestGame.Model.Base;
using TestGame.Model.Enums;

namespace TestGame.Model.Player
{
    class Player: GameObject2D
    {
        public float Spead { get; set; } = 0.1f;
        public override void Update()
        {
            var keyboardState = this.SceneManager.KeyboardState;
            if (keyboardState.IsKeyDown(Keys.W))
                Run(Side.Up);
            if (keyboardState.IsKeyDown(Keys.S))
                Run(Side.Down);
            if (keyboardState.IsKeyDown(Keys.A))
                Run(Side.Left);
            if (keyboardState.IsKeyDown(Keys.D))
                Run(Side.Right);

            base.Update();
        }

        public void Run(Side side)
        {
            if (side == Side.Up)
            {
                this.Position.Y -= Spead * SceneManager.UpdateTime.ElapsedGameTime.Milliseconds;
            }
            else if (side == Side.Down)
            {
                this.Position.Y += Spead * this.SceneManager.UpdateTime.ElapsedGameTime.Milliseconds;
            }
            else if (side == Side.Left)
            {
                this.Position.X -= Spead * this.SceneManager.UpdateTime.ElapsedGameTime.Milliseconds;
            }
            else if (side == Side.Right)
            {
                this.Position.X += Spead * this.SceneManager.UpdateTime.ElapsedGameTime.Milliseconds;
            }
        }
    }
}
