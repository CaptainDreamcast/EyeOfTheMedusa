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
    class EnemyHandler
    {

        List<EnemyGroup> enemyGroups;
        private Canvas screen;
        private List<Canvas> allObjects;

        public EnemyHandler(Canvas newScreen, List<Canvas> objects)
        {
            
            this.enemyGroups = new List<EnemyGroup>();
            this.screen = newScreen;
            this.allObjects = objects;
            this.spawnEnemies();

        }

        public void update() {

            int whichEnemyGroup;

            for (whichEnemyGroup = 0; whichEnemyGroup < enemyGroups.Count; whichEnemyGroup++)
            {
                if (!this.enemyGroups[whichEnemyGroup].update()) {
                    this.enemyGroups.Remove(this.enemyGroups[whichEnemyGroup]);
                    whichEnemyGroup--;
                }
            }
        
        }

        private void spawnEnemies() {

            EnemyGroup newEnemyGroup;

            newEnemyGroup = new EnemyGroupA(this.screen, this.allObjects);
            this.enemyGroups.Add(newEnemyGroup);

        }


        public EnemyGroup GetCurrentEnemyGroup()
        {
            if (enemyGroups.Count > 0)
            {
                return this.enemyGroups[0];
            }
            else {
                return null;
            }
        }
    }
}
