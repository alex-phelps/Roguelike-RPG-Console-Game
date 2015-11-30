using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike_RPG_Console_Game
{
    public class Shopkeeper
    {
        public int x;
        public int y;

        private List<GameItem> stock;

        public Shopkeeper(byte level)
        {
            stock = new List<GameItem>();

            switch (level)
            {
                case 1:
                    stock.Add(new HealthTonicBasic());
                    stock.Add(new Weapon("Basic Bronze Sword", 4, 200));
                    stock.Add(new Statbooster("Defense", 1));
                    stock.Add(new Statbooster("Health", 1));
                    break;
            }
        }

        public void Shop(Player player)
        {
            int selectedItem = 0;

            while (true)
            {

                Console.Clear();
                Console.WriteLine("###Buy### ===Sell===\nGold: " + player.gold);

                if (!(selectedItem <= stock.Count - 1))
                    selectedItem = stock.Count - 1;

                foreach (GameItem item in stock)
                {
                    if (stock.IndexOf(item) == selectedItem)
                        Console.Write(">> ");
                    else Console.Write("$  ");

                    Console.WriteLine(item.name);
                }

                Console.WriteLine("Info: " + stock[selectedItem].info);
                Console.WriteLine("Cost: " + stock[selectedItem].cost + " gold");

                ConsoleKey key = Console.ReadKey().Key;

                if (key == ConsoleKey.UpArrow)
                {
                    if (selectedItem == 0)
                        selectedItem = stock.Count - 1;
                    else selectedItem--;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    if (selectedItem == stock.Count - 1)
                        selectedItem = 0;
                    else selectedItem++;
                }
                else if (key == ConsoleKey.Enter)
                {
                    if (player.gold >= stock[selectedItem].cost)
                    {
                        player.inventory.Add(stock[selectedItem]);
                        player.gold -= stock[selectedItem].cost;
                        Console.WriteLine("You bought a " + stock[selectedItem].name + "!");

                        if (stock[selectedItem] is Weapon)
                        {
                            Console.WriteLine("Would you like to equip your new " + stock[selectedItem].name + "? (y/n)");

                            if (Console.ReadKey().Key == ConsoleKey.Y)
                                player.weapon = (Weapon)stock[selectedItem];
                        }
                        else Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("You can't afford that!");
                        Console.ReadKey();
                    }
                }
                else if (key == ConsoleKey.RightArrow)
                {
                    int selectedItem2 = 0;

                    while (true)
                    {

                        Console.Clear();
                        Console.WriteLine("===Buy=== ###Sell###\nGold: " + player.gold);

                        if (!(selectedItem2 <= player.inventory.Count - 1))
                            selectedItem2 = player.inventory.Count - 1;

                        foreach (GameItem item in player.inventory)
                        {
                            if (player.inventory.IndexOf(item) == selectedItem2)
                                Console.Write(">> ");
                            else Console.Write("$  ");

                            Console.WriteLine(item.name);
                        }

                        Console.WriteLine("Info: " + player.inventory[selectedItem2].info);
                        Console.WriteLine("Value: " + player.inventory[selectedItem2].cost + " gold");

                        ConsoleKey key2 = Console.ReadKey().Key;

                        if (key2 == ConsoleKey.UpArrow)
                        {
                            if (selectedItem2 == 0)
                                selectedItem2 = player.inventory.Count - 1;
                            else selectedItem2--;
                        }
                        else if (key2 == ConsoleKey.DownArrow)
                        {
                            if (selectedItem2 == player.inventory.Count - 1)
                                selectedItem2 = 0;
                            else selectedItem2++;
                        }
                        else if (key2 == ConsoleKey.Enter)
                        {
                            Console.WriteLine();
                            Console.Write("Would you like to sell your " + player.inventory[selectedItem2].name + " for ");
                            Console.WriteLine(player.inventory[selectedItem2].cost + " gold? (y/n)");

                            ConsoleKey key3 = Console.ReadKey().Key;

                            if (key3 == ConsoleKey.Y)
                            {
                                if (player.inventory[selectedItem2] is Weapon && player.weapon == (Weapon)player.inventory[selectedItem2])
                                {
                                    player.weapon = new Weapon("Fist", 0, 0);
                                }

                                player.gold += player.inventory[selectedItem2].cost;
                                player.inventory.Remove(player.inventory[selectedItem2]);
                            }
                        }
                        else if (key2 == ConsoleKey.LeftArrow)
                            break;
                        else if (key2 == ConsoleKey.Escape)
                            return;
                    }
                }
                else if (key == ConsoleKey.Escape)
                    break;
            }
        }

        public char ToChar()
        {
            return '£';
        }
    }
}
