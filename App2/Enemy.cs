using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

using Windows.Storage.Streams;

namespace App2
{
    public abstract class Enemy
    {
        public StackPanel existence;

        public List<Canvas> allObjects;
        public bool alive { get; set; }
        public bool Dying;

        public float speedX { get; set; }
        public float speedY { get; set; }

        private float ticks;

        abstract public bool update();

        public void setPosition(float x, float y) {
            Canvas.SetLeft(this.existence, x);
            Canvas.SetTop(this.existence, y);
        }

        public async void load(String stringu, Canvas screen) {

            this.existence = new StackPanel();
            this.existence.HorizontalAlignment = HorizontalAlignment.Left;
            this.existence.VerticalAlignment = VerticalAlignment.Top;
            this.existence.Height = 300;
            this.existence.Width = 300;

            ImageBrush brush = new ImageBrush();
            var uri = new System.Uri("ms-appx:///Assets/badass.png");
            var file = await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(uri);

            using (IRandomAccessStream stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read)) {
                BitmapImage img = new BitmapImage();
                img.SetSource(stream);
                brush.ImageSource = img;
                existence.Background = brush;
            
            }

           
            screen.Children.Add(this.existence);
        }

        public float getX() {
            return ((float)Canvas.GetLeft(this.existence));
        }

        public void setX(float x)
        {
            Canvas.SetLeft(this.existence, x);
        }



        public float getY()
        {
            return ((float)Canvas.GetTop(this.existence));
        }

        public void setY(float y)
        {
            Canvas.SetTop(this.existence, y);
        }

        public float getSizeX() {
            return ((float)this.existence.Width);
        }

        public bool died() {
            return (this.getX() + this.getSizeX() < 0);
        }

        public void TakeDamage() {
            ImageBrush brush = new ImageBrush();
            var uri = new System.Uri("ms-appx:///Assets/dying1.png");
            BitmapImage img = new BitmapImage(uri);
            brush.ImageSource = img;
            existence.Background = brush;
            this.Dying = true;
        }


        public float getSizeY()
        {
            return ((float)this.existence.Height);
        }

        protected void animateDeath() {
            ticks++;
            if (ticks > 20)
            {
                this.setX(-100000000);

            }
            else if (ticks > 10) {
                ImageBrush brush = new ImageBrush();
                var uri = new System.Uri("ms-appx:///Assets/dying2.png");
                BitmapImage img = new BitmapImage(uri);
                brush.ImageSource = img;
                existence.Background = brush;
            }
        }
    }
}
