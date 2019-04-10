using System;
using System.Collections.Generic;
using System.Text;
using CocosSharp;

namespace Psyche_Game
{
    class Psyche : CCNode
    {
        //create a sprite
        CCSprite sprite;
        //getter and setters for velocity value
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
        //create and ad dthe psyche sprite
        public Psyche() : base()
        {
            sprite = new CCSprite("psycheAsteroid.png");
            this.AddChild(sprite);
            this.Schedule(ApplyVelocity);
        }
        //aply the vleicoty to the psyche sprite
        void ApplyVelocity(float time)
        {
            if (PositionY > 200)
            {
                PositionX += VelocityX * time;
                PositionY += VelocityY * time;
            }
        }
    }
}
