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

            baseHealth = 8;
            baseAttack = 8;
            expDropBase = 5;
            goldDropBase = 2;
            baseResist = 4;

            healthModifier = 1.6f;
            attackModifier = 2.3f;
            expModifier = 1.7f;

            effect = WeaponEffect.penetrate;

            health = maxHealth;

            SetupStats();
        }

        public override char ToChar()
        {
            return '¥';
        }
    }
}
