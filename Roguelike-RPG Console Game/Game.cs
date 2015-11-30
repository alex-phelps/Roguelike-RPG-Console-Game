using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike_RPG_Console_Game
{
    public class Game
    {
        static void Main(string[] args)
        {
            Player player = CreateCharacter();
            RoomGenerator roomGenerator = new RoomGenerator(player);

            Console.Clear();
            Console.WriteLine("###Controls###");
            Console.WriteLine("\nArrow Keys: Move");
            Console.WriteLine("Enter: Select");
            Console.WriteLine("Escape: Back");
            Console.WriteLine("B: Inventory");

            Console.ReadKey();

            while (true)
            {
                Room room = roomGenerator.NextRoom();
                player.x = room.width / 2;
                player.y = room.height / 2;

                while (!room.Update(player))
                {
                    string roomString = room.ToString();

                    Console.Clear();

                    Console.WriteLine("Health: " + player.healthBar);
                    Console.WriteLine("Room: " + player.dungeonLevel + " Gold: " + player.gold);
                    Console.WriteLine(roomString);

                    ConsoleKey key = Console.ReadKey().Key;

                    player.Update(key, room);
                }

                player.dungeonLevel++;
            }
        }

        private static Player CreateCharacter()
        {
            int selectedCategory = 0;

            string name = "None";
            int gender = 0;
            int affinity = 0;

            while (true)
            {
                if (selectedCategory == 0) //Gender
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("###Character Creation###");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("##Gender##");

                        if (gender == 0)
                            Console.WriteLine("#Male# =Female=");
                        else Console.WriteLine("=Male= #Female#");

                        Console.WriteLine();
                        Console.WriteLine("==Name==");
                        Console.WriteLine("$ " + name);
                        Console.WriteLine();
                        Console.WriteLine("==Affinity==");

                        if (affinity == 0)
                            Console.WriteLine("$Sun$ =Moon= =Stars=");
                        else if (affinity == 1)
                            Console.WriteLine("=Sun= $Moon$ =Stars=");
                        else Console.WriteLine("=Sun= =Moon= $Stars$");

                        Console.WriteLine();
                        Console.WriteLine("==Confirm==");

                        ConsoleKey key = Console.ReadKey().Key;

                        if (key == ConsoleKey.UpArrow)
                        {
                            if (selectedCategory == 0)
                                selectedCategory = 3;
                            else selectedCategory--;
                            break;
                        }
                        else if (key == ConsoleKey.DownArrow)
                        {
                            if (selectedCategory == 3)
                                selectedCategory = 0;
                            else selectedCategory++;
                            break;
                        }
                        else if (key == ConsoleKey.LeftArrow)
                        {
                            if (gender == 0)
                                gender = 1;
                            else gender--;
                        }
                        else if (key == ConsoleKey.RightArrow)
                        {
                            if (gender == 1)
                                gender = 0;
                            else gender++;
                        }
                    }
                }
                else if (selectedCategory == 1) //Name
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("###Character Creation###");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("==Gender==");

                        if (gender == 0)
                            Console.WriteLine("$Male$ =Female=");
                        else Console.WriteLine("=Male= $Female$");

                        Console.WriteLine();
                        Console.WriteLine("##Name##");
                        Console.WriteLine("> " + name);
                        Console.WriteLine();
                        Console.WriteLine("==Affinity==");

                        if (affinity == 0)
                            Console.WriteLine("$Sun$ =Moon= =Stars=");
                        else if (affinity == 1)
                            Console.WriteLine("=Sun= $Moon$ =Stars=");
                        else Console.WriteLine("=Sun= =Moon= $Stars$");

                        Console.WriteLine();
                        Console.WriteLine("==Confirm==");

                        ConsoleKey key = Console.ReadKey().Key;

                        if (key == ConsoleKey.UpArrow)
                        {
                            if (selectedCategory == 0)
                                selectedCategory = 3;
                            else selectedCategory--;
                            break;
                        }
                        else if (key == ConsoleKey.DownArrow)
                        {
                            if (selectedCategory == 3)
                                selectedCategory = 0;
                            else selectedCategory++;
                            break;
                        }
                        else if (key == ConsoleKey.Enter)
                        {
                            Console.WriteLine();
                            Console.Write("Enter your name: ");

                            name = Console.ReadLine();
                        }
                    }
                }
                else if (selectedCategory == 2) //Affinty
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("###Character Creation###");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("==Gender==");

                        if (gender == 0)
                            Console.WriteLine("$Male$ =Female=");
                        else Console.WriteLine("=Male= $Female$");

                        Console.WriteLine();
                        Console.WriteLine("==Name==");
                        Console.WriteLine("$ " + name);
                        Console.WriteLine();
                        Console.WriteLine("##Affinity##");

                        if (affinity == 0)
                            Console.WriteLine("#Sun# =Moon= =Stars=");
                        else if (affinity == 1)
                            Console.WriteLine("=Sun= #Moon# =Stars=");
                        else Console.WriteLine("=Sun= =Moon= #Stars#");

                        Console.WriteLine();
                        Console.WriteLine("==Confirm==");

                        ConsoleKey key = Console.ReadKey().Key;

                        if (key == ConsoleKey.UpArrow)
                        {
                            if (selectedCategory == 0)
                                selectedCategory = 3;
                            else selectedCategory--;
                            break;
                        }
                        else if (key == ConsoleKey.DownArrow)
                        {
                            if (selectedCategory == 3)
                                selectedCategory = 0;
                            else selectedCategory++;
                            break;
                        }
                        else if (key == ConsoleKey.LeftArrow)
                        {
                            if (affinity == 0)
                                affinity = 2;
                            else affinity--;
                        }
                        else if (key == ConsoleKey.RightArrow)
                        {
                            if (affinity == 2)
                                affinity = 0;
                            else affinity++;
                        }
                    }
                }
                else if (selectedCategory == 3)
                {
                    while (true)
                    {
                        Console.Clear();
                    Console.WriteLine("###Character Creation###");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("==Gender==");

                    if (gender == 0)
                        Console.WriteLine("$Male$ =Female=");
                    else Console.WriteLine("=Male= $Female$");

                    Console.WriteLine();
                    Console.WriteLine("==Name==");
                    Console.WriteLine("$ " + name);
                    Console.WriteLine();
                    Console.WriteLine("==Affinity==");

                    if (affinity == 0)
                        Console.WriteLine("$Sun$ =Moon= =Stars=");
                    else if (affinity == 1)
                        Console.WriteLine("=Sun= $Moon$ =Stars=");
                    else Console.WriteLine("=Sun= =Moon= $Stars$");

                    Console.WriteLine();
                    Console.WriteLine("##Confirm##");

                    ConsoleKey key = Console.ReadKey().Key;

                    if (key == ConsoleKey.UpArrow)
                    {
                        if (selectedCategory == 0)
                            selectedCategory = 3;
                        else selectedCategory--;
                        break;
                    }
                    else if (key == ConsoleKey.DownArrow)
                    {
                        if (selectedCategory == 3)
                            selectedCategory = 0;
                        else selectedCategory++;
                        break;
                    }
                    else if (key == ConsoleKey.Enter)
                    {
                        string trueGender;
                        int trueAffinity;
                        string weaponName;

                        if (gender == 0)
                            trueGender = "Male";
                        else trueGender = "Female";

                        if (affinity == 0)
                            trueAffinity = 1;
                        else if (affinity == 1)
                            trueAffinity = -1;
                        else trueAffinity = 0;

                        if (trueAffinity == -1)
                            weaponName = "Wooden Staff";
                        else weaponName = "Wooden Sword";


                        return new Player(name, trueGender, trueAffinity, new Weapon(weaponName, 2, 40));
                    }
                    }
                }
            }

            return new Player("None", "Male", 1, new Weapon("Wooden Sword", 2, 40));
        }
    }
}
