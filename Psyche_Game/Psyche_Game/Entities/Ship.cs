using System;
using System.Collections.Generic;
using System.Text;
using CocosSharp;

namespace Psyche_Game
{
    class Ship : CCNode
    {
        CCSprite sprite;

        public Ship() : base()
        {
            sprite = new CCSprite("rocket.png");
            // Center the Sprite in this entity to simplify
            // centering the Ship when it is instantiated
            sprite.Scale = 0.5F;
            sprite.AnchorPoint = CCPoint.AnchorMiddleBottom;
            this.AddChild(sprite);
        }
    }
}
