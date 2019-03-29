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
        GameScene _scene;

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
            if (ccGView != null)
            {
                ccGView.DesignResolution = new CCSizeI(App.Width, App.Height);
                _scene = new GameScene(ccGView);
                var touchEvent = new CCEventListenerTouchOneByOne();
                touchEvent.OnTouchBegan = (touch, _event) => {
                    _scene.DrawParticle(touch.LocationOnScreen);
                    return true;
                };
                touchEvent.OnTouchMoved = (touch, _event) => {
                    _scene.DrawParticle(touch.LocationOnScreen);
                };
                _scene.AddEventListener(touchEvent);
                CCSprite s = new CCSprite("psyche_rocket.png");
                s.PositionX = 100;
                s.PositionY = 100;
                
                _scene.AddChild(s);
                ccGView.RunWithScene(_scene);
            }
        }
    }
}