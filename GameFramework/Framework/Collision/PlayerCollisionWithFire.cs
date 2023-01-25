using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core;
using Framework.FireFolder;
using Framework.Movement;

namespace Framework.CollisionFolder
{
    public class PlayerCollisionWithFire : ICollisionAction
    {
        public void PerformAction(Game game, Object ob1, Object ob2)
        {
            GameObject Player;
            Fire fire;
            if(ob1.GetType() == typeof(GameObject) && ob2.GetType() == typeof(Fire))
            {
                Player = (GameObject)ob1;
                fire = (Fire)ob2;
            }
            else
            {
                Player = (GameObject)ob2;
                fire = (Fire)ob1;
            }

            Player.ObjectStats.ReduceHealth();
            game.RemoveFire(fire);
            if (!Player.ObjectStats.IsAlive())
            {
                game.RemoveObject(Player);
                game.RaisePlayerDeathEvent(Player.Pb);
            }
        }
    }
}
