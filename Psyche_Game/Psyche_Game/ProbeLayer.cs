using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using CocosSharp;

namespace Psyche_Game
{
    class ProbeLayer: CCLayer
    {
        CCSprite probeSprite;
        public ProbeLayer()
        {
            // "paddle" refers to the paddle.png image
            Debug.WriteLine("Sprite");
            probeSprite = new CCSprite("psyche_elements_large_renders02");
            probeSprite.PositionX = 100;
            probeSprite.PositionY = 100;
            AddChild(probeSprite);
        }
        protected override void AddedToScene()
        {
            base.AddedToScene();
            // Use the bounds to layout the positioning of the drawable assets
            CCRect bounds = VisibleBoundsWorldspace;
            // Register for touch events
            var touchListener = new CCEventListenerTouchAllAtOnce();
            touchListener.OnTouchesEnded = OnTouchesEnded;
            AddEventListener(touchListener, this);
        }
        void OnTouchesEnded(List<CCTouch> touches, CCEvent touchEvent)
        {
            if (touches.Count > 0)
            {
                // Perform touch handling here
            }
        }
    }
}
