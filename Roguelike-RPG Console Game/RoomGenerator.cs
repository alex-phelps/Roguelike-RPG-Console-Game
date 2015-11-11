using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike_RPG_Console_Game
{
    public class RoomGenerator
    {
        private Random random;

        public RoomGenerator()
        {
            random = new Random();
        }

        public Room GenRandomRoom()
        {
            int width = random.Next(8, 60);
            int height = random.Next(8, 20);
            int coinCount = random.Next(0, (width * height) / 30);

            return new Room(width, height, coinCount);
        }
    }
}
