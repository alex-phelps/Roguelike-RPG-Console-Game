using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike_RPG_Console_Game
{
    public class Rat : Enemy
    {
        Random random;

        public Rat(int x, int y)
        {
            this.x = x;
            this.y = y;

            random = new Random();

            level = random.Next(1, 2);
            int modifier = Convert.ToInt32(1.5f * level);

            baseHealth = 8;
            baseAttack = 4;
            expDropBase = 2;
            goldDropBase = 2;
            baseDefence = 0;

            health += modifier;
            attackDamage += modifier;
            expDropped += modifier;
            goldDropped += modifier;
        }

        public override char ToChar()
        {
            return '«';
        }
    }
}
