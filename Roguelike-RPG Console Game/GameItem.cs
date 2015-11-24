using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike_RPG_Console_Game
{
    
    public class GameItem
    {
        public string name { get; protected set; }
        public string info { get; protected set; }
        public int x;
        public int y;
        public int cost { get; protected set; }
        private Random random;
        protected int randomId;

        public GameItem(string name, int cost)
        {
            this.cost = cost;
            this.name = name;

            random = new Random();

            randomId = random.Next(-255, 255);
        }
        public GameItem(string name, int cost, int x, int y)
        {
            this.cost = cost;
            this.name = name;
            this.x = x;
            this.y = y;

            random = new Random();

            randomId = random.Next(-255, 255);
        }

        public virtual bool UseItem(Player player)
        {
            Console.WriteLine("NO USE");

            return true;
        }

        public virtual char ToChar()
        {
            return 'º';
        }
    }
}
