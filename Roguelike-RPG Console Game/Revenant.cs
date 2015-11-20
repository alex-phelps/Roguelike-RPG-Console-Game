using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike_RPG_Console_Game
{
    public class Revenant : Boss
    {
        public Revenant() 
            : base()
        {
            name = "Revenant";
            level = 12;
            int modifier = Convert.ToInt32(1.5f * level);

            baseHealth = 12;
            baseAttack = 4;
            baseDefence = 4;
            expDropBase = 7;
            goldDropBase = 8;

            maxHealth = baseHealth + modifier;
            attackDamage = baseAttack + modifier;
            defence = baseDefence + modifier;
            expDropped = expDropBase + modifier;
            goldDropped = goldDropBase + modifier;

            health = maxHealth;
        }

        public override char ToChar()
        {
            return '₧';
        }
    }
}
