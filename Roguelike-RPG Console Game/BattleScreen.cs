using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike_RPG_Console_Game
{
    public class BattleScreen
    {
        private Random random;
        private Player player;
        private Enemy enemy;

        public BattleScreen(Player player, Enemy enemy)
        {
            random = new Random();

            this.player = player;
            this.enemy = enemy;
        }

        public bool DoBattle()
        {
            bool? battleWon = null;

            while (battleWon == null)
            {
                Console.Clear();
                Console.WriteLine(enemy.ToString());
                Console.WriteLine("Your Health: " + player.healthBar);
                Console.WriteLine();
                Console.WriteLine("Attack: A");
                Console.WriteLine("Bag: B");

                ConsoleKey key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.A:
                        Console.Clear();
                        Console.WriteLine(enemy.ToString());
                        Console.WriteLine("Your Health: " + player.healthBar);
                        Console.WriteLine();

                        player.Attack(enemy);

                        Console.Clear();
                        Console.WriteLine(enemy.ToString());
                        Console.WriteLine("Your Health: " + player.healthBar);
                        Console.WriteLine();

                        if (!enemy.alive)
                        {
                            battleWon = true;
                            break;
                        }

                        System.Threading.Thread.Sleep(1000);
                        enemy.Attack(player);

                        if (!player.alive)
                        {
                            battleWon = false;
                            break;
                        }

                        break;
                    
                    case ConsoleKey.B:
                        player.CheckInventory();
                        break;
                }
            }

            Console.Clear();

            if ((bool)battleWon)
            {
                Console.WriteLine("You won!\n");

                player.Loot(enemy);

                return true;
            }
            else
            {
                Console.WriteLine("You Lost!\n");
                Console.ReadKey();
                return false;
            }

        }
    }
}
