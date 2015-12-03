using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
            int race = 0;

            while (true)
            {
                if (selectedCategory == 0) //race
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("###Character Creation###");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("##Race##");

                        if (race == 0)
                            Console.WriteLine("#Human# =Elf= =Orc= =Dwarf=");
                        else if (race == 1)
                            Console.WriteLine("=Human= #Elf# =Orc= =Dwarf=");
                        else if (race == 2)
                            Console.WriteLine("=Human= =Elf= #Orc# =Dwarf=");
                        else if (race == 3)
                            Console.WriteLine("=Human= =Elf= =Orc= #Dwarf#");

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
                        Console.WriteLine("==Confirm==");

                        ConsoleKey key = Console.ReadKey().Key;

                        if (key == ConsoleKey.UpArrow)
                        {
                            selectedCategory = 4;
                            break;
                        }
                        else if (key == ConsoleKey.DownArrow)
                        {
                            selectedCategory++;
                            break;
                        }
                        else if (key == ConsoleKey.LeftArrow)
                        {
                            if (race == 0)
                                race = 3;
                            else race--;
                        }
                        else if (key == ConsoleKey.RightArrow)
                        {
                            if (race == 3)
                                race = 0;
                            else race++;
                        }
                    }
                }
                else if (selectedCategory == 1) //Gender
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("###Character Creation###");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("==Race==");

                        if (race == 0)
                            Console.WriteLine("$Human$ =Elf= =Orc= =Dwarf=");
                        else if (race == 1)
                            Console.WriteLine("=Human= $Elf$ =Orc= =Dwarf=");
                        else if (race == 2)
                            Console.WriteLine("=Human= =Elf= $Orc$ =Dwarf=");
                        else if (race == 3)
                            Console.WriteLine("=Human= =Elf= =Orc= $Dwarf$");

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
                            selectedCategory--;
                            break;
                        }
                        else if (key == ConsoleKey.DownArrow)
                        {
                            selectedCategory++;
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
                else if (selectedCategory == 2) //Name
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("###Character Creation###");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("==Race==");

                        if (race == 0)
                            Console.WriteLine("$Human$ =Elf= =Orc= =Dwarf=");
                        else if (race == 1)
                            Console.WriteLine("=Human= $Elf$ =Orc= =Dwarf=");
                        else if (race == 2)
                            Console.WriteLine("=Human= =Elf= $Orc$ =Dwarf=");
                        else if (race == 3)
                            Console.WriteLine("=Human= =Elf= =Orc= $Dwarf$");

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
                            selectedCategory--;
                            break;
                        }
                        else if (key == ConsoleKey.DownArrow)
                        {
                            selectedCategory++;
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
                else if (selectedCategory == 3) //Affinty
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("###Character Creation###");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("==Race==");

                        if (race == 0)
                            Console.WriteLine("$Human$ =Elf= =Orc= =Dwarf=");
                        else if (race == 1)
                            Console.WriteLine("=Human= $Elf$ =Orc= =Dwarf=");
                        else if (race == 2)
                            Console.WriteLine("=Human= =Elf= $Orc$ =Dwarf=");
                        else if (race == 3)
                            Console.WriteLine("=Human= =Elf= =Orc= $Dwarf$");

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
                            selectedCategory--;
                            break;
                        }
                        else if (key == ConsoleKey.DownArrow)
                        {
                            selectedCategory++;
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
                else if (selectedCategory == 4) //Confirm
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("###Character Creation###");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("==Race==");

                        if (race == 0)
                            Console.WriteLine("$Human$ =Elf= =Orc= =Dwarf=");
                        else if (race == 1)
                            Console.WriteLine("=Human= $Elf$ =Orc= =Dwarf=");
                        else if (race == 2)
                            Console.WriteLine("=Human= =Elf= $Orc$ =Dwarf=");
                        else if (race == 3)
                            Console.WriteLine("=Human= =Elf= =Orc= $Dwarf$");

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
                            selectedCategory--;
                            break;
                        }
                        else if (key == ConsoleKey.DownArrow)
                        {
                            selectedCategory = 0;
                            break;
                        }
                        else if (key == ConsoleKey.Enter)
                        {
                            string trueGender = "";
                            string trueRace = "";
                            int trueAffinity = 0;
                            string weaponName = "Wooden Sword";

                            if (gender == 0)
                                trueGender = "Male";
                            else trueGender = "Female";

                            if (race == 0)
                                trueRace = "Human";
                            else if (race == 1)
                                trueRace = "Elf";
                            else if (race == 2)
                                trueRace = "Orc";
                            else if (race == 3)
                                trueRace = "Dwarf";

                            if (affinity == 0)
                                trueAffinity = 1;
                            else if (affinity == 1)
                                trueAffinity = -1;
                            else trueAffinity = 0;

                            if (trueAffinity == -1)
                                weaponName = "Wooden Staff";


                            return new Player(name, trueRace, trueGender, trueAffinity, new Weapon(weaponName, 2, 40));
                        }
                    }
                }
            }
        }
        
        private static void LoadGame(string filename, out Player player, out Room room)
        {
            StreamReader file = File.OpenText(filename);

            while (!file.EndOfStream)
            {
                string text = file.ReadLine();

                //Get Player Data
                if (text == "player:")
                {
                    string name;
                    string gender;
                    string race;
                    int chosenAffinity;
                    int affinity;
                    int dungeonLevel;
                    int x;
                    int y;
                    int level;
                    int exp;
                    int expNeeded;
                    int gold;
                    Weapon weapon;
                    int maxHealth;
                    int health;
                    int attackDamage;
                    int magic;
                    int defense;
                    int resist;
                    StatusEffect status;
                    List<GameItem> inventory;


                    while (!file.EndOfStream)
                    {
                        text = file.ReadLine();
                        string[] subTexts = text.Split(new string[] { ":" }, StringSplitOptions.None);

                        if (subTexts[0] == "name")
                            name = subTexts[1];
                        else if (subTexts[0] == "gender")
                            gender = subTexts[1];
                        else if (subTexts[0] == "race")
                            race = subTexts[1];
                        else if (subTexts[0] == "chosenAffinity")
                            chosenAffinity = Convert.ToInt32(subTexts[1]);
                        else if (subTexts[0] == "afinity")
                            affinity = Convert.ToInt32(subTexts[1]);
                        else if (subTexts[0] == "dungeonLevel")
                            dungeonLevel = Convert.ToInt32(subTexts[1]);
                        else if (subTexts[0] == "x")
                            x = Convert.ToInt32(subTexts[1]);
                        else if (subTexts[0] == "y")
                            y = Convert.ToInt32(subTexts[1]);
                        else if (subTexts[0] == "level")
                            level = Convert.ToInt32(subTexts[1]);
                        else if (subTexts[0] == "exp")
                            level = Convert.ToInt32(subTexts[1]);
                        else if (subTexts[0] == "expNeeded")
                            expNeeded = Convert.ToInt32(subTexts[1]);
                        else if (subTexts[0] == "gold")
                            gold = Convert.ToInt32(subTexts[1]);
                        else if (subTexts[0] == "weapon")
                        {
                            string weaponName = "none";
                            int cost = 0;
                            int damage = 0;
                            WeaponEffect effect = WeaponEffect.none;
                            int wx = 0, wy = 0;

                            for (int i = 1; i < subTexts.Count(); i += 2)
                            {
                                if (subTexts[i] == "name")
                                    weaponName = subTexts[i + 1];
                                else if (subTexts[i] == "cost")
                                    cost = Convert.ToInt32(subTexts[i + 1]);
                                else if (subTexts[i] == "damage")
                                    damage = Convert.ToInt32(subTexts[i + 1]);
                                else if (subTexts[i] == "effect")
                                {
                                    if (subTexts[i + 1] == "burn")
                                        effect = WeaponEffect.burn;
                                    else if (subTexts[i + 1] == "penetrate")
                                        effect = WeaponEffect.penetrate;
                                    else if (subTexts[i + 1] == "curse")
                                        effect = WeaponEffect.curse;
                                    else if (subTexts[i + 1] == "midas")
                                        effect = WeaponEffect.midas;
                                    else if (subTexts[i + 1] == "wisdom")
                                        effect = WeaponEffect.wisdom;
                                    else effect = WeaponEffect.none;
                                }
                                else if (subTexts[i] == "x")
                                    wx = Convert.ToInt32(subTexts[i + 1]);
                                else if (subTexts[i] == "y")
                                    wy = Convert.ToInt32(subTexts[i + 1]);
                            }

                            weapon = new Weapon(weaponName, damage, cost, effect);
                        }
                        else if (subTexts[0] == "maxHealth")
                            maxHealth = Convert.ToInt32(subTexts[1]);
                        else if (subTexts[0] == "health")
                            health = Convert.ToInt32(subTexts[1]);
                        else if (subTexts[0] == "attackDamage")
                            attackDamage = Convert.ToInt32(subTexts[1]);
                        else if (subTexts[0] == "magic")
                            magic = Convert.ToInt32(subTexts[1]);
                        else if (subTexts[0] == "defense")
                            defense = Convert.ToInt32(subTexts[1]);
                        else if (subTexts[0] == "resist")
                            resist = Convert.ToInt32(subTexts[1]);
                        else if (subTexts[0] == "status")
                        {
                            if (subTexts[1] == "burned")
                                status = StatusEffect.burned;
                            else if (subTexts[1] == "cursed")
                                status = StatusEffect.cursed;
                            else status = StatusEffect.none;
                        }
                        else if (subTexts[0] == "inventory")
                        {
                            string invText = file.ReadLine();
                            string[] subInvTexts = invText.Split(new string[] { ":" }, StringSplitOptions.None);
                            int sPos = 0;

                            inventory = new List<GameItem>();

                            while (true) 
                            {
                                if (subInvTexts[sPos] == "type")
                                {
                                    sPos++;
                                    if (subInvTexts[sPos] == "weapon")
                                    {
                                        sPos++;
                                        if (subInvTexts[sPos] == "name")
                                    }
                                }
                                else if (subInvTexts[sPos] == "end")
                                    break;
                                sPos++;
                            }
                        }
                        else if (subTexts[0] == "end")
                            break;
                    }
                }
                else if (text == "room:")
                {
                    while (!file.EndOfStream)
                    {

                    }
                }
            }

        }
    }
}
