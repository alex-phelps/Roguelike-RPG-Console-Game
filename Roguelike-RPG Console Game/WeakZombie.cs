using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike_RPG_Console_Game
{
    public class WeakZombie : Enemy
    {
        public WeakZombie(int x, int y)
            : base(x, y)
        {
            name = "Zombie";
            level = random.Next(5, 9);

            baseHealth = 10;
            baseAttack = 4;
            baseDefense = 2;
            expDropBase = 6;
            goldDropBase = 2;

            healthModifier = 1.8f;

            SetupStats();
        }

        public override char ToChar()
        {
            return '¶';
        }

        public override string SaveDataAsString()
        {
            string saveData = "";
            saveData += "type:weakZombie\n";
            saveData += "x:" + x + "\n";
            saveData += "y:" + y + "\n";
            saveData += "level:" + level + "\n";
            return saveData;
        }
    }
}
