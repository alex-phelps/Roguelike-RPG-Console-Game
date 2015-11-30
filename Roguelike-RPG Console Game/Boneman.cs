using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike_RPG_Console_Game
{
    public class Boneman : Enemy
    {
        public Boneman(int x, int y) 
            :base(x, y)
        {
            name = "Boneman";
            random = new Random();
            level = random.Next(7, 12);
            int modifier = Convert.ToInt32(level * 1.5f);

            baseHealth = 4;
            baseAttack = 9;
            baseDefence = 1;
            expDropBase = 5;
            goldDropBase = 2;
            baseResist = 4;
            baseMagic = 0;

            maxHealth = baseHealth + modifier;
            attackDamage = baseAttack + modifier;
            defence = baseDefence + modifier;
            expDropped = expDropBase + modifier;
            goldDropped = goldDropBase + modifier;
            resist = baseResist + modifier;
            magic = baseMagic + modifier;

            effect = WeaponEffect.penetrate;

            health = maxHealth;
        }

        public override char ToChar()
        {
            return '¥';
        }
    }
}
