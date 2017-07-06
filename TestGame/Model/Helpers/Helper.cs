using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using TestGame.Model.Base;

namespace TestGame.Model.Helpers
{
    static class Helper
    {
        public static Vector2 ToVector2(this MyPoint point)
        {
            return new Vector2(point.X, point.Y);
        }

        public static MyPoint CenterPosition(this GameObject2D obj)
        {
            return new MyPoint(obj.Position.X + obj.Size.X / 2, obj.Position.Y + obj.Size.Y / 2);
        }
        
    }
}
