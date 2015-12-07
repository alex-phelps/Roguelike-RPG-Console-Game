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
            bool loadGameAvalible = false;
            int titleItems = 2;
            int selectedItem = 0;
            Player player = null;
            Room room = null;
            RoomGenerator roomGenerator = null;

            if (File.Exists("Save1.txt") || File.Exists("Save2.txt") || File.Exists("Save3.txt")) 
            {
                loadGameAvalible = true;
                titleItems = 3;
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("TITLE");
                Console.WriteLine();
                if (selectedItem == 0)
                    Console.WriteLine("##New Game##");
                else Console.WriteLine("==New Game==");
                if (loadGameAvalible)
                {
                    if (selectedItem == 1)
                        Console.WriteLine("##Load Game##");
                    else Console.WriteLine("==Load Game==");
                    if (selectedItem == 2)
                        Console.WriteLine("##Options##");
                    else Console.WriteLine("==Options==");
                    if (selectedItem == 3)
                        Console.WriteLine("##Quit##");
                    else Console.WriteLine("==Quit==");
                }
                else
                {
                    if (selectedItem == 1)
                        Console.WriteLine("##Options##");
                    else Console.WriteLine("==Options==");
                    if (selectedItem == 2)
                        Console.WriteLine("##Quit##");
                    else Console.WriteLine("==Quit==");
                }

                ConsoleKey key = Console.ReadKey().Key;

                if (key == ConsoleKey.UpArrow)
                {
                    if (selectedItem == 0)
                        selectedItem = titleItems;
                    else selectedItem--;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    if (selectedItem == titleItems)
                        selectedItem = 0;
                    else selectedItem++;
                }
                else if (key == ConsoleKey.Enter)
                {
                    if (selectedItem == 0) //Create Player
                    {
                        player = CreateCharacter();
                        roomGenerator = new RoomGenerator(player);
                        room = roomGenerator.NextRoom();
                        player.x = room.width / 2;
                        player.y = room.height / 2;
                        break;
                    }
                    else if (loadGameAvalible)
                    {
                        if (selectedItem == 1) //Load game
                        {
                            bool doLoad = false;
                            int selectedSave = 0;

                            while (true)
                            {
                                Console.Clear();
                                if (selectedSave == 0)
                                    Console.WriteLine("##Save 1##");
                                else Console.WriteLine("==Save 1==");
                                if (selectedSave == 1)
                                    Console.WriteLine("##Save 2##");
                                else Console.WriteLine("==Save 2==");
                                if (selectedSave == 2)
                                    Console.WriteLine("##Save 3##");
                                else Console.WriteLine("==Save 3==");
                                if (selectedSave == 3)
                                    Console.WriteLine("##Back##");
                                else Console.WriteLine("==Back==");

                                ConsoleKey key2 = Console.ReadKey().Key;

                                if (key2 == ConsoleKey.UpArrow)
                                {
                                    if (selectedSave == 0)
                                        selectedSave = 3;
                                    else selectedSave--;
                                }
                                else if (key2 == ConsoleKey.DownArrow)
                                {
                                    if (selectedSave == 3)
                                        selectedSave = 0;
                                    else selectedSave++;
                                }
                                else if (key2 == ConsoleKey.Enter)
                                {
                                    if (selectedSave == 0)
                                    {
                                        if (File.Exists("Save1.txt"))
                                        {
                                            doLoad = true;
                                            LoadGame("Save1.txt", out player, out room);
                                            break;
                                        }
                                    }
                                    else if (selectedSave == 1)
                                    {
                                        if (File.Exists("Save2.txt"))
                                        {
                                            doLoad = true;
                                            LoadGame("Save2.txt", out player, out room);
                                            break;
                                        }
                                    }
                                    else if (selectedSave == 2)
                                    {
                                        if (File.Exists("Save3.txt"))
                                        {
                                            doLoad = true;
                                            LoadGame("Save3.txt", out player, out room);
                                            break;
                                        }
                                    }
                                    else if (selectedSave == 3)
                                        break;

                                    Console.WriteLine();
                                    Console.WriteLine("No Save Found!");
                                    Console.ReadKey();
                                }
                            }

                            if (doLoad)
                                break;
                        }
                        else if (selectedItem == 2) //Options
                        {

                        }
                        else Environment.Exit(0); //Quit
                    }
                    else
                    {
                        if (selectedItem == 1) //Options
                        {

                        }
                        else Environment.Exit(0); //Quit
                    }
                }
            }

            Console.Clear();
            Console.WriteLine("###Controls###");
            Console.WriteLine("\nArrow Keys: Move");
            Console.WriteLine("Enter: Select");
            Console.WriteLine("Escape: Back");
            Console.WriteLine("B: Inventory");

            Console.ReadKey();

            while (true)
            {
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
                room = roomGenerator.NextRoom();
                player.x = room.width / 2;
                player.y = room.height / 2;
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

            player = new Player("none", "Human", "Male", 0, new Weapon("Fists", 0, 0));
            room = new Room(1, 1, new Boss());

            while (!file.EndOfStream)
            {
                string text = file.ReadLine();

                //Get Player Data
                if (text == "player:")
                {
                    string name = "none";
                    string gender = "Male";
                    string race = "Human";
                    int chosenAffinity = 0;
                    int affinity = 0;
                    int dungeonLevel = 0;
                    int x = 0;
                    int y = 0;
                    int level = 1;
                    int exp = 0;
                    int expNeeded = 10;
                    int gold = 0;
                    Weapon weapon = new Weapon("Fists", 0, 0);
                    int maxHealth = 0;
                    int health = 0;
                    int attackDamage = 0;
                    int magic = 0;
                    int defense = 0;
                    int resist = 0;
                    StatusEffect status = StatusEffect.none;
                    List<GameItem> inventory = new List<GameItem>();


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
                            exp = Convert.ToInt32(subTexts[1]);
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
                            string[] subInvTexts = invText.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                            int sPos = 0;

                            inventory = new List<GameItem>();

                            while (!file.EndOfStream) 
                            {
                                if (subInvTexts[sPos] == "type")
                                {
                                    sPos++;
                                    if (subInvTexts[sPos] == "weapon")
                                    {
                                        string weaponName = "none";
                                        int cost = 0;
                                        int damage = 0;
                                        WeaponEffect effect = WeaponEffect.none;
                                        int wx = 0, wy = 0;

                                        while (!file.EndOfStream) 
                                        {
                                            sPos++;

                                            if (subInvTexts[sPos] == "name")
                                            {
                                                sPos++;
                                                weaponName = subInvTexts[sPos];
                                            }
                                            else if (subInvTexts[sPos] == "cost")
                                            {
                                                sPos++;
                                                cost = Convert.ToInt32(subInvTexts[sPos]);
                                            }
                                            else if (subInvTexts[sPos] == "damage")
                                            {
                                                sPos++;
                                                damage = Convert.ToInt32(subInvTexts[sPos]);
                                            }
                                            else if (subInvTexts[sPos] == "x")
                                            {
                                                sPos++;
                                                wx = Convert.ToInt32(subInvTexts[sPos]);
                                            }
                                            else if (subInvTexts[sPos] == "y")
                                            {
                                                sPos++;
                                                wy = Convert.ToInt32(subInvTexts[sPos]);
                                            }
                                            else if (subInvTexts[sPos] == "effect")
                                            {
                                                sPos++;

                                                if (subInvTexts[sPos] == "burn")
                                                    effect = WeaponEffect.burn;
                                                else if (subInvTexts[sPos] == "penetrate")
                                                    effect = WeaponEffect.penetrate;
                                                else if (subInvTexts[sPos] == "curse")
                                                    effect = WeaponEffect.curse;
                                                else if (subInvTexts[sPos] == "midas")
                                                    effect = WeaponEffect.midas;
                                                else if (subInvTexts[sPos] == "wisdom")
                                                    effect = WeaponEffect.wisdom;
                                                else effect = WeaponEffect.none;
                                            }
                                            else if (subInvTexts[sPos] == "end")
                                            {
                                                sPos++;
                                                inventory.Add(new Weapon(weaponName, damage, cost, wx, wy, effect));
                                                break;
                                            }
                                        }
                                    }
                                    else if (subInvTexts[sPos] == "magicWeapon")
                                    {
                                        string weaponName = "none";
                                        int cost = 0;
                                        int magicDamage = 0;
                                        WeaponEffect effect = WeaponEffect.none;
                                        int wx = 0, wy = 0;

                                        while (!file.EndOfStream)
                                        {
                                            sPos++;

                                            if (subInvTexts[sPos] == "name")
                                            {
                                                sPos++;
                                                weaponName = subInvTexts[sPos];
                                            }
                                            else if (subInvTexts[sPos] == "cost")
                                            {
                                                sPos++;
                                                cost = Convert.ToInt32(subInvTexts[sPos]);
                                            }
                                            else if (subInvTexts[sPos] == "magicDamage")
                                            {
                                                sPos++;
                                                magicDamage = Convert.ToInt32(subInvTexts[sPos]);
                                            }
                                            else if (subInvTexts[sPos] == "x")
                                            {
                                                sPos++;
                                                wx = Convert.ToInt32(subInvTexts[sPos]);
                                            }
                                            else if (subInvTexts[sPos] == "y")
                                            {
                                                sPos++;
                                                wy = Convert.ToInt32(subInvTexts[sPos]);
                                            }
                                            else if (subInvTexts[sPos] == "effect")
                                            {
                                                sPos++;
                                                if (subInvTexts[sPos] == "burn")
                                                    effect = WeaponEffect.burn;
                                                else if (subInvTexts[sPos] == "penetrate")
                                                    effect = WeaponEffect.penetrate;
                                                else if (subInvTexts[sPos] == "curse")
                                                    effect = WeaponEffect.curse;
                                                else if (subInvTexts[sPos] == "midas")
                                                    effect = WeaponEffect.midas;
                                                else if (subInvTexts[sPos] == "wisdom")
                                                    effect = WeaponEffect.wisdom;
                                                else effect = WeaponEffect.none;
                                            }
                                            else if (subInvTexts[sPos] == "end")
                                            {
                                                sPos++;
                                                inventory.Add(new MagicWeapon(magicDamage, weaponName, cost, wx, wy, effect));
                                                break;
                                            }
                                        }
                                    }
                                    else if (subInvTexts[sPos] == "noviceFireTome")
                                    {
                                        while (!file.EndOfStream)
                                        {
                                            int wx = 0, wy = 0;
                                            
                                            sPos++;

                                            if (subInvTexts[sPos] == "x")
                                            {
                                                sPos++;
                                                wx = Convert.ToInt32(subInvTexts[sPos]);
                                            }
                                            else if (subInvTexts[sPos] == "y")
                                            {
                                                sPos++;
                                                wy = Convert.ToInt32(subInvTexts[sPos]);
                                            }
                                            else if (subInvTexts[sPos] == "end")
                                            {
                                                sPos++;
                                                inventory.Add(new NoviceFireTome(wx, wy));
                                                break;
                                            }
                                        }
                                    }
                                    else if (subInvTexts[sPos] == "statbooster")
                                    {
                                        while (!file.EndOfStream)
                                        {
                                            int ix = 0, iy = 0;
                                            int statLevel = 1;
                                            string stat = "Health";

                                            sPos++;

                                            if (subInvTexts[sPos] == "x")
                                            {
                                                sPos++;
                                                ix = Convert.ToInt32(subInvTexts[sPos]);
                                            }
                                            else if (subInvTexts[sPos] == "y")
                                            {
                                                sPos++;
                                                iy = Convert.ToInt32(subInvTexts[sPos]);
                                            }
                                            else if (subInvTexts[sPos] == "level")
                                            {
                                                sPos++;
                                                statLevel = Convert.ToInt32(subInvTexts[sPos]);
                                            }
                                            else if (subInvTexts[sPos] == "stat")
                                            {
                                                sPos++;
                                                stat = subInvTexts[sPos];
                                            }
                                            else if (subInvTexts[sPos] == "end")
                                            {
                                                sPos++;
                                                inventory.Add(new Statbooster(stat, statLevel, ix, iy));
                                                break;
                                            }
                                        }
                                    }
                                    else if (subInvTexts[sPos] == "statusHealer")
                                    {
                                        while (!file.EndOfStream)
                                        {
                                            int ix = 0, iy = 0;
                                            StatusEffect itemStatus = StatusEffect.none;

                                            sPos++;

                                            if (subInvTexts[sPos] == "x")
                                            {
                                                sPos++;
                                                ix = Convert.ToInt32(subInvTexts[sPos]);
                                            }
                                            else if (subInvTexts[sPos] == "y")
                                            {
                                                sPos++;
                                                iy = Convert.ToInt32(subInvTexts[sPos]);
                                            }
                                            else if (subInvTexts[sPos] == "status")
                                            {
                                                sPos++;
                                                if (subInvTexts[sPos] == "burned")
                                                    itemStatus = StatusEffect.burned;
                                                else if (subInvTexts[sPos] == "cursed")
                                                    itemStatus = StatusEffect.cursed;
                                                else itemStatus = StatusEffect.none;
                                            }
                                            else if (subInvTexts[sPos] == "end")
                                            {
                                                sPos++;
                                                inventory.Add(new StatusHealer(itemStatus, ix, iy));
                                                break;
                                            }
                                        }
                                    }
                                    else if (subInvTexts[sPos] == "healthTonicBasic")
                                    {
                                        while (!file.EndOfStream)
                                        {
                                            int hx = 0, hy = 0;
                                            sPos++;

                                            if (subInvTexts[sPos] == "x")
                                            {
                                                sPos++;
                                                hx = Convert.ToInt32(subInvTexts[sPos]);
                                            }
                                            else if (subInvTexts[sPos] == "x")
                                            {
                                                sPos++;
                                                hy = Convert.ToInt32(subInvTexts[sPos]);
                                            }
                                            else if (subInvTexts[sPos] == "end")
                                            {
                                                sPos++;
                                                inventory.Add(new HealthTonicBasic(hx, hy));
                                                break;
                                            }
                                        }
                                    }
                                }
                                else if (subInvTexts[sPos] == "end")
                                    break;
                                else if (subInvTexts[sPos] == "gameItem")
                                {
                                    string itemName = "none";
                                    int cost = 0;
                                    string info = "none";
                                    int ix = 0, iy = 0;

                                    while (!file.EndOfStream)
                                    {
                                        sPos++;

                                        if (subInvTexts[sPos] == "name")
                                        {
                                            sPos++;
                                            itemName = subInvTexts[sPos];
                                        }
                                        else if (subInvTexts[sPos] == "info")
                                        {
                                            sPos++;
                                            info = subInvTexts[sPos];
                                        }
                                        else if (subInvTexts[sPos] == "cost")
                                        {
                                            sPos++;
                                            cost = Convert.ToInt32(subInvTexts[sPos]);
                                        }
                                        else if (subInvTexts[sPos] == "x")
                                        {
                                            sPos++;
                                            ix = Convert.ToInt32(subInvTexts[sPos]);
                                        }
                                        else if (subInvTexts[sPos] == "y")
                                        {
                                            sPos++;
                                            iy = Convert.ToInt32(subInvTexts[sPos]);
                                        }
                                        else if (subInvTexts[sPos] == "end")
                                        {
                                            sPos++;
                                            inventory.Add(new GameItem(itemName, cost, ix, iy, info));
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        else if (subTexts[0] == "end")
                        {
                            player = new Player(name, gender, race, chosenAffinity, affinity, dungeonLevel, x, y,
                                level, exp, expNeeded, gold, weapon, maxHealth, health, attackDamage, magic, defense,
                                resist, status, inventory);
                            break;
                        }
                    }
                }
                else if (text == "room:")
                {
                    text = file.ReadLine();
                    string[] subTexts = text.Split(new string[] { ":" }, StringSplitOptions.None);
                    int sPos = 0;

                    int width = 0, height = 0;
                    int[] exitPos = new int[] { 0, 0 };
                    bool exitOpen = true;
                    int coinCount = 0;
                    int[,] coinPos = new int[coinCount, 2];
                    int enemyCount = 0;
                    List<Enemy> enemies = new List<Enemy>();
                    List<GameItem> items = new List<GameItem>();
                    Boss boss = null;
                    Shopkeeper shopkeeper = null;

                    while (!file.EndOfStream)
                    {
                        if (subTexts[sPos] == "width")
                        {
                            sPos++;
                            width = Convert.ToInt32(subTexts[sPos]);
                        }
                        else if (subTexts[sPos] == "height")
                        {
                            sPos++;
                            height = Convert.ToInt32(subTexts[sPos]);
                        }
                        else if (subTexts[sPos] == "exitPos")
                        {
                            sPos++;

                            string[] exitPosStrings = subTexts[sPos].Split(new string[] { "," }, StringSplitOptions.None);
                            exitPos[0] = Convert.ToInt32(exitPosStrings[0]);
                            exitPos[1] = Convert.ToInt32(exitPosStrings[1]);
                        }
                        else if (subTexts[sPos] == "exitOpen")
                        {
                            sPos++;
                            exitOpen = Convert.ToBoolean(subTexts[sPos]);
                        }
                        else if (subTexts[sPos] == "coinCount")
                        {
                            sPos++;
                            coinCount = Convert.ToInt32(subTexts[sPos]);
                        }
                        else if (subTexts[sPos] == "coinPos")
                        {
                            sPos++;
                            coinPos = new int[coinCount, 2];
                            int coinNum = 0;

                            while (true)
                            {
                                if (subTexts[sPos] == "end")
                                {
                                    sPos++;
                                    break;
                                }
                                else
                                {
                                    string[] stringCoinPos = subTexts[sPos].Split(new string[] { "," }, StringSplitOptions.None);
                                    sPos++;

                                    coinPos[coinNum, 0] = Convert.ToInt32(stringCoinPos[0]);
                                    coinPos[coinNum, 1] = Convert.ToInt32(stringCoinPos[1]);

                                    coinNum++;
                                }
                            }
                        }
                        else if (subTexts[sPos] == "enemyCount")
                        {
                            sPos++;
                            enemyCount = Convert.ToInt32(subTexts[sPos]);
                        }
                        else if (subTexts[sPos] == "enemies")
                        {
                            sPos++;

                            while (true)
                            {
                                if (subTexts[sPos] == "type")
                                {
                                    sPos++;

                                    if (subTexts[sPos] == "rat")
                                    {
                                        sPos++;

                                        int ex = 0, ey = 0, level = 1;

                                        while (true)
                                        {
                                            if (subTexts[sPos] == "level")
                                            {
                                                sPos++;
                                                level = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "x")
                                            {
                                                sPos++;
                                                ex = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "y")
                                            {
                                                sPos++;
                                                ey = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "end")
                                            {
                                                sPos++;
                                                enemies.Add(new Rat(ex, ey, level));
                                                break;
                                            }
                                        }

                                        sPos++;
                                    }
                                    else if (subTexts[sPos] == "weakZombie")
                                    {
                                        sPos++;

                                        int ex = 0, ey = 0, level = 1;

                                        while (true)
                                        {
                                            if (subTexts[sPos] == "level")
                                            {
                                                sPos++;
                                                level = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "x")
                                            {
                                                sPos++;
                                                ex = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "y")
                                            {
                                                sPos++;
                                                ey = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "end")
                                            {
                                                sPos++;
                                                enemies.Add(new WeakZombie(ex, ey, level));
                                                break;
                                            }
                                        }

                                        sPos++;
                                    }
                                    else if (subTexts[sPos] == "boneman")
                                    {
                                        sPos++;

                                        int ex = 0, ey = 0, level = 1;

                                        while (true)
                                        {
                                            if (subTexts[sPos] == "level")
                                            {
                                                sPos++;
                                                level = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "x")
                                            {
                                                sPos++;
                                                ex = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "y")
                                            {
                                                sPos++;
                                                ey = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "end")
                                            {
                                                sPos++;
                                                enemies.Add(new Boneman(ex, ey, level));
                                                break;
                                            }
                                        }

                                        sPos++;
                                    }
                                    else
                                    {
                                        sPos++;

                                        int ex = 0, ey = 0, level = 1;
                                        string name = "none";
                                        int maxHealth = 0;
                                        int health = 0;
                                        int attackDamage = 0;
                                        int magic = 0;
                                        int defense = 0;
                                        int resist = 0;
                                        WeaponEffect effect = WeaponEffect.none;
                                        int expDropped = 0;
                                        int goldDropped = 0;
                                        int baseHealth = 0;
                                        int baseAttack = 0;
                                        int baseMagic = 0;
                                        int baseDefense = 0;
                                        int baseResist = 0;
                                        int expDropBase = 0;
                                        int goldDropBase = 0;
                                        float healthModifier = 1;
                                        float attackModifier = 1;
                                        float magicModifier = 1;
                                        float defenseModifier = 1;
                                        float resistModifier = 1;
                                        float expModifier = 1;
                                        float goldModifier = 1;

                                        while (true)
                                        {
                                            if (subTexts[sPos] == "level")
                                            {
                                                sPos++;
                                                level = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "x")
                                            {
                                                sPos++;
                                                ex = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "y")
                                            {
                                                sPos++;
                                                ey = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "name")
                                            {
                                                sPos++;
                                                name = subTexts[sPos];
                                            }
                                            else if (subTexts[sPos] == "maxHealth")
                                            {
                                                sPos++;
                                                maxHealth = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "health")
                                            {
                                                sPos++;
                                                health = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "attackDamage")
                                            {
                                                sPos++;
                                                attackDamage = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "magic")
                                            {
                                                sPos++;
                                                magic = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "defense")
                                            {
                                                sPos++;
                                                defense = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "resist")
                                            {
                                                sPos++;
                                                resist = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "effect")
                                            {
                                                sPos++;

                                                if (subTexts[sPos] == "burn")
                                                    effect = WeaponEffect.burn;
                                                else if (subTexts[sPos] == "penetrate")
                                                    effect = WeaponEffect.penetrate;
                                                else if (subTexts[sPos] == "curse")
                                                    effect = WeaponEffect.curse;
                                                else if (subTexts[sPos] == "midas")
                                                    effect = WeaponEffect.midas;
                                                else if (subTexts[sPos] == "wisdom")
                                                    effect = WeaponEffect.wisdom;
                                                else effect = WeaponEffect.none;
                                            }
                                            else if (subTexts[sPos] == "expDropped")
                                            {
                                                sPos++;
                                                expDropped = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "goldDropped")
                                            {
                                                sPos++;
                                                goldDropped = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "baseHealth")
                                            {
                                                sPos++;
                                                baseHealth = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "baseAttack")
                                            {
                                                sPos++;
                                                baseAttack = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "baseMagic")
                                            {
                                                sPos++;
                                                baseMagic = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "baseDefense")
                                            {
                                                sPos++;
                                                baseDefense = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "baseResist")
                                            {
                                                sPos++;
                                                baseResist = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "expDropBase")
                                            {
                                                sPos++;
                                                expDropBase = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "goldDropBase")
                                            {
                                                sPos++;
                                                goldDropBase = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "healthModifier")
                                            {
                                                sPos++;
                                                healthModifier = (float)Convert.ToDouble(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "attackModifier")
                                            {
                                                sPos++;
                                                attackModifier = (float)Convert.ToDouble(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "magicModifier")
                                            {
                                                sPos++;
                                                magicModifier = (float)Convert.ToDouble(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "defenseModifier")
                                            {
                                                sPos++;
                                                defenseModifier = (float)Convert.ToDouble(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "reistModifier")
                                            {
                                                sPos++;
                                                resistModifier = (float)Convert.ToDouble(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "expModifier")
                                            {
                                                sPos++;
                                                expModifier = (float)Convert.ToDouble(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "goldModifier")
                                            {
                                                sPos++;
                                                goldModifier = (float)Convert.ToDouble(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "end")
                                            {
                                                sPos++;
                                                enemies.Add(new Enemy(name, ex, ey, level, effect, maxHealth, health,
                                                    attackDamage, magic, defense, resist, expDropped, goldDropped,
                                                    baseHealth, baseAttack, baseMagic, baseDefense, baseResist, expDropBase,
                                                    goldDropBase, healthModifier, attackModifier, magicModifier, defenseModifier,
                                                    resistModifier, expModifier, goldModifier));
                                                break;
                                            }
                                        }

                                        sPos++;
                                    }

                                    sPos++;
                                }
                            }
                        }
                        else if (subTexts[sPos] == "items")
                        {
                            sPos++;

                            while (true)
                            {
                                if (subTexts[sPos] == "type")
                                {
                                    sPos++;

                                    if (subTexts[sPos] == "weapon")
                                    {
                                        while (true)
                                        {
                                            string weaponName = "none";
                                            int cost = 0;
                                            int damage = 0;
                                            WeaponEffect effect = WeaponEffect.none;
                                            int wx = 0, wy = 0;

                                            sPos++;

                                            if (subTexts[sPos] == "name")
                                            {
                                                sPos++;
                                                weaponName = subTexts[sPos];
                                            }
                                            else if (subTexts[sPos] == "cost")
                                            {
                                                sPos++;
                                                cost = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "damage")
                                            {
                                                sPos++;
                                                damage = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "x")
                                            {
                                                sPos++;
                                                wx = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "y")
                                            {
                                                sPos++;
                                                wy = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "effect")
                                            {
                                                sPos++;

                                                if (subTexts[sPos] == "burn")
                                                    effect = WeaponEffect.burn;
                                                else if (subTexts[sPos] == "penetrate")
                                                    effect = WeaponEffect.penetrate;
                                                else if (subTexts[sPos] == "curse")
                                                    effect = WeaponEffect.curse;
                                                else if (subTexts[sPos] == "midas")
                                                    effect = WeaponEffect.midas;
                                                else if (subTexts[sPos] == "wisdom")
                                                    effect = WeaponEffect.wisdom;
                                                else effect = WeaponEffect.none;

                                                sPos++;
                                            }
                                            else if (subTexts[sPos] == "end")
                                            {
                                                sPos++;
                                                items.Add(new Weapon(weaponName, damage, cost, wx, wy, effect));
                                                break;
                                            }
                                        }
                                    }
                                    else if (subTexts[sPos] == "weapon")
                                    {
                                        while (!file.EndOfStream)
                                        {
                                            string weaponName = "none";
                                            int cost = 0;
                                            int magicDamage = 0;
                                            WeaponEffect effect = WeaponEffect.none;
                                            int wx = 0, wy = 0;

                                            sPos++;

                                            if (subTexts[sPos] == "name")
                                            {
                                                sPos++;
                                                weaponName = subTexts[sPos];
                                            }
                                            else if (subTexts[sPos] == "cost")
                                            {
                                                sPos++;
                                                cost = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "magicDamage")
                                            {
                                                sPos++;
                                                magicDamage = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "x")
                                            {
                                                sPos++;
                                                wx = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "y")
                                            {
                                                sPos++;
                                                wy = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "effect")
                                            {
                                                sPos++;

                                                if (subTexts[sPos] == "burn")
                                                    effect = WeaponEffect.burn;
                                                else if (subTexts[sPos] == "penetrate")
                                                    effect = WeaponEffect.penetrate;
                                                else if (subTexts[sPos] == "curse")
                                                    effect = WeaponEffect.curse;
                                                else if (subTexts[sPos] == "midas")
                                                    effect = WeaponEffect.midas;
                                                else if (subTexts[sPos] == "wisdom")
                                                    effect = WeaponEffect.wisdom;
                                                else effect = WeaponEffect.none;

                                                sPos++;
                                            }
                                            else if (subTexts[sPos] == "end")
                                            {
                                                sPos++;
                                                items.Add(new MagicWeapon(magicDamage, weaponName, cost, wx, wy, effect));
                                                break;
                                            }
                                        }
                                    }
                                    else if (subTexts[sPos] == "noviceFireTome")
                                    {
                                        while (!file.EndOfStream)
                                        {
                                            int wx = 0, wy = 0;

                                            sPos++;

                                            if (subTexts[sPos] == "x")
                                            {
                                                sPos++;
                                                wx = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "y")
                                            {
                                                sPos++;
                                                wy = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "end")
                                            {
                                                sPos++;
                                                items.Add(new NoviceFireTome(wx, wy));
                                                break;
                                            }
                                        }
                                    }
                                    else if (subTexts[sPos] == "statbooster")
                                    {
                                        while (!file.EndOfStream)
                                        {
                                            int ix = 0, iy = 0;
                                            int statLevel = 1;
                                            string stat = "Health";

                                            sPos++;

                                            if (subTexts[sPos] == "x")
                                            {
                                                sPos++;
                                                ix = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "y")
                                            {
                                                sPos++;
                                                iy = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "level")
                                            {
                                                sPos++;
                                                statLevel = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "stat")
                                            {
                                                sPos++;
                                                stat = subTexts[sPos];
                                            }
                                            else if (subTexts[sPos] == "end")
                                            {
                                                sPos++;
                                                items.Add(new Statbooster(stat, statLevel, ix, iy));
                                                break;
                                            }
                                        }
                                    }
                                    else if (subTexts[sPos] == "statusHealer")
                                    {
                                        while (!file.EndOfStream)
                                        {
                                            int ix = 0, iy = 0;
                                            StatusEffect itemStatus = StatusEffect.none;

                                            sPos++;

                                            if (subTexts[sPos] == "x")
                                            {
                                                sPos++;
                                                ix = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "y")
                                            {
                                                sPos++;
                                                iy = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "status")
                                            {
                                                sPos++;

                                                if (subTexts[sPos] == "burned")
                                                    itemStatus = StatusEffect.burned;
                                                else if (subTexts[sPos] == "cursed")
                                                    itemStatus = StatusEffect.cursed;
                                                else itemStatus = StatusEffect.none;

                                                sPos++;
                                            }
                                            else if (subTexts[sPos] == "end")
                                            {
                                                sPos++;
                                                items.Add(new StatusHealer(itemStatus, ix, iy));
                                                break;
                                            }
                                        }
                                    }
                                    else if (subTexts[sPos] == "healthTonicBasic")
                                    {
                                        while (!file.EndOfStream)
                                        {
                                            int hx = 0, hy = 0;
                                            sPos++;

                                            if (subTexts[sPos] == "x")
                                            {
                                                sPos++;
                                                hx = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "x")
                                            {
                                                sPos++;
                                                hy = Convert.ToInt32(subTexts[sPos]);
                                            }
                                            else if (subTexts[sPos] == "end")
                                            {
                                                sPos++;
                                                items.Add(new HealthTonicBasic(hx, hy));
                                                break;
                                            }
                                        }
                                    }
                                }
                                else if (subTexts[sPos] == "end")
                                    break;
                                else
                                {
                                    while (!file.EndOfStream)
                                    {
                                        string itemName = "none";
                                        int cost = 0;
                                        string info = "none";
                                        int ix = 0, iy = 0;

                                        sPos++;

                                        if (subTexts[sPos] == "name")
                                        {
                                            sPos++;
                                            itemName = subTexts[sPos];
                                        }
                                        else if (subTexts[sPos] == "info")
                                        {
                                            sPos++;
                                            info = subTexts[sPos];
                                        }
                                        else if (subTexts[sPos] == "cost")
                                        {
                                            sPos++;
                                            cost = Convert.ToInt32(subTexts[sPos]);
                                        }
                                        else if (subTexts[sPos] == "x")
                                        {
                                            sPos++;
                                            ix = Convert.ToInt32(subTexts[sPos]);
                                        }
                                        else if (subTexts[sPos] == "y")
                                        {
                                            sPos++;
                                            iy = Convert.ToInt32(subTexts[sPos]);
                                        }
                                        else if (subTexts[sPos] == "end")
                                        {
                                            sPos++;
                                            items.Add(new GameItem(itemName, cost, ix, iy, info));
                                            break;
                                        }
                                    }
                                }

                                sPos++;
                            }
                        }
                        else if (subTexts[sPos] == "Boss")
                        {
                            sPos++;

                            if (subTexts[sPos] == "type")
                            {
                                sPos++;

                                if (subTexts[sPos] == "revenant")
                                {
                                    sPos++;
                                    boss = new Revenant();
                                }
                            }
                            else
                            {
                                sPos++;

                                int ex = 0, ey = 0, level = 1;
                                string name = "none";
                                int maxHealth = 0;
                                int health = 0;
                                int attackDamage = 0;
                                int magic = 0;
                                int defense = 0;
                                int resist = 0;
                                WeaponEffect effect = WeaponEffect.none;
                                int expDropped = 0;
                                int goldDropped = 0;
                                int baseHealth = 0;
                                int baseAttack = 0;
                                int baseMagic = 0;
                                int baseDefense = 0;
                                int baseResist = 0;
                                int expDropBase = 0;
                                int goldDropBase = 0;
                                float healthModifier = 1;
                                float attackModifier = 1;
                                float magicModifier = 1;
                                float defenseModifier = 1;
                                float resistModifier = 1;
                                float expModifier = 1;
                                float goldModifier = 1;

                                while (true)
                                {
                                    if (subTexts[sPos] == "level")
                                    {
                                        sPos++;
                                        level = Convert.ToInt32(subTexts[sPos]);
                                    }
                                    else if (subTexts[sPos] == "x")
                                    {
                                        sPos++;
                                        ex = Convert.ToInt32(subTexts[sPos]);
                                    }
                                    else if (subTexts[sPos] == "y")
                                    {
                                        sPos++;
                                        ey = Convert.ToInt32(subTexts[sPos]);
                                    }
                                    else if (subTexts[sPos] == "name")
                                    {
                                        sPos++;
                                        name = subTexts[sPos];
                                    }
                                    else if (subTexts[sPos] == "maxHealth")
                                    {
                                        sPos++;
                                        maxHealth = Convert.ToInt32(subTexts[sPos]);
                                    }
                                    else if (subTexts[sPos] == "health")
                                    {
                                        sPos++;
                                        health = Convert.ToInt32(subTexts[sPos]);
                                    }
                                    else if (subTexts[sPos] == "attackDamage")
                                    {
                                        sPos++;
                                        attackDamage = Convert.ToInt32(subTexts[sPos]);
                                    }
                                    else if (subTexts[sPos] == "magic")
                                    {
                                        sPos++;
                                        magic = Convert.ToInt32(subTexts[sPos]);
                                    }
                                    else if (subTexts[sPos] == "defense")
                                    {
                                        sPos++;
                                        defense = Convert.ToInt32(subTexts[sPos]);
                                    }
                                    else if (subTexts[sPos] == "resist")
                                    {
                                        sPos++;
                                        resist = Convert.ToInt32(subTexts[sPos]);
                                    }
                                    else if (subTexts[sPos] == "effect")
                                    {
                                        sPos++;

                                        if (subTexts[sPos] == "burn")
                                            effect = WeaponEffect.burn;
                                        else if (subTexts[sPos] == "penetrate")
                                            effect = WeaponEffect.penetrate;
                                        else if (subTexts[sPos] == "curse")
                                            effect = WeaponEffect.curse;
                                        else if (subTexts[sPos] == "midas")
                                            effect = WeaponEffect.midas;
                                        else if (subTexts[sPos] == "wisdom")
                                            effect = WeaponEffect.wisdom;
                                        else effect = WeaponEffect.none;
                                    }
                                    else if (subTexts[sPos] == "expDropped")
                                    {
                                        sPos++;
                                        expDropped = Convert.ToInt32(subTexts[sPos]);
                                    }
                                    else if (subTexts[sPos] == "goldDropped")
                                    {
                                        sPos++;
                                        goldDropped = Convert.ToInt32(subTexts[sPos]);
                                    }
                                    else if (subTexts[sPos] == "baseHealth")
                                    {
                                        sPos++;
                                        baseHealth = Convert.ToInt32(subTexts[sPos]);
                                    }
                                    else if (subTexts[sPos] == "baseAttack")
                                    {
                                        sPos++;
                                        baseAttack = Convert.ToInt32(subTexts[sPos]);
                                    }
                                    else if (subTexts[sPos] == "baseMagic")
                                    {
                                        sPos++;
                                        baseMagic = Convert.ToInt32(subTexts[sPos]);
                                    }
                                    else if (subTexts[sPos] == "baseDefense")
                                    {
                                        sPos++;
                                        baseDefense = Convert.ToInt32(subTexts[sPos]);
                                    }
                                    else if (subTexts[sPos] == "baseResist")
                                    {
                                        sPos++;
                                        baseResist = Convert.ToInt32(subTexts[sPos]);
                                    }
                                    else if (subTexts[sPos] == "expDropBase")
                                    {
                                        sPos++;
                                        expDropBase = Convert.ToInt32(subTexts[sPos]);
                                    }
                                    else if (subTexts[sPos] == "goldDropBase")
                                    {
                                        sPos++;
                                        goldDropBase = Convert.ToInt32(subTexts[sPos]);
                                    }
                                    else if (subTexts[sPos] == "healthModifier")
                                    {
                                        sPos++;
                                        healthModifier = (float)Convert.ToDouble(subTexts[sPos]);
                                    }
                                    else if (subTexts[sPos] == "attackModifier")
                                    {
                                        sPos++;
                                        attackModifier = (float)Convert.ToDouble(subTexts[sPos]);
                                    }
                                    else if (subTexts[sPos] == "magicModifier")
                                    {
                                        sPos++;
                                        magicModifier = (float)Convert.ToDouble(subTexts[sPos]);
                                    }
                                    else if (subTexts[sPos] == "defenseModifier")
                                    {
                                        sPos++;
                                        defenseModifier = (float)Convert.ToDouble(subTexts[sPos]);
                                    }
                                    else if (subTexts[sPos] == "reistModifier")
                                    {
                                        sPos++;
                                        resistModifier = (float)Convert.ToDouble(subTexts[sPos]);
                                    }
                                    else if (subTexts[sPos] == "expModifier")
                                    {
                                        sPos++;
                                        expModifier = (float)Convert.ToDouble(subTexts[sPos]);
                                    }
                                    else if (subTexts[sPos] == "goldModifier")
                                    {
                                        sPos++;
                                        goldModifier = (float)Convert.ToDouble(subTexts[sPos]);
                                    }
                                    else if (subTexts[sPos] == "end")
                                    {
                                        sPos++;
                                        enemies.Add(new Enemy(name, ex, ey, level, effect, maxHealth, health,
                                            attackDamage, magic, defense, resist, expDropped, goldDropped,
                                            baseHealth, baseAttack, baseMagic, baseDefense, baseResist, expDropBase,
                                            goldDropBase, healthModifier, attackModifier, magicModifier, defenseModifier,
                                            resistModifier, expModifier, goldModifier));
                                        break;
                                    }
                                }
                            }
                        }
                        else if (subTexts[sPos] == "Shopkeeper")
                        {
                            sPos++;

                            int level = 1;

                            while (true)
                            {
                                if (subTexts[sPos] == "level")
                                {
                                    sPos++;
                                    level = Convert.ToInt32(subTexts[sPos]);
                                }
                                else if (subTexts[sPos] == "end")
                                {
                                    sPos++;
                                    shopkeeper = new Shopkeeper(level);
                                    break;
                                }

                                sPos++;
                            }
                        }
                        else if (subTexts[sPos] == "end")
                        {
                            sPos++;
                            room = new Room(width, height, exitPos, exitOpen, coinCount, coinPos, enemyCount, 
                                enemies, items, boss, shopkeeper);
                            break;
                        }

                        sPos++;
                    }
                }
            }

        }
    }
}
