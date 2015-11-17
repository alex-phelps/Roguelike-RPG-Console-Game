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
            Weapon woodSword = new Weapon("Wood Sword", 1, 5);
            Player player = new Player(woodSword);
            RoomGenerator roomGenerator = new RoomGenerator(player);

            while (true)
            {
                Room room = roomGenerator.GenRandomRoom();
                player.x = room.width / 2;
                player.y = room.height / 2;

                while (!room.Update(player))
                {
                    string roomString = room.ToString();

                    Console.Clear();

                    Console.WriteLine("Level: " + player.level + "  Gold: " + player.gold + "  Room: " + player.dungeonLevel);
                    Console.WriteLine("Exp: " + player.exp);
                    Console.WriteLine(roomString);

                    ConsoleKey key = Console.ReadKey().Key;

                    player.Update(key, room);

                }

                player.dungeonLevel++;
            }
        }
    }
}
