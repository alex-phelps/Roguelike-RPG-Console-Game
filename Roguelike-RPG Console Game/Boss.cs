using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike_RPG_Console_Game
{
    public class Boss : Enemy
    {
        public GameItem itemDrop { get; protected set; }

        public Boss() : base(0, 0)
        {
        }

        public override void Update(Player player)
        {
        }

        public override string SaveDataAsString()
        {
            string saveData = "";
            saveData += "name:" + name + "\n";
            saveData += "level:" + level + "\n";
            if (itemDrop != null)
                saveData += "itemDrop:\n" + itemDrop.SaveDataAsString();
            saveData += "effect:" + effect + "\n";
            saveData += "maxHealth:" + maxHealth + "\n";
            saveData += "health:" + health + "\n";
            saveData += "attackDamage:" + attackDamage + "\n";
            saveData += "magic:" + magic + "\n";
            saveData += "defense:" + defense + "\n";
            saveData += "resist:" + resist + "\n";
            saveData += "expDropped:" + expDropped + "\n";
            saveData += "goldDropped:" + goldDropped + "\n";
            saveData += "baseHealth:" + baseHealth + "\n";
            saveData += "baseAttack:" + baseAttack + "\n";
            saveData += "baseMagic:" + baseMagic + "\n";
            saveData += "baseDefense:" + baseDefense + "\n";
            saveData += "baseResist:" + baseResist + "\n";
            saveData += "expDropBase:" + expDropBase + "\n";
            saveData += "goldDropBase:" + goldDropBase + "\n";
            saveData += "healthModifier:" + healthModifier + "\n";
            saveData += "attackModifier:" + attackModifier + "\n";
            saveData += "magicModifier:" + magicModifier + "\n";
            saveData += "defenseModifier:" + defenseModifier + "\n";
            saveData += "resistModifier:" + resistModifier + "\n";
            saveData += "expModifier:" + expModifier + "\n";
            saveData += "goldModifer:" + goldModifier + "\n";
            return saveData;
        }
    }
}
