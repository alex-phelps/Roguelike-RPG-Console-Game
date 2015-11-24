using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike_RPG_Console_Game
{
    public class Room
    {
        public int width { get; private set; }
        public int height { get; private set; }
        public int[] exitPos { get; private set; }

        private Random random;
        private Shopkeeper shopkeeper;
        private Boss boss;
        private int coinCount;
        private int[,] coinPos;
        private int enemyCount;
        private List<Enemy> enemies;
        private List<GameItem> items;
        private bool exitOpen = true;

        private char[,] map;

        public Room(int width, int height, int coinCount, List<EnemyType> enemyTypes, int enemyCount, List<RandomItemType> randomItemType)
        {
            random = new Random();

            this.width = width;
            this.height = height;
            this.coinCount = coinCount;
            this.enemyCount = enemyCount;

            enemies = new List<Enemy>();
            items = new List<GameItem>();

            map = new char[height, (width + 1)];
            coinPos = new int[coinCount, 2];

            for (int i = 0; i < coinCount; i++)
            {
                System.Threading.Thread.Sleep(10);
                coinPos[i, 0] = random.Next(1, height - 1);
                coinPos[i, 1] = random.Next(1, width - 1);
            }

            exitPos = new int[2];
            exitPos[0] = random.Next(1, height - 1);
            exitPos[1] = random.Next(1, width - 1);

            for (int i = 0; i < enemyCount; i++)
            {
                System.Threading.Thread.Sleep(10);
                EnemyType enemyType = enemyTypes.ElementAt(random.Next(enemyTypes.Count));

                int x = random.Next(1, width - 1);
                int y = random.Next(1, height - 1);

                if (!(x == width / 2 && y == height / 2))
                {
                    if (enemyType == EnemyType.rat)
                        enemies.Add(new Rat(x, y));
                    else if (enemyType == EnemyType.weakZombie)
                        enemies.Add(new WeakZombie(x, y));
                    else if (enemyType == EnemyType.boneman)
                        enemies.Add(new Boneman(x, y));
                }
            }

            RandomItemType itemType = randomItemType.ElementAt(random.Next(randomItemType.Count));

            int itemx = random.Next(1, width - 1);
            int itemy = random.Next(1, height - 1);

            if (itemType == RandomItemType.basicHealthTonic)
                items.Add(new HealthTonicBasic(itemx, itemy));
            else if (itemType == RandomItemType.statBooster)
            {
                int stat = random.Next(0, 5);

                if (stat == 0)
                    items.Add(new Statbooster("Attack", 1, itemx, itemy));
                else if (stat == 1)
                    items.Add(new Statbooster("Health", 1, itemx, itemy));
                else if (stat == 2)
                    items.Add(new Statbooster("Defense", 1, itemx, itemy));
                else if (stat == 3)
                    items.Add(new Statbooster("Resist", 1, itemx, itemy));
                else if (stat == 4)
                    items.Add(new Statbooster("Magic", 1, itemx, itemy));
            }
        }

        public Room(int width, int height, Shopkeeper shopkeeper)
        {
            random = new Random();

            this.width = width;
            this.height = height;
            this.shopkeeper = shopkeeper;
            this.coinCount = 0;
            this.enemyCount = 0;

            enemies = new List<Enemy>();
            items = new List<GameItem>();

            map = new char[height, (width + 1)];
            coinPos = new int[coinCount, 2];

            exitPos = new int[2] {height - 2, (width - 1) / 2};

            shopkeeper.y = 2;
            shopkeeper.x = (width - 1) / 2;
        }

        public Room(int width, int height, Boss boss)
        {
            random = new Random();

            this.width = width;
            this.height = height;
            this.coinCount = 0;
            this.enemyCount = 0;

            exitOpen = false;

            enemies = new List<Enemy>();
            items = new List<GameItem>();

            this.boss = boss;

            map = new char[height, (width + 1)];
            coinPos = new int[coinCount, 2];

            exitPos = new int[2] { height - 2, (width - 1) / 2 };

            boss.y = 2;
            boss.x = (width - 1) / 2;
        }

        public bool Update(Player player)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width + 1; x++)
                {
                    if (x == width)
                        map[y, x] = '\n';
                    else if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                        map[y, x] = '#';
                    else map[y, x] = '=';
                }
            }

            for (int i = 0; i < coinPos.GetLength(0); i++ )
            {
                if (player.y == coinPos[i, 0] && player.x == coinPos[i, 1])
                {
                    coinPos[i, 0] = 0;
                    coinPos[i, 1] = 0;

                    player.gold += (int)Math.Ceiling(player.level / 2.0);
                }
                
                if (!(coinPos[i, 0] == 0 && coinPos[i, 1] == 0))
                    map[coinPos[i, 0], coinPos[i, 1]] = 'c';

            }

            if (exitOpen)
            {
                map[exitPos[0], exitPos[1]] = '█';

                if (exitPos[0] == player.y && exitPos[1] == player.x)
                    return true;
            }

            List<Enemy> deadEnemies = new List<Enemy>();
            List<GameItem> collectedItems = new List<GameItem>();

            foreach (GameItem item in items)
            {
                map[item.y, item.x] = item.ToChar();

                if (item.x == player.x && item.y == player.y)
                {
                    player.inventory.Add(item);
                    collectedItems.Add(item);
                }
            }

            foreach (Enemy e in enemies)
            {
                e.Update(player);
                map[e.y, e.x] = e.ToChar();

                if (e.y == player.y && e.x == player.x)
                {
                    BattleScreen battle = new BattleScreen(player, e);
                    if (battle.DoBattle())
                        deadEnemies.Add(e);
                    else Environment.Exit(0);
                }
            }

            foreach (GameItem i in collectedItems)
            {
                items.Remove(i);
            } 
            
            foreach (Enemy e in deadEnemies)
            {
                enemies.Remove(e);
            }

            if (shopkeeper != null)
            {
                map[shopkeeper.y, shopkeeper.x] = shopkeeper.ToChar();

                if (player.x == shopkeeper.x && player.y == shopkeeper.y)
                {
                    shopkeeper.Shop(player);
                    player.y++;
                }
            }

            if (boss != null)
            {
                map[boss.y, boss.x] = boss.ToChar();

                if (player.x == boss.x && player.y == boss.y)
                {
                    BattleScreen battle = new BattleScreen(player, boss);
                    if (battle.DoBattle())
                    {
                        player.y++;
                        exitOpen = true;
                        map[boss.y, boss.x] = boss.itemDrop.ToChar();
                        boss.itemDrop.x = boss.x;
                        boss.itemDrop.y = boss.y;
                        items.Add(boss.itemDrop);
                        boss = null;
                    }
                    else Environment.Exit(0);
                }
            }


            map[player.y, player.x] = '@';

            return false;

        }

        public override string ToString()
        {
            string s = "";

            foreach (char c in map)
            {
                s += c;
            }

            return s;
        }
    }
}
