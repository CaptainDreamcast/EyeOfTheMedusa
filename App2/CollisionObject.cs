using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App2
{
    public class CollisionObject
    {
        public float PositionX;
        public float PositionY;
        public float SizeX;
        public float SizeY;
        public Object Source;

        public CollisionObject(Enemy enemy) {
            this.PositionX = enemy.getX();
            this.PositionY = enemy.getY();
            this.SizeX = enemy.getSizeX();
            this.SizeY = enemy.getSizeY();
            this.Source = enemy;
        }

        public static List<CollisionObject> CollisionObjectList(EnemyGroup enemyGroup) {
            List<CollisionObject> returnList;
            returnList = new List<CollisionObject>();

            if (enemyGroup != null)
            {
                foreach (Enemy enemy in enemyGroup.enemies)
                {
                    if (!enemy.Dying)
                    {
                        returnList.Add(new CollisionObject(enemy));
                    }
                }
            }

            return returnList;
        }

    }
}
