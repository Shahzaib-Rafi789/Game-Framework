using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core;

namespace Framework.BoosterPills
{
    public class HealthRecoverPill : IBooster
    {
        int healthRecoverAmount;

        public HealthRecoverPill(int healthRecoverAmount)
        {
            this.HealthRecoverAmount = healthRecoverAmount;
        }

        public int HealthRecoverAmount { get => healthRecoverAmount; set => healthRecoverAmount = value; }

        public void BoosterEffect(Object Ob)
        {
            GameObject ob = (GameObject)Ob;
            if(ob.ObjectStats.Health + HealthRecoverAmount < ob.ObjectStats.TotalHealth)
            {
                ob.ObjectStats.Health += HealthRecoverAmount;                
            }
            else
            {
                ob.ObjectStats.Health = 100;
            }

            ob.ObjectStats.HealthBar.Value = ob.ObjectStats.Health;
        }
    }
}
