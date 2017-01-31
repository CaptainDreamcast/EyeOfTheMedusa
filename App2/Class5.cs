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

namespace App2
{
    class EnemyB : Enemy
    {

        private bool up;
        private float upperBoundY;
        private float lowerBoundY;

        public EnemyB(float x, float y, Canvas screen, List<Canvas> objects, float newLowerBoundY, float newUpperBoundY)
        {

            this.allObjects = objects;
            this.alive = true;
            this.speedX = 3;
            this.speedY = 3;
            this.load("Assets/Logo.scale-100.png", screen);
            this.setPosition(x, y);
            this.up = true;
            this.lowerBoundY = newLowerBoundY;
            this.upperBoundY = newUpperBoundY;
        }


        public override bool update()
        {


            if (this.alive)
            {
                if (!this.Dying)
                {
                    this.setX(this.getX() - this.speedX);
                    if (this.up)
                    {
                        if (this.getY() >= this.upperBoundY)
                        {
                            this.up = false;
                        }
                        else
                        {
                            this.setY(this.getY() + this.speedY);
                        }
                    }
                    else
                    {
                        if (this.getY() <= this.lowerBoundY)
                        {
                            this.up = true;
                        }
                        else
                        {
                            this.setY(this.getY() - this.speedY);
                        }
                    }


                    if (this.died())
                    {
                        this.alive = false;
                    }
                }
                else {
                    this.animateDeath();
                }
            }


            return (this.alive);
        }
    }
}
