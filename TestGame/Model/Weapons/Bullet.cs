using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TestGame.Model.Base;
using TestGame.Model.Helpers;

namespace TestGame.Model.Weapons
{
    class Bullet: GameObject2D
    {
        public float Spead { get; set; } = 0.7f;
        public float RemoveTime { get; set; } = 200f;
        public TimeSpan TimeStart { get; set; }
        public override void Update()
        {
            this.Position.Y -= Spead * this.SceneManager.UpdateTime.ElapsedGameTime.Milliseconds;
            if (IsCollide("obstacle"))
            {
                IsVisable = false;
            }
            base.Update();
        }
        

        public Bullet(TimeSpan timeStart)
        {
            TimeStart = timeStart;
        }
        public override void Draw()
        {
            if(!IsVisable)
                return;
            if (TimeStart < SceneManager.UpdateTime.TotalGameTime.Subtract(TimeSpan.FromMilliseconds(RemoveTime)))
                IsVisable = false;
            SceneManager.SpriteBatch.Draw(Texture, Position.ToVector2(), null, Color.White, Rotation, Vector2.Zero, 1f, SpriteEffects.None, 1f);
            
        }
    }
}
