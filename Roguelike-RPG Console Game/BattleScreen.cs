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
            bool hasMagic = false;

            foreach (GameItem item in player.inventory)
            {
                if (item is MagicWeapon)
                {
                    hasMagic = true;
                    break;
                }
            }

            while (battleWon == null)
            {
                Console.Clear();
                Console.WriteLine(enemy.ToString());
                Console.WriteLine("Your Health: " + player.healthBar);
                Console.WriteLine();
                Console.WriteLine("Attack: A");
                if (hasMagic)
                    Console.WriteLine("Magic: M");
                Console.WriteLine("Inventory: B");

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

                    case ConsoleKey.M:

                        List<MagicWeapon> magicWeapons = new List<MagicWeapon>();

                        foreach (GameItem item in player.inventory)
                        {
                            if (item is MagicWeapon)
                                magicWeapons.Add((MagicWeapon)item);
                        }

                        int selectedItem = 0;

                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine(enemy.ToString());
                            Console.WriteLine("Your Health: " + player.healthBar);
                            Console.WriteLine("\n");

                            foreach (MagicWeapon m in magicWeapons)
                            {
                                if (magicWeapons.IndexOf(m) == selectedItem)
                                    Console.Write(">> ");
                                else Console.Write("$  ");

                                Console.WriteLine(m.name);
                            }

                            Console.WriteLine("\nBack: Esc");
                            
                            ConsoleKey key2 = Console.ReadKey().Key;


                            if (key == ConsoleKey.UpArrow)
                            {
                                if (selectedItem == 0)
                                    selectedItem = magicWeapons.Count - 1;
                                else selectedItem--;
                            }
                            else if (key2 == ConsoleKey.DownArrow)
                            {
                                if (selectedItem == magicWeapons.Count - 1)
                                    selectedItem = 0;
                                else selectedItem++;
                            }
                            else if (key2 == ConsoleKey.Enter)
                            {
                                Console.Clear();
                                Console.WriteLine(enemy.ToString());
                                Console.WriteLine("Your Health: " + player.healthBar);
                                Console.WriteLine("\n");

                                player.MagicAttack(enemy, magicWeapons[selectedItem]);

                                Console.Clear();
                                Console.WriteLine(enemy.ToString());
                                Console.WriteLine("Your Health: " + player.healthBar);
                                Console.WriteLine("\n");

                                if (!enemy.alive)
                                {
                                    battleWon = true;
                                    break;
                                }

                                System.Threading.Thread.Sleep(1000);
                                enemy.Attack(player);

                                Console.Clear();
                                Console.WriteLine(enemy.ToString());
                                Console.WriteLine("Your Health: " + player.healthBar);
                                Console.WriteLine("\n");

                                if (!player.alive)
                                {
                                    battleWon = false;
                                    break;
                                }

                            }
                            else if (key2 == ConsoleKey.Escape)
                                break;
                        }

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
