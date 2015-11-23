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
            itemDrop = new NoviceFireTome();

            baseHealth = 12;
            baseAttack = 4;
            baseDefence = 4;
            expDropBase = 7;
            goldDropBase = 8;
            baseResist = 2;
            baseMagic = 0;

            maxHealth = baseHealth + modifier;
            attackDamage = baseAttack + modifier;
            defence = baseDefence + modifier;
            expDropped = expDropBase + modifier;
            goldDropped = goldDropBase + modifier;
            resist = baseResist + modifier;
            magic = baseMagic + modifier;

            health = maxHealth;
        }

        public override char ToChar()
        {
            return '₧';
        }
    }
}
