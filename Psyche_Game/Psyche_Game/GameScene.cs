using System;
using System.Collections.Generic;
using System.Text;
using CocosSharp;

namespace Psyche_Game
{
    public class GameScene : CCScene
    {
        CCLayer _layer;

        public GameScene(CCGameView gameView) : base(gameView)
        {
            _layer = new CCLayer();
            this.AddLayer(_layer);
        }

        public void DrawParticle(CCPoint point)
        {
            var explosion = new CCParticleExplosion(CCPoint.Zero)
            {
                TotalParticles = 10,
                StartColor = new CCColor4F(CCColor3B.White),
                EndColor = new CCColor4F(CCColor3B.Black),
                Position = new CCPoint(point.X / App.Density, App.Height - point.Y / App.Density)
            };

            _layer.AddChild(explosion);
            var back = new CCSprite("psyche_launchpad.png");
            AddChild(back);

        }
    }
}
