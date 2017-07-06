using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGame.Model
{
    class MyPoint
    {
        public static readonly MyPoint Zero = new MyPoint{X = 0, Y = 0};
        public float X { get; set; }
        public float Y { get; set; }

        public MyPoint()
        {
            
        }
        public MyPoint(float x, float y)
        {
            X = x;
            Y = y;
        }

        public static MyPoint operator -(MyPoint point1, MyPoint point2)
        {
            return new MyPoint(point1.X - point2.X, point1.X - point2.X);
        }
    }
}
