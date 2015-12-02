using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike_RPG_Console_Game
{
    public class HealthTonicBasic : GameItem
    {
        public HealthTonicBasic()
            : base("Basic Health Tonic", 70)
        {
            info = "Heals 40 health";
        }

        public HealthTonicBasic(int x, int y)
            : base("Basic Health Tonic", 70, x, y)
        {
            info = "Heals 40 health";
        }

        public override bool UseItem(Player player)
        {
            player.health += 40;
            if (player.health > player.maxHealth)
                player.health = player.maxHealth;

            Console.WriteLine("You used the Health Tonic!\nIt restored 40 health!");
            return true;
        }

        public override string SaveDataAsString()
        {
            string saveData = "";
            saveData += "type:healthTonicBasic:\n";
            saveData += "x:" + x + "\n";
            saveData += "y:" + y + "\n";
            return saveData;
        }
    }
}
