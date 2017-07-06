using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TestGame.Model.Base
{
    abstract class GameObject2D
    {
        public SceneManager SceneManager { get; set; }
        public Texture2D Texture { get; set; }
		public Guid Id { get; set; }
        public Vector2 Position
        {
            get { return _position; }
            set
            {
                _position = value;
                _sourseRectange = new Rectangle((int) Position.X, (int) Position.Y,(int) Size.X, (int) Size.Y);
            }
        }
        public float Rotation { get; set; }
        public bool IsVisable { get; set; }
        public Vector2 Size
        {
            get { return _size; }
            set
            {
                _size = value;
                _sourseRectange = new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
            }
        }
        public List<string> Tags { get; set; }

        private Rectangle? _sourseRectange = null;
        private Vector2 _size;
        private Vector2 _position;

        public GameObject2D(): this(null, null, Vector2.Zero, 0f)
        {

        }
        public GameObject2D(SceneManager sceneManager, Texture2D texture, Vector2 position, float rotation)
        {
            SceneManager = sceneManager;
            Texture = texture;
            Position = position;
            Rotation = rotation;
        }
        public virtual void Draw()
        {
            if(!IsVisable)
                return;
            SceneManager.SpriteBatch.Draw(Texture, Position, _sourseRectange, Color.White, Rotation, Vector2.One, 1f, SpriteEffects.None, 1f);
        }

        public virtual void Update()
        {
            if(!IsVisable)
                return;
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
        public virtual void Destroy()
        {
            SceneManager.Elements.Remove(this);
        }
    }
}
