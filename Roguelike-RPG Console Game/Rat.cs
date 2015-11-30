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

            level = random.Next(1, 5);

            baseHealth = 8;
            baseAttack = 4;
            expDropBase = 2;
            goldDropBase = 2;

            healthModifier = 2;

            SetupStats();
        }

        public override char ToChar()
        {
            return '«';
        }
    }
}
