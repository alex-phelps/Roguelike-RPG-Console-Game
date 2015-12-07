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
            baseDefense = 2;
            expDropBase = 5;
            goldDropBase = 2;
            baseResist = 4;

            healthModifier = 1.6f;
            attackModifier = 2.3f;
            defenseModifier = 1f;
            expModifier = 1.7f;

            effect = WeaponEffect.penetrate;

            health = maxHealth;

            SetupStats();
        }

        public Boneman(int x, int y, int level)
            : base(x, y)
        {
            name = "Boneman";
            this.level = level;

            baseHealth = 8;
            baseAttack = 8;
            baseDefense = 2;
            expDropBase = 5;
            goldDropBase = 2;
            baseResist = 4;

            healthModifier = 1.6f;
            attackModifier = 2.3f;
            defenseModifier = 1f;
            expModifier = 1.7f;

            effect = WeaponEffect.penetrate;

            health = maxHealth;

            SetupStats();
        }

        public override char ToChar()
        {
            return '¥';
        }

        public override string SaveDataAsString()
        {
            string saveData = "";
            saveData += "type:boneman:";
            saveData += "x:" + x + ":";
            saveData += "y:" + y + ":";
            saveData += "level:" + level + ":";
            saveData += "end:";
            return saveData;
        }
    }
}
