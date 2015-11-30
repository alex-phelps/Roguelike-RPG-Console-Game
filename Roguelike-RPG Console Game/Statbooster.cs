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
            info = "Boosts your " + stat.ToLower() + " stat.";
        }
        public Statbooster(string stat, int level, int x, int y)
            : base("Level " + level + " " + stat + " Booster", level * 100, x, y)
        {
            this.stat = stat;
            this.level = level;
            info = "Boosts your " + stat.ToLower() + " stat.";
        }

        public override bool UseItem(Player player)
        {
            if (stat == "Attack")
                player.attackDamage += level;
            else if (stat == "Health")
                player.health += 5 * level;
            else if (stat == "Defense")
                player.defense += level;
            else if (stat == "Magic")
                player.magic += level;
            else if (stat == "Resist")
                player.resist += level;

            Console.WriteLine("You used your " + name + "!\nIt increased your " + stat.ToLower() + " stat!");

            return true;
        }
    }
}
