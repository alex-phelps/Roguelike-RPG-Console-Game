﻿using System;
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
        private int coinCount;
        private int[,] coinPos;
        private int enemyCount;
        private List<Enemy> enemies;

        private char[,] map;

        public Room(int width, int height, int coinCount, List<EnemyType> enemyTypes, int enemyCount)
        {
            random = new Random();

            this.width = width;
            this.height = height;
            this.coinCount = coinCount;
            this.enemyCount = enemyCount;

            enemies = new List<Enemy>();

            map = new char[height, (width + 1)];
            coinPos = new int[coinCount, 2];

            for (int i = 0; i < coinCount; i++)
            {
                coinPos[i, 0] = random.Next(1, height - 1);
                coinPos[i, 1] = random.Next(1, width - 1);
            }

            exitPos = new int[2];
            exitPos[0] = random.Next(1, height - 1);
            exitPos[1] = random.Next(1, width - 1);

            for (int i = 0; i < enemyCount; i++)
            {
                EnemyType enemyType = enemyTypes.ElementAt(random.Next(enemyTypes.Count - 1));

                int x = random.Next(1, width - 1);
                int y = random.Next(1, height - 1);

                if (enemyType == EnemyType.rat)
                {
                    enemies.Add(new Rat(x, y));
                }
            }
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

            map[exitPos[0], exitPos[1]] = '█';
            map[player.y, player.x] = '@';

            if (exitPos[0] == player.y && exitPos[1] == player.x)
                return true;

            foreach (Enemy e in enemies)
            {
                e.Update(player);
                map[e.y, e.x] = e.ToChar();
            }

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