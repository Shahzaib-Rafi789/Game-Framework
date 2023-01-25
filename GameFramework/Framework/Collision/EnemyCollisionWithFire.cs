using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core;
using Framework.FireFolder;

namespace Framework.CollisionFolder
{
    public class EnemyCollisionWithFire : ICollisionAction
    {
        public void PerformAction(Game game, Object ob1, Object ob2)
        {
            GameObject Enemy;
            Fire fire;
            if (ob1.GetType() == typeof(GameObject) && ob2.GetType() == typeof(Fire))
            {
                Enemy = (GameObject)ob1;
                fire = (Fire)ob2;
            }
            else
            {
                Enemy = (GameObject)ob2;
                fire = (Fire)ob1;
            }

            Enemy.ObjectStats.ReduceHealth();
            game.RemoveFire(fire);
            if (!Enemy.ObjectStats.IsAlive())
            {
                game.RemoveObject(Enemy);
                game.RaiseEnemyDeathEvent(Enemy.Pb);
            }
        }
    }
}
