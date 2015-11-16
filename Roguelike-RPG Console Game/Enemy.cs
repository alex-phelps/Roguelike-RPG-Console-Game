using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike_RPG_Console_Game
{
    public enum EnemyType
    {
        rat
    }

    public class Enemy
    {
        public int x { get; protected set; }
        public int y { get; protected set; }

        protected int level;
        protected int baseHealth;
        protected int health;
        protected int baseAttack;
        protected int attackDamage;
        protected int baseDefence;
        protected int defence;
        protected int expDropBase;
        protected int expDropped;
        protected int goldDropBase;
        protected int goldDropped;

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

        public virtual char ToChar()
        {
            return '$';
        }
    }
}
