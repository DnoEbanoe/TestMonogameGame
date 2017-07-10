using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using Microsoft.Xna.Framework.Graphics;

namespace TestGame.Animation
{
    class Animator
    {
        public List<AnimationFrame> Frames { get; set; }
        System.Timers.Timer Timer = new Timer();
       
        private int currentFrame;
        public event Action<AnimationFrame> StartFrame;

        public void Start()
        {
            var firstAnim = Frames.FirstOrDefault();
            if (firstAnim == null)
                return;
            Timer.Interval = firstAnim.TimeStart.Milliseconds;
            Timer.Elapsed += TimerOnElapsed;
            Timer.Start();
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            if (currentFrame > Frames.Count)
                currentFrame = 0;
            Timer.Interval = 
                currentFrame + 1 > Frames.Count
                    ? Frames.First().TimeStart.Milliseconds
                    : Frames[currentFrame + 1].TimeStart.Milliseconds;
            OnStartFrame(Frames[currentFrame]);
        }

        public void Stop()
        {
            Timer.Stop();
        }
        protected virtual void OnStartFrame(AnimationFrame obj)
        {
            StartFrame?.Invoke(obj);
        }
    }
}
