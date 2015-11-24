using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike_RPG_Console_Game
{
    
    public class Enemy : DamagableEntity
    {
        public int expDropped { get; protected set; }
        public int goldDropped { get; protected set; }

        protected Random random;
        protected int baseHealth;
        protected int baseAttack;
        protected int baseMagic;
        protected int baseDefence;
        protected int baseResist;
        protected int expDropBase;
        protected int goldDropBase;

        public WeaponEffect effect = WeaponEffect.none;

        public Enemy(int x, int y)
            : base()
        {
            this.x = x;
            this.y = y;
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

        public void Attack(Player player)
        {
            player.TakeDamage(attackDamage, effect);
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
