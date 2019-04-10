using System;
using System.Collections.Generic;
using System.Text;
using CocosSharp;

namespace Psyche_Game
{
    class Asteroid : CCNode
    {
        public CCSprite sprite;

        public float VelocityX
        {
            get;
            set;
        }

        public float VelocityY
        {
            get;
            set;
        }
        public CCSprite GetSprite()
        {
            return sprite;
        }
        public Asteroid() : base()
        {
            String[] arr = new String[3] { "asteroid1.png", "asteroid2.png", "asteroid3.png" };
            Random rnd = new Random();
            int index = rnd.Next(arr.Length);

            sprite = new CCSprite(arr[index]);
            this.AddChild(sprite);
            this.Schedule(ApplyVelocity);
        }

        void ApplyVelocity(float time)
        {
            PositionX += VelocityX * time;
            PositionY += VelocityY * time;
        }
    }
}
