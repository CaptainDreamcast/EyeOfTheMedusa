using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// Die Elementvorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace App2
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet werden kann oder auf die innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Timer timer;
        private Robo robot;
        private EnemyHandler enemyHandler;
        public List<Canvas> objects;

        public MainPage()
        {
            
            this.InitializeComponent();
            this.robot = new Robo(inner, outer);
            this.objects = new List<Canvas>();
            this.enemyHandler = new EnemyHandler(this.outer, this.objects);


            timer = new Timer(TimerCallback, null, 100, 100);
        }

        private void TimerCallback(object param)
        {
            Dispatcher.RunAsync(CoreDispatcherPriority.High,
                new DispatchedHandler(() =>
                {
                    Update(1.0f/60);
                }));
        }



        private void Update(float frameDurationInSeconds)
        {
            List<Shot> shots;
            List<CollisionObject> objects;
            List<int[]> integerTuples;

            enemyHandler.update();
            shots = robot.GetActiveShots();
            foreach (Shot shot in shots)
            {
                shot.Update(frameDurationInSeconds);
            }
            objects = CollisionObject.CollisionObjectList(enemyHandler.GetCurrentEnemyGroup());
            integerTuples = CollisionHandler.HandleShots(shots, objects);
            foreach (int[] integerTuple in integerTuples)
            {
                ((Enemy)(objects.ElementAt<CollisionObject>(integerTuple[0]).Source)).TakeDamage();
                this.robot.RemoveShot(shots.ElementAt<Shot>(integerTuple[1]));
            }

        }

        private void Canvas_KeyDown(object sender, KeyRoutedEventArgs e)
        {

            if (e.Key == Windows.System.VirtualKey.Right)
            {
                robot.goRight();
            }
            else if (e.Key == Windows.System.VirtualKey.Left)
            {
                robot.goLeft();
            }
            else if (e.Key == Windows.System.VirtualKey.Up)
            {
                robot.goUp();
            }
            else if (e.Key == Windows.System.VirtualKey.Down)
            {
                robot.goDown();
            }
            else if (e.Key == Windows.System.VirtualKey.Control)
            {
                robot.shoot();
            }
            else if (e.Key == Windows.System.VirtualKey.C)
            {
                robot.transformC();
            }
            else if (e.Key == Windows.System.VirtualKey.V)
            {
                robot.transformV();
            }
            else if (e.Key == Windows.System.VirtualKey.B)
            {
                robot.transformB();
            }
        }

        private void test(object sender, RoutedEventArgs e)
        {
            this.robot.goLeft();
        }
    }
}
