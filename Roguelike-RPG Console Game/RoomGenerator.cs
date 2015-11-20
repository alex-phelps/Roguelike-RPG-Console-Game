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

        public Room NextRoom()
        {
            int width = random.Next(8, 60);
            int height = random.Next(8, 20);
            int coinCount = random.Next(0, (width * height) / 50);
            int enemyCount = random.Next(1, ((width * height) / 80) + 1);

            List<Enums.EnemyType> enemies = new List<Enums.EnemyType>();
            List<Enums.RandomItemType> items = new List<Enums.RandomItemType>();
            items.Add(Enums.RandomItemType.basicHealthTonic);

            if (player.dungeonLevel < 4)
            {
                enemies.Add(Enums.EnemyType.rat);
            }
            else if (player.dungeonLevel < 9)
            {
                enemies.Add(Enums.EnemyType.rat);
                enemies.Add(Enums.EnemyType.weakZombie);
            }
            else if (player.dungeonLevel == 9)
            {
                return new Room(11, 15, new Shopkeeper(1));
            }
            else if (player.dungeonLevel == 10)
            {
                return new Room(15, 19, new Revenant());
            }

            return new Room(width, height, coinCount, enemies, enemyCount, items);

        }
    }
}
