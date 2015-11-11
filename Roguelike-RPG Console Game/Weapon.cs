using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike_RPG_Console_Game
{
    public class Weapon : GameItem
    {
        private int damage;

        public Weapon(string name, int damage, int cost)
            : base(cost)
        {
            this.damage = damage;
        }
    }
}
