using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike_RPG_Console_Game
{
    
    public class Enemy
    {
        public string healthBar
        {
            get
            {
                string healthBar = "[";

                for (int i = 9; i > 0; i--)
                {
                    if ((float)health >= (float)(maxHealth * (i / 9f)))
                        healthBar += "█";
                    else healthBar += " ";
                }

                healthBar += "█]";

                return healthBar;
            }
        }
        public int x;
        public int y;
        public bool alive { get; protected set; }
        public int expDropped { get; protected set; }
        public int goldDropped { get; protected set; }

        protected Random random;
        protected int level;
        protected int baseHealth;
        protected int maxHealth;
        protected int health;
        protected int baseAttack;
        protected int attackDamage;
        protected int baseMagic;
        protected int magic;
        protected int baseDefence;
        protected int defence;
        protected int baseResist;
        protected int resist;
        protected int expDropBase;
        protected int goldDropBase;

        public WeaponEffect effect = WeaponEffect.none;
        public StatusEffect status = StatusEffect.none;

        protected string name;

        public Enemy(int x, int y)
        {
            this.x = x;
            this.y = y;

            alive = true;
        }

        public virtual void Update(Player player)
        {
            if (Math.Abs(player.x - x) > Math.Abs(player.y - y))
            {
                if (player.x > x)
                {
                    x++;
                }
                else if (player.x < x)
                {
                    x--;
                }
                else if (player.y < y)
                {
                    y--;
                }
                else if (player.y > y)
                {
                    y++;
                }
                
            }
            else
            {
                if (player.y < y)
                {
                    y--;
                }
                else if (player.y > y)
                {
                    y++;
                }
                else if (player.x > x)
                {
                    x++;
                }
                else if (player.x < x)
                {
                    x--;
                }
            }
        }

        public virtual void TakeDamage(int damage, WeaponEffect effect)
        {
            if (effect == WeaponEffect.burn)
                status = StatusEffect.burned;

            damage -= defence / 2;

            if (damage < 0)
                damage = 0;

            health -= damage;

            if (status == StatusEffect.burned)
                health -= 5;

            if (health <= 0)
                alive = false;
        }

        public virtual void TakeMagicDamage(int magicDamage, WeaponEffect effect)
        {
            if (effect == WeaponEffect.burn)
                status = StatusEffect.burned;

            magicDamage -= resist / 3;

            if (magicDamage < 0)
                magicDamage = 0;

            health -= magicDamage;

            if (status == StatusEffect.burned)
                health -= 5;

            if (health <= 0)
                alive = false;
        }

        public void Attack(Player player)
        {
            player.TakeDamage(attackDamage, effect);
        }

        public virtual char ToChar()
        {
            return '$';
        }

        public override string ToString()
        {
            string statusString = "";

            if (status == StatusEffect.burned)
                statusString = "(Burned)\n";

            return
                "Level " + level + " " + name + "\n" +
                "Health: " + healthBar + "\n" +
                statusString +
                "#####################\n" +
                "IMAGE HERE\n" +
                "#####################\n";

        }
    }
}
