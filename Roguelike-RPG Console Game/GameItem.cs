using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike_RPG_Console_Game
{
    public class GameItem
    {
        protected int cost;

        public GameItem(int cost)
        {
            this.cost = cost;
        }
    }
}
