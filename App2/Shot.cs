using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace App2
{
    public class Shot
    {
        private float velocityX;
        private float velocityY;
        public float PositionX;
        public float PositionY;
        public float SizeX;
        public float SizeY;
        private Canvas existence;

        public Shot(Canvas backGround, float startPositionX, float startPositionY, float velocityX, float velocityY, float sizeX, float sizeY) {
            Canvas shot;
            ImageBrush brush;
            BitmapImage image;

            shot = new Canvas();
            brush = new ImageBrush();
            var uri = new System.Uri("ms-appx:///Assets/SHOT.png");
            image = new BitmapImage(uri);
            brush.ImageSource = image;
            shot.Background = brush;

            backGround.Children.Add(shot);
            this.existence = shot;
            this.PositionX = startPositionX;
            this.PositionY = startPositionY;
            this.velocityX = velocityX;
            this.velocityY = velocityY;
            this.SizeX = sizeX;
            this.SizeY = sizeY;

            this.existence.Width = this.SizeX;
            this.existence.Height = this.SizeY;
            this.Redraw();
        }

        public void Update(float frameTimeInSeconds) {
            this.PositionX += this.velocityX * frameTimeInSeconds;
            this.PositionY += this.velocityY * frameTimeInSeconds;
            this.Redraw();
        }

        public void Redraw() {
            Canvas.SetLeft(this.existence, this.PositionX);
            Canvas.SetTop(this.existence, this.PositionY);
        }





        public void Destroy(Canvas background)
        {
            background.Children.Remove(this.existence);
        }
    }
}
