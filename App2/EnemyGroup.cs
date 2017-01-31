using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2
{
    public abstract class EnemyGroup
    {
        public List<Enemy> enemies;
        public bool update()
        {
            bool alive;
            int whichEnemy;

            alive = false;
            for (whichEnemy = 0; whichEnemy < this.enemies.Count; whichEnemy++)
            {
                if (this.enemies[whichEnemy].update())
                {
                    alive = true;
                }
                else {
                    this.enemies.Remove(this.enemies[whichEnemy]);
                    whichEnemy--;
                }
            }

            return(alive);
        }
    }
}
