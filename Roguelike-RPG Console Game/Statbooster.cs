using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike_RPG_Console_Game
{
    public class Statbooster : GameItem
    {
        string stat;
        int level;

        public Statbooster(string stat, int level) : base("Level " + level + " " + stat + " Booster", level * 100)
        {
            this.stat = stat;
            this.level = level;
            info = "Boosts your " + stat.ToLower() + " stat by " + level + " amount.";
        }

        public override bool UseItem(Player player)
        {
            if (stat.ToString() == "Attack")
            {
                player.attackDamage += level;
            }
            else if (stat.ToString() == "Health")
            {
                player.health += level;
            }
            else if (stat.ToString() == "Defense")
            {
                player.defence += level;
            }

            Console.WriteLine("You used your " + name + "!\nIt increased your " + stat.ToLower() + " stat!");

            return true;
        }
    }
}
