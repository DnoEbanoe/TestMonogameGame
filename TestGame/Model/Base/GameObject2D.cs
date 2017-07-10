using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TestGame.Model.Helpers;

namespace TestGame.Model.Base
{
    internal abstract class GameObject2D
    {
        public SceneManager SceneManager { get; set; }
        public Texture2D Texture { get; set; }
		public Guid Id { get; set; }
        public MyPoint Position
        {
            get { return _position; }
            set
            {
                _position = value;
                _sourseRectange = new Rectangle((int) Position.X, (int) Position.Y,(int) Size.X, (int) Size.Y);
            }
        }
        public float Rotation { get; set; }
        public bool IsVisable { get; private set; } = true;
        public MyPoint Size
        {
            get { return _size; }
            set
            {
                _size = value;
                _sourseRectange = new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
            }
        }
        public List<string> Tags { get; set; }

        private Rectangle? _sourseRectange = new Rectangle();
        private MyPoint _size = MyPoint.Zero;
        private MyPoint _position = MyPoint.Zero;

        public GameObject2D(): this(null, null, MyPoint.Zero, 0f)
        {

        }
        public GameObject2D(SceneManager sceneManager, Texture2D texture, MyPoint position, float rotation)
        {
            SceneManager = sceneManager;
            Texture = texture;
            Position = position;
            Rotation = rotation;
        }
        public virtual void Draw()
        {
            SceneManager.SpriteBatch.Draw(Texture, Position.ToVector2(), _sourseRectange, Color.White, Rotation, Vector2.One, 1f, SpriteEffects.None, 1f);
        }

        public virtual void Update()
        {
        }

        public virtual bool IsCollide(string tag)
        {
            var elements = SceneManager.Elements.Where(obj => obj.IsVisable 
            && obj.Tags != null 
            && obj.Tags.Contains(tag));

            foreach (var gameObject2D in elements)
            {
                Rectangle obj1 = new Rectangle((int)Position.X,
                    (int)Position.Y, (int)Size.X, (int)Size.Y);
                Rectangle obj2 = new Rectangle((int)gameObject2D.Position.X,
                    (int)gameObject2D.Position.Y, (int) gameObject2D.Size.X, (int) gameObject2D.Size.Y);
                if (obj1.Intersects(obj2))
                    return true;
            }

            return false;
        }

        public void Show()
        {
            SceneManager.Elements.Add(this);
        }

        public void Hide()
        {
            SceneManager.Elements.Remove(this);
        }
        public virtual void Destroy()
        {
            SceneManager.Elements.Remove(this);
        }
    }
}
