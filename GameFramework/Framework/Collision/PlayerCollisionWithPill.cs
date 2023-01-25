using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core;
using Framework.FireFolder;
using Framework.BoosterPills;

namespace Framework.CollisionFolder
{
    public class PlayerCollisionWithPill : ICollisionAction
    {
        public void PerformAction(Game game, Object ob1, Object ob2)
        {
            GameObject Player;
            Booster booster;
            if (ob1.GetType() == typeof(GameObject) && ob2.GetType() == typeof(Booster))
            {
                Player = (GameObject)ob1;
                booster = (Booster)ob2;
            }
            else
            {
                Player = (GameObject)ob2;
                booster = (Booster)ob1;
            }

            booster.BoosterEffect.BoosterEffect(Player);
            game.RemovePill(booster);
        }
    }
}
