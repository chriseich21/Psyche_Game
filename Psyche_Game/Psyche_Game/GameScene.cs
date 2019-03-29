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
            _layer = new ProbeLayer();
            this.AddLayer(_layer);
        }
    }
}
