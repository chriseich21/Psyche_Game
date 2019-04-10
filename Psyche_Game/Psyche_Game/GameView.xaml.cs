using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CocosSharp;
using CocosDenshion;

namespace Psyche_Game
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameView : ContentView
    {
        private GamePage Page;
        CCGameView ccGView;
        //instantiate Variables
        CCScene _scene;
        CCLayer _layer;
        Ship ship;
        List<Asteroid> asteroids;
        Psyche psyche;

        CCParticleFire fire;
        public GameView()
        {
            //create a new view
            var sharpView = new CocosSharpView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                ViewCreated = HandleViewCreated
            };
            Content = sharpView;
        }

        //check for the location of the ship
        public void Update()
        {
            //updated sprites and/or particles here
            fire.PositionX = ship.PositionX;
            fire.PositionY = ship.PositionY;
            //collision here

            CheckCollisionAsteroids();
            CheckCollisionPsyche();
        }

        //check collison function dtermines if the ship touches an asteroid
        void CheckCollisionAsteroids()
        {

            foreach (var asteroid in asteroids)
            {
                bool hit = ship.sprite.BoundingBoxTransformedToWorld.IntersectsRect(asteroid.sprite.BoundingBoxTransformedToWorld);

                if (hit)
                {
                    var Lose = new Lose();
                    Lose.PositionX = ((App.Width) / 2);
                    Lose.PositionY = ((App.Height) / 4);
                    _layer.AddChild(Lose);
                    ccGView.Scheduler.PauseAllTargets();
                }
            }
        }

        void CheckCollisionPsyche()
        {
            bool hit = ship.sprite.BoundingBoxTransformedToWorld.IntersectsRect(psyche.sprite.BoundingBoxTransformedToWorld);

            if (hit)
            {
                var Win = new Win();
                Win.PositionX = ((App.Width) / 2);
                Win.PositionY = ((App.Height) / 4);
                _layer.AddChild(Win);
                ccGView.Scheduler.PauseAllTargets();
            }
        }
        
        //draws our particle effects in the view 
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
            
            //loads the view
            var ccGView = sender as CCGameView;
            var contentSearchPaths = new List<string>() { "Resources","Assets" };
            ccGView.ContentManager.SearchPaths = contentSearchPaths;
            
            if (ccGView != null)
            {
                //if the view is created then load all the assets
                ccGView.DesignResolution = new CCSizeI(App.Width, App.Height);
                _scene = new CCScene(ccGView);
                _layer = new CCLayer();
                _scene.AddLayer(_layer);

                //ship
                ship = new Ship(this);
                ship.PositionX = ((App.Width) / 2);
                ship.PositionY = ((App.Height) / 4);
                
                _layer.AddChild(ship);

                //starts are generated as particles
                var stars = new CCParticleRain(new CCPoint(200, App.Height))
                {
                    StartSize = 1,
                    Color = CCColor3B.White,
                    Speed = 250,
                    SourcePosition = new CCPoint(0.0f, -10.0f),

                };
                stars.StartColor = new CCColor4F(1.0f, 1.0f, 1.0f, 1.0f);
                _layer.AddChild(stars);


                var faststars = new CCParticleRain(new CCPoint(200, App.Height))
                {
                    StartSize = 1,
                    Speed = 500,
                    SourcePosition = new CCPoint(0.0f, -10.0f),
                    
                };
                faststars.StartColor = new CCColor4F(1.0f,1.0f,1.0f,1.0f);
                _layer.AddChild(faststars);
                
                var slowstars = new CCParticleRain(new CCPoint(200, App.Height))
                {
                    TotalParticles = 1,
                    StartSize = 2,
                    Color = CCColor3B.Blue,
                    Speed = 50,
                    SourcePosition = new CCPoint(0.0f, -10.0f),

                };
                faststars.StartColor = new CCColor4F(0.0f, 0.0f, 1.0f, 1.0f);
                _layer.AddChild(slowstars);
                //the fire trailing the rocket
                fire = new CCParticleFire(new CCPoint(((App.Width) / 2), ((App.Height) / 4)))
                {
                    StartSize = 1,
                    Angle = 270,
                    Speed = 100,
                    SourcePosition = new CCPoint(0.0f,-10.0f),
                    
                };
                _layer.AddChild(fire);
                //the handlers for the screne being touched
                var touchEvent = new CCEventListenerTouchAllAtOnce();
                touchEvent.OnTouchesEnded = OnTouchesEnded;
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
                psyche.PositionY = 4000;
                psyche.VelocityY = -50;
                _layer.AddChild(psyche);
                ccGView.RunWithScene(_scene);
              
            }
        }


        void OnTouchesEnded(List<CCTouch> touches, CCEvent touchEvent)
        {
            if (touches.Count > 0)
            {
                // Perform touch handling here
            }
            if (touches[0].Location.X > (App.Width/ 2) )
            {
                ship.VelocityX += 5;
            }
            else if (touches[0].Location.X < (App.Width/ 2) )
            {
                ship.VelocityX -= 5;
            }

        }

        
    }
}
