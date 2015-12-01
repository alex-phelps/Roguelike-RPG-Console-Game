using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike_RPG_Console_Game
{
    public class DamagableEntity
    {
        public string healthBar
        {
            get
            {
                string healthBar = "[";
                string statusString = "";

                for (int i = 9; i > 0; i--)
                {
                    if ((float)health >= (float)(maxHealth * (i / 9f)))
                        healthBar += "█";
                    else healthBar += " ";
                }

                healthBar += "█]";

                if (status == StatusEffect.burned)
                    statusString = "\n(Burned)";
                else if (status == StatusEffect.cursed)
                    statusString = "\n(Cursed)";

                return healthBar + statusString;
            }
        }

        public bool alive { get; protected set; }
        public int x;
        public int y;

        public int level = 0;
        public int maxHealth;
        public int health;
        public int attackDamage;
        public int magic;
        public int defense;
        public int resist;

        public StatusEffect status = StatusEffect.none;

        protected string name;

        public DamagableEntity()
        {
            alive = true;
        }

        public virtual void TakeDamage(int damage, WeaponEffect effect)
        {
            if (effect == WeaponEffect.burn)
                status = StatusEffect.burned;
            else if (effect == WeaponEffect.curse)
                status = StatusEffect.cursed;

            if (effect != WeaponEffect.penetrate)
                damage -= defense / 2;

            if (damage < 0)
                damage = 0;

            health -= damage;

            if (status == StatusEffect.burned)
                health -= 5;
            else if (status == StatusEffect.cursed)
                health = (int)Math.Ceiling((4f / 5f) * health);

            if (health <= 0)
                alive = false;
        }

        public virtual void TakeMagicDamage(int magicDamage, WeaponEffect effect)
        {
            if (effect == WeaponEffect.burn)
                status = StatusEffect.burned;
            else if (effect == WeaponEffect.curse)
                status = StatusEffect.cursed;

            magicDamage -= resist / 2;

            if (magicDamage < 0)
                magicDamage = 0;

            health -= magicDamage;

            if (status == StatusEffect.burned)
                health -= 5;
            else if (status == StatusEffect.cursed)
                health = (int)Math.Ceiling((4f / 5f) * health);

            if (health <= 0)
                alive = false;
        }

        public virtual char ToChar()
        {
            return '$';
        }
    }
}
