using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Framework.Movement;
using Framework.FireFolder;
using Framework.CollisionFolder;

namespace Framework.Core
{
    public class HUD
    {
        int health;
        ProgressBar healthBar;
        int totalHealth;
        double stamina;
        double staminaDeplete;
        double staminaRecovery;
        double attackStamina;
        int defence;

        public HUD(int health, int defence, double staminaDeplete, double staminaRecovery, double attackStamina, ProgressBar healthBar)
        {
            this.Health = health;
            this.Defence = defence;
            TotalHealth = 100;
            Stamina = 100;
            this.StaminaDeplete = staminaDeplete;
            this.StaminaRecovery = staminaRecovery;
            this.AttackStamina = attackStamina;
            this.HealthBar = healthBar;
            HealthBar.Style = ProgressBarStyle.Continuous;
        }

        public int Health { get => health; set => health = value; }
        public int Defence { get => defence; set => defence = value; }
        public int TotalHealth { get => totalHealth; set => totalHealth = value; }
        public double Stamina { get => stamina; set => stamina = value; }
        public double StaminaDeplete { get => staminaDeplete; set => staminaDeplete = value; }
        public double StaminaRecovery { get => staminaRecovery; set => staminaRecovery = value; }
        public double AttackStamina { get => attackStamina; set => attackStamina = value; }
        public ProgressBar HealthBar { get => healthBar; set => healthBar = value; }

        public void ReduceHealth()
        {
            Health -= 100 / Defence;
            if (Health > 0) { HealthBar.Value = Health; }
            else { HealthBar.Value = 0; }
        }

        public void DepleteStamina()
        {
            if (Stamina <= StaminaDeplete) { Stamina = 0; }
            else { Stamina -= StaminaDeplete; }

            //PlayerHUD.StaminaBar.Value = Convert.ToInt32(stamina);
        }

        public void RecoverStamina()
        {
            if (Stamina != 100)
            {
                if (Stamina + StaminaRecovery >= 100) { Stamina = 100; }
                else { Stamina += StaminaRecovery; }

                //PlayerHUD.StaminaBar.Value = Convert.ToInt32(stamina);
            }
        }

        public bool IsAlive()
        {
            if(Health>0)
            {
                return true;
            }
            return false;
        }
    }
}
