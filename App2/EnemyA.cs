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
    class EnemyA:Enemy
    {
        public EnemyA(float x, float y, Canvas screen, List<Canvas> objects)
        {

            this.Dying = false;
            this.alive = true;
            this.speedX = 3;
            this.load("Assets/Logo.scale-100.png", screen);
            this.setPosition(x, y);
            
        }


        public override bool update() {


            if (this.alive)
            {
                if (!this.Dying)
                {
                    this.setX(this.getX() - this.speedX);
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
