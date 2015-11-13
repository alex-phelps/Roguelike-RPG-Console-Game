using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike_RPG_Console_Game
{
    public class Player
    {
        public int health = 100;
        public int level = 1;
        public int exp = 0;
        public int gold = 0;
        public int dungeonLevel = 0;
        public List<GameItem> inventory;
        public Weapon weapon;
        public int x = 0;
        public int y = 0;

        public Player(Weapon weapon)
        {
            inventory = new List<GameItem>();
            this.weapon = weapon;
        }

        public void Update(ConsoleKey key, Room room)
        {
            if (key == ConsoleKey.UpArrow)
            {
                y--;

                if (y == 0 || y == room.height - 1)
                    y++;
            }
            if (key == ConsoleKey.DownArrow)
            {
                y++;

                if (y == 0 || y == room.height - 1)
                    y--;
            }
            if (key == ConsoleKey.LeftArrow)
            {
                x--;

                if (x == 0 || x == room.width - 1)
                    x++;
            }
            if (key == ConsoleKey.RightArrow)
            {
                x++;

                if (x == 0 || x == room.width - 1)
                    x--;
            }

            if (exp == 100)
            {
                exp = 0;
                level++;
            }
        }
    }
}
