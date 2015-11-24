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
            Weapon woodSword = new Weapon("Wood Sword", 1, 30);
            Player player = new Player(woodSword);
            RoomGenerator roomGenerator = new RoomGenerator(player);


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

                    Console.WriteLine("Room: " + player.dungeonLevel);
                    Console.WriteLine("Health: " + player.healthBar);
                    Console.WriteLine(roomString);

                    ConsoleKey key = Console.ReadKey().Key;

                    player.Update(key, room);

                }

                player.dungeonLevel++;
            }
        }
    }
}
