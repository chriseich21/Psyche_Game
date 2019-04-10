using System;
using System.Collections.Generic;
using System.Text;
using CocosSharp;

namespace Psyche_Game
{
    class Asteroid : CCNode
    {
        public CCSprite sprite;
        //geters and steers for the velcitys of our astroids
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
        //creates the sateroids sprite
        public CCSprite GetSprite()
        {
            return sprite;
        }
        //create an asteroid entity with  arandomly asigned picture
        public Asteroid() : base()
        {
            String[] arr = new String[3] { "asteroid1.png", "asteroid2.png", "asteroid3.png" };
            Random rnd = new Random();
            int index = rnd.Next(arr.Length);

            sprite = new CCSprite(arr[index]);
            this.AddChild(sprite);
            this.Schedule(ApplyVelocity);
        }
        //apply the vleocity values given a time value
        void ApplyVelocity(float time)
        {
            PositionX += VelocityX * time;
            PositionY += VelocityY * time;
        }
    }
}
