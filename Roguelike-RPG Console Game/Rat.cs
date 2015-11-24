using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike_RPG_Console_Game
{
    public class Rat : Enemy
    {
        public Rat(int x, int y) 
            : base(x, y)
        {
            name = "Rat";
            random = new Random();

            level = random.Next(1, 5);
            int modifier = Convert.ToInt32(1.5f * level);

            baseHealth = 9;
            baseAttack = 3;
            expDropBase = 3;
            goldDropBase = 2;
            baseDefence = 0;
            baseResist = 0;
            baseMagic = 0;

            maxHealth = baseHealth + modifier;
            attackDamage = baseAttack + modifier;
            expDropped = expDropBase + modifier;
            goldDropped = goldDropBase + modifier;
            resist = baseResist + modifier;
            magic = baseMagic + modifier;

            health = maxHealth;
        }

        public override char ToChar()
        {
            return '«';
        }
    }
}
