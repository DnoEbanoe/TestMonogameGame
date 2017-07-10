using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace TestGame.Animation
{
    class AnimationFrame
    {
        public Texture2D Texture { get; set; }
        public TimeSpan TimeStart { get; set; }
    }
}
