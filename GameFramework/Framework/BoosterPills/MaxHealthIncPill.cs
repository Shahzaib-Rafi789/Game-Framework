using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core;

namespace Framework.BoosterPills
{
    public class MaxHealthIncPill : IBooster
    {
        int healthExtent;

        public MaxHealthIncPill(int healthExtent)
        {
            this.HealthExtent = healthExtent;
        }

        public int HealthExtent { get => healthExtent; set => healthExtent = value; }

        public void BoosterEffect(Object Ob)
        {
            GameObject ob = (GameObject)Ob;
            double n = ob.ObjectStats.TotalHealth / HealthExtent;
            ob.ObjectStats.Defence += (int)(ob.ObjectStats.Defence/n);

            ob.ObjectStats.HealthBar.Width += (int)((ob.ObjectStats.HealthBar.Width) / n);
        }
    }
}
