using System;
using System.Collections.Generic;
using System.Text;

namespace Psyche_Game
{
    class AsteroidFactory
    {
        static Lazy<AsteroidFactory> self =
            new Lazy<AsteroidFactory>(() => new AsteroidFactory());

        // simple singleton implementation
        public static AsteroidFactory Self
        {
            get
            {
                return self.Value;
            }
        }

        public event Action<Asteroid> AsteroidCreated;

        private AsteroidFactory()
        {

        }

        public Asteroid CreateNew()
        {
            Asteroid newAsteroid = new Asteroid();

            if (AsteroidCreated != null)
            {
                AsteroidCreated(newAsteroid);
            }

            return newAsteroid;
        }
    }
}
