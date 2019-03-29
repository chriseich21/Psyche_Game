using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CocosSharp;

namespace Psyche_Game
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameView : ContentView
    {
        CCScene _scene;
        CCLayer _layer;
        Ship ship;
        public GameView()
        {
            var sharpView = new CocosSharpView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                ViewCreated = HandleViewCreated
            };
            Content = sharpView;
        }

        void HandleViewCreated(object sender, EventArgs e)
        {
            var ccGView = sender as CCGameView;
            var contentSearchPaths = new List<string>() { "Resources" };
            ccGView.ContentManager.SearchPaths = contentSearchPaths;
            if (ccGView != null)
            {
                ccGView.DesignResolution = new CCSizeI(App.Width, App.Height);
                _scene = new CCScene(ccGView);
                _layer = new CCLayer();
                _scene.AddLayer(_layer);
                ship = new Ship();
                ship.PositionX = 200;
                ship.PositionY = 50;
                _layer.AddChild(ship);
                var touchEvent = new CCEventListenerTouchAllAtOnce();
                touchEvent.OnTouchesEnded = OnTouchesEnded;
                touchEvent.OnTouchesMoved = HandleTouchesMoved;
                _layer.AddEventListener(touchEvent);
                ccGView.RunWithScene(_scene);
            }
        }

        void OnTouchesEnded(List<CCTouch> touches, CCEvent touchEvent)
        {
            if (touches.Count > 0)
            {
                // Perform touch handling here
            }
        }

        void HandleTouchesMoved(System.Collections.Generic.List<CCTouch> touches, CCEvent touchEvent)
        {
            // we only care about the first touch:
            var locationOnScreen = touches[0].Location;
            ship.PositionX = locationOnScreen.X;
            ship.PositionY = locationOnScreen.Y;
        }
    }
}