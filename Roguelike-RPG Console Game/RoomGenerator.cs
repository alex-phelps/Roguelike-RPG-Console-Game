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
        private Player player;

        public RoomGenerator(Player player)
        {
            random = new Random();
            this.player = player;
        }

        public Room GenRandomRoom()
        {
            int width = random.Next(8, 60);
            int height = random.Next(8, 20);
            int coinCount = random.Next(0, (width * height) / 50);
            int enemyCount = random.Next(1, (width * height) / 80);


            if (player.dungeonLevel < 10)
            {
                List<EnemyType> enemies = new List<EnemyType>();
                enemies.Add(EnemyType.rat);

                return new Room(width, height, coinCount, enemies, enemyCount);
            }
            else return new Room(width, height, coinCount, null, 0);

        }
    }
}
