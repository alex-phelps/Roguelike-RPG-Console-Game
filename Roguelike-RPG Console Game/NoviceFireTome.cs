using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike_RPG_Console_Game
{
    public class NoviceFireTome : MagicWeapon
    {
        public NoviceFireTome()
            : base(8, "Novice Fire Tome", 400)
        {
            effect = Enums.WeaponEffect.burn;
            info = "A basic fire tome. Has a chance to burn the enemy.";
        }

        public override char ToChar()
        {
            return '▥';
        }
    }
}
