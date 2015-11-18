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
            : base("Basic Health Tonic", 10)
        {
        }

        public HealthTonicBasic(int x, int y)
            : base("Basic Health Tonic", 10, x, y)
        {
        }

        public override bool UseItem(Player player)
        {
            player.health += 25;
            if (player.health > player.maxHealth)
                player.health = player.maxHealth;

            Console.WriteLine("You used the Health Tonic!\nIt restored 25 health!");
            return true;
        }
    }
}
