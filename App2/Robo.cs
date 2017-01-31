using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage.Streams;
using System.Threading;

namespace App2
{
    class Robo
    {
        public float x { get; set; }
        public float y { get; set; }


        public float speed { get; set; }
        public char state;
        public Boolean transforming;
        private Canvas background;
        public List<Shot> shots;

        public Canvas existence { get; set; }

        public Robo(Canvas newExistence, Canvas background)
        {
            this.x = 185.0f;
            this.y = 98.0f;
            this.speed = 5;
            this.existence = newExistence;
            this.state = 'C';
            this.transforming = false;
            this.background = background;
            this.shots = new List<Shot>();
        }

        public void goLeft()
        {
            if (this.x > 0)
            {
                this.x -= this.speed;
                Canvas.SetLeft(this.existence, this.x);
            }
        }

        public void goRight()
        {
            if (this.x < 1206)
                this.x += this.speed;
            Canvas.SetLeft(this.existence, this.x);
        }

        public void goUp()
        {
            if (this.y > 0)
            {
                this.y -= this.speed;
                Canvas.SetTop(this.existence, this.y);
            }
        }

        public void goDown()
        {
            if (this.y < 468)
            {
                this.y += this.speed;
                Canvas.SetTop(this.existence, this.y);
            }
        }

        public void TimerCallback(object param) 
        {
            transforming = false;
            t1.Dispose();
        }
        Timer t1;

        public void transformC()
        {
            if (transforming == false)
            {
                if (state == 'V')
                {
                    transforming = true;
                    t1 = new Timer(TimerCallback, null, 500, 500);

                    ImageBrush brush = new ImageBrush();
                    var uri = new System.Uri("ms-appx:///Assets/tukan1.png");
                    BitmapImage img = new BitmapImage(uri);
                    brush.ImageSource = img;
                    existence.Background = brush;
                }

                else if (state == 'B')
                {
                    transforming = true;
                    t1 = new Timer(TimerCallback, null, 500, 500);

                    ImageBrush brush = new ImageBrush();
                    var uri = new System.Uri("ms-appx:///Assets/tukan1.png");
                    BitmapImage img = new BitmapImage(uri);
                    brush.ImageSource = img;
                    existence.Background = brush;
                }
                state = 'C';
            }
        }

        public void transformV()
        {
            if (transforming == false)
            {
                if (state == 'C')
                {
                    transforming = true;
                    t1 = new Timer(TimerCallback, null, 500, 500);

                    ImageBrush brush = new ImageBrush();
                    var uri = new System.Uri("ms-appx:///Assets/tukan2.png");
                    BitmapImage img = new BitmapImage(uri);
                    //var file = await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(uri);
                    //using (IRandomAccessStream stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
                    //{
                    //    BitmapImage img = new BitmapImage();
                    //    img.SetSource(stream);
                    brush.ImageSource = img;
                    existence.Background = brush;

                    //}
                }
                else if (state == 'B')
                {
                    transforming = true;
                    t1 = new Timer(TimerCallback, null, 500, 500);

                    ImageBrush brush = new ImageBrush();
                    var uri = new System.Uri("ms-appx:///Assets/tukan2.png");
                    BitmapImage img = new BitmapImage(uri);
                    brush.ImageSource = img;
                    existence.Background = brush;
                }
                state = 'V';
            }
        }

        public void transformB()
        {
            if (transforming == false)
            {
                if (state == 'C')
                {
                    transforming = true;
                    t1 = new Timer(TimerCallback, null, 500, 500);

                    ImageBrush brush = new ImageBrush();
                    var uri = new System.Uri("ms-appx:///Assets/tukan3.png");
                    BitmapImage img = new BitmapImage(uri);
                    brush.ImageSource = img;
                    existence.Background = brush;
                }
                else if (state == 'V')
                {
                    transforming = true;
                    t1 = new Timer(TimerCallback, null, 500, 500); 
                    ImageBrush brush = new ImageBrush();
                    var uri = new System.Uri("ms-appx:///Assets/tukan3.png");
                    BitmapImage img = new BitmapImage(uri);
                    brush.ImageSource = img;
                    existence.Background = brush;
                }
                state = 'B';
            }
        }

        public void shoot()
        {
            this.shots.Add(new Shot(this.background, (float)(this.x+this.existence.Width), (float)(this.y+0.5f*this.existence.Height), Robo.ShotVelocityX, Robo.ShotVelocityY, Robo.ShotSizeX, Robo.ShotSizeY));
        }

        public List<Shot> GetActiveShots() {
            return new List<Shot>(this.shots);
        }

        public void RemoveShot(Shot shot) {
            this.shots.Remove(shot);
            shot.Destroy(this.background);
        }

        public static float ShotVelocityX = 3000;

        public static float ShotVelocityY = 0;

        public static float ShotSizeY = 10;

        public static float ShotSizeX = 10;
    }
}
