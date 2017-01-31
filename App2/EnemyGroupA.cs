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
    class EnemyGroupA:EnemyGroup
    {

        public EnemyGroupA(Canvas screen, List<Canvas> objects)
        {
            this.enemies = new List<Enemy>();
            this.enemies.Add(new EnemyA(600, 100, screen, objects));
            this.enemies.Add(new EnemyB(600, 300, screen, objects, 150, 450));
            this.enemies.Add(new EnemyC(600, 500, screen, objects, 150, 450));
        }

        
    }
}
