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
    class EnemyC : Enemy
    {

        private int state;
        private float velocityX;
        private float velocityY;

        public EnemyC(float x, float y, Canvas screen, List<Canvas> objects, float newLowerBoundY, float newUpperBoundY)
        {
            this.allObjects = objects;
            this.alive = true;
            this.velocityX = 0.5f;
            this.speedX = 0;
            this.speedY = 5;
            this.state = 0;
            this.load("Assets/Logo.scale-100.png", screen);
            this.setPosition(x, y);

        }


        public override bool update()
        {


            if (this.alive)
            {
                if (!this.Dying)
                {


                    if (this.state == 0)
                    {
                        this.setX(this.getX() - speedX);
                        this.speedX += velocityX;
                        if (this.speedX > 10)
                        {
                            this.state = 1;
                        }
                    }
                    else if (this.state == 1)
                    {
                        this.setY(this.getY() - speedY);
                        this.setX(this.getX() - speedX);
                        this.speedX -= velocityX;
                        if (this.speedX < -5)
                        {
                            this.state = 2;
                        }
                    }
                    else if (this.state == 2)
                    {

                        this.setY(this.getY() + speedY);
                        this.setX(this.getX() - speedX);
                        this.speedX += velocityX;
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
