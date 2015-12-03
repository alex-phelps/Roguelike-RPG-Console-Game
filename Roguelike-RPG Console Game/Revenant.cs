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
            itemDrop = new NoviceFireTome();

            baseHealth = 10;
            baseAttack = 4;
            baseDefense = 4;
            expDropBase = 7;
            goldDropBase = 8;
            baseResist = 2;

            healthModifier = 2;
            expModifier = 1.8f;
            goldModifier = 1.8f;

            effect = WeaponEffect.curse;

            health = maxHealth;

            SetupStats();
        }

        public override char ToChar()
        {
            return '₧';
        }

        public override string SaveDataAsString()
        {
            string saveData = "";
            saveData += "type:revenant:\n";
            saveData += "end:\n";
            return saveData;
        }
    }
}
