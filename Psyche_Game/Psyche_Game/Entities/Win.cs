using System;
using System.Collections.Generic;
using System.Text;
using CocosSharp;

namespace Psyche_Game
{
    class Win : CCNode
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

        public Win() : base()
        {
           // sprite = new CCSprite("win.png");
            this.AddChild(sprite);
            
        }

    }
}
