using System;
using System.Collections.Generic;
using System.Text;
using CocosSharp;

namespace Psyche_Game
{
    class Ship : CCNode
    {
        //instatiate  the sprite
      public CCSprite sprite;
        GameView g;
        //velocity getter sand setters
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
        //creta ethe ship view
        public Ship(GameView gView) : base()
        {
            g = gView;
            sprite = new CCSprite("rocket.png");
            // Center the Sprite in this entity to simplify
            // centering the Ship when it is instantiated
            sprite.Scale = 0.5F;
            sprite.AnchorPoint = CCPoint.AnchorMiddleBottom;
            this.AddChild(sprite);

            Schedule(SeeAsteroid, interval: 1.5f);
            this.Schedule(ApplyVelocity);

            //Schedule(SeePsyche);
        }
        //creat the asteroids
        void SeeAsteroid(float unusedValue)
        {
            Asteroid newAsteroid = AsteroidFactory.Self.CreateNew();
            newAsteroid.PositionX = 200;
            newAsteroid.PositionY = 500;
            newAsteroid.VelocityY = -50;
        }

        void ApplyVelocity(float time)
        {

            if (!((PositionX + VelocityX * time) < 0 || (PositionX + VelocityX * time) > App.Width))
            {
                PositionX += VelocityX * time;
            }
            else
            {
                VelocityX *= -0.1f;
                PositionX += VelocityX * time;
            }

            g.Update();
            /*
            if (!((PositionY + VelocityY * time) < App.Width || (PositionY + VelocityY * time) > App.Width))
            {
                PositionY += VelocityY * time;
            }
            else
            {
                VelocityY *= -1;
                PositionY += VelocityY * time;
            }*/
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
