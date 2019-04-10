using System;
using System.Collections.Generic;
using System.Text;
using CocosSharp;

namespace Psyche_Game
{
    class Lose : CCNode
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
        public Lose() : base()
        {
            sprite = new CCSprite("lose.png");
            this.AddChild(sprite);
            //this.Schedule(ApplyVelocity);
        }

        void ApplyVelocity(float time)
        {
            PositionX += VelocityX * time;
            PositionY += VelocityY * time;
        }


    }
}
