using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike_RPG_Console_Game
{
    public enum EnemyType
    {
        rat,
        weakZombie
    }

    public class Enemy
    {
        public string healthBar
        {
            get
            {
                string healthBar = "[";

                for (int i = 8; i > 0; i--)
                {
                    if ((float)health >= (float)(maxHealth * (i / 8f)))
                        healthBar += "█";
                    else healthBar += " ";
                }

                healthBar += "]";

                return healthBar;
            }
        }
        public int x { get; protected set; }
        public int y { get; protected set; }
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
        protected int baseDefence;
        protected int defence;
        protected int expDropBase;
        protected int goldDropBase;

        protected string name;

        public Enemy(int x, int y)
        {
            this.x = x;
            this.y = y;

            alive = true;
        }

        public void Update(Player player)
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

        public virtual void TakeDamage(int damage)
        {
            damage -= defence / 2;

            if (damage < 0)
                damage = 0;

            health -= damage;

            if (health <= 0)
                alive = false;
        }

        public void Attack(Player player)
        {
            player.TakeDamage(attackDamage);
        }

        public virtual char ToChar()
        {
            return '$';
        }

        public override string ToString()
        {
            return
                "Level " + level + " " + name + "\n" +
                "Health: " + healthBar + "\n" +
                "#####################\n" +
                "IMAGE HERE\n" +
                "#####################\n";

        }
    }
}
