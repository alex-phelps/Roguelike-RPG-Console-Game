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
            : base(5, "Novice Fire Tome", 400)
        {
            effect = WeaponEffect.burn;
            info = "A basic fire tome. Has a chance to burn the enemy.";
        }

        public override char ToChar()
        {
            return '■';
        }

        public override string SaveDataAsString()
        {
            string saveData = "";
            saveData += "type:noviceFireTome:\n";
            saveData += "name:" + name + "\n";
            saveData += "x:" + x + "\n";
            saveData += "y:" + y + "\n";
            return saveData;
        }
    }
}
