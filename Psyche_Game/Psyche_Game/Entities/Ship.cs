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

            Schedule(SeeAsteroid, interval: 1.5f);
            //Schedule(SeePsyche);
        }

        void SeeAsteroid(float unusedValue)
        {
            Asteroid newAsteroid = AsteroidFactory.Self.CreateNew();
            newAsteroid.PositionX = 200;
            newAsteroid.PositionY = 500;
            newAsteroid.VelocityY = -50;
        }
        /*
        void SeePsyche(float unusedValue)
        {
            Psyche newPsyche = new Psyche();
            newPsyche.PositionX = 200;
            newPsyche.PositionY = 500;
            newPsyche.VelocityY = -50;
        }*/
    }
}
