using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike_RPG_Console_Game
{
    public class WeakZombie : Enemy
    {
        public WeakZombie(int x, int y)
            : base(x, y)
        {
            name = "Zombie";
            random = new Random();
            level = random.Next(5, 9);
            int modifier = Convert.ToInt32(level * 1.5f);

            baseHealth = 10;
            baseAttack = 3;
            baseDefence = 2;
            expDropBase = 3;
            goldDropBase = 2;

            maxHealth = baseHealth + modifier;
            attackDamage = baseAttack + modifier;
            defence = baseDefence + modifier;
            expDropped = expDropBase + modifier;
            goldDropped = goldDropBase + modifier;

            health = maxHealth;
        }

        public override char ToChar()
        {
            return '¶';
        }
    }
}
