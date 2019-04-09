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
        List<Asteroid> asteroids;
        Psyche psyche;

        CCParticleFire fire;
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

        public void DrawParticle(CCPoint point)
        {
            var explosion = new CCParticleFireworks(CCPoint.Zero)
            {
                TotalParticles = 10,
                StartColor = new CCColor4F(CCColor3B.White),
                EndColor = new CCColor4F(CCColor3B.Black),
                Position = new CCPoint(point.X,point.Y )
                
            };

            _layer.AddChild(explosion);
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

                //ship
                ship = new Ship();
                ship.PositionX = 200;
                ship.PositionY = 50;
                _layer.AddChild(ship);

                fire = new CCParticleFire(new CCPoint(200, 50))
                {
                    StartSize = 1,
                    Angle = 270
                   
                };
                _layer.AddChild(fire);

                var touchEvent = new CCEventListenerTouchAllAtOnce();
                touchEvent.OnTouchesEnded = OnTouchesEnded;
                touchEvent.OnTouchesMoved = HandleTouchesMoved;
                _layer.AddEventListener(touchEvent);

                //asteroid
                asteroids = new List<Asteroid>();
                void HandleAsteroidCreated(Asteroid newAsteroid)
                {
                    _layer.AddChild(newAsteroid);
                    asteroids.Add(newAsteroid);
                }
                AsteroidFactory.Self.AsteroidCreated += HandleAsteroidCreated;

                //psyche

                psyche = new Psyche();
                psyche.PositionX = 200;
                psyche.PositionY = 2000;
                psyche.VelocityY = -50;
                _layer.AddChild(psyche);
                if (psyche.PositionY == 200)
                {
                    psyche.VelocityY = 0;
                    psyche.PositionY = 200;
                }

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
            fire.PositionX = locationOnScreen.X;
            fire.PositionY = locationOnScreen.Y;
        }
    }
}
