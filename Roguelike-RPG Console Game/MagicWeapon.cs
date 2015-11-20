using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike_RPG_Console_Game
{
    public class MagicWeapon : GameItem
    {
        protected int magicDamage;
        protected Enums.WeaponEffect effect = Enums.WeaponEffect.none;

        public MagicWeapon(int magicDamage, string name, int cost) 
            : base(name, cost)
        {
            this.magicDamage = magicDamage;
            info = "A magical weapon that does " + magicDamage + " magic damage";
        }

        public override bool UseItem(Player player)
        {
            return false;
        }
    }
}
