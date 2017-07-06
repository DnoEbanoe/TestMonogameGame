using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TestGame.Model.Base;
using TestGame.Model.Enums;
using TestGame.Model.Helpers;
using TestGame.Model.Weapons;

namespace TestGame.Model.Player
{
    class Player: GameObject2D
    {
        public Texture2D BulletTexture { get; set; }
        public List<Bullet> Bullets { get; set; } = new List<Bullet>();
        public float Spead { get; set; } = 0.1f;
        public float RotationSpeed { get; set; } = 0.0005f;
        public override void Update()
        {
            var keyboardState = this.SceneManager.KeyboardState;
            var mouseState = this.SceneManager.MouseState;
            if (keyboardState.IsKeyDown(Keys.W))
                Run(Side.Up);
            if (keyboardState.IsKeyDown(Keys.S))
                Run(Side.Down);
            if (keyboardState.IsKeyDown(Keys.A))
                //Run(Side.Left);
                Rotation -= RotationSpeed * SceneManager.UpdateTime.ElapsedGameTime.Milliseconds;
            if (keyboardState.IsKeyDown(Keys.D))
                //Run(Side.Right);
                Rotation += RotationSpeed * SceneManager.UpdateTime.ElapsedGameTime.Milliseconds;
            //if (keyboardState.IsKeyDown(Keys.W) && keyboardState.IsKeyDown(Keys.A))
            //    this.Rotation += 1;
            if (mouseState.LeftButton == ButtonState.Pressed 
                && Bullets.FirstOrDefault(bullet => bullet.TimeStart > SceneManager.UpdateTime.TotalGameTime.Subtract(TimeSpan.FromSeconds(0.8))) == null)
                Gun();
            base.Update();
        }

        public override void Draw()
        {
            base.Draw();
        }

        public void Gun()
        {
            var bullet = new Bullet(this.SceneManager.UpdateTime.TotalGameTime)
            {
                Texture = BulletTexture,
                SceneManager = this.SceneManager,
                Position = this.CenterPosition(),
                Size = new MyPoint(9, 23)
            };
            bullet.Position.X -= (bullet.Size.X / 2);
            bullet.Show();
            Bullets.Add(bullet);
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
