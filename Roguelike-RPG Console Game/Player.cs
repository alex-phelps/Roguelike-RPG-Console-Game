using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Roguelike_RPG_Console_Game
{
    public class Player : DamagableEntity
    {
        
        public int exp = 0;
        public int gold = 0;
        public int dungeonLevel = 1;
        public List<GameItem> inventory;
        public Weapon weapon;

        //1 = Physical (Sun), -1 = Magical (Moon), 0 = Unchosen / None (Stars)
        public int affinity = 0; 
        public int chosenAffinity;

        string gender;
        string race;

        private int expNeeded = 10;

        public Player(string name, string race, string gender, int affinity, Weapon weapon)
            : base()
        {
            level = 1;
            maxHealth = 100;
            attackDamage = 3;
            magic = 2;
            defense = 0;
            resist = 0;

            inventory = new List<GameItem>();
            this.weapon = weapon;
            this.name = name;
            this.gender = gender;
            this.race = race;
            chosenAffinity = affinity;

            if (gender == "Male")
                attackDamage++;
            else magic++;

            if (race == "Elf")
            {
                magic += 3;
                resist += 1;
                attackDamage -= 1;
                defense -= 1;
            }
            else if (race == "Orc")
            {
                maxHealth += 20;
                defense += 2;
                magic -= 1;
                attackDamage -= 1;
                resist -= 2;
            }
            else if (race == "Dwarf")
            {
                attackDamage += 2;
                magic -= 2;
                maxHealth -= 10;
            }

            if (chosenAffinity == 1)
                magic++;
            else if (chosenAffinity == -1)
                attackDamage++;
            else maxHealth += 10;

            health = maxHealth;

            inventory.Add(weapon);
        }

        public Player(string name, string gender, string race, int chosenAffinity, int affinity,
            int dungeonLevel, int x, int y, int level, int exp, int expNeeded, int gold, 
            Weapon weapon, int maxHealth, int health, int attackDamage, int magic,
            int defense, int resist, StatusEffect status, List<GameItem> inventory)
            : base()
        {
            this.name = name;
            this.gender = gender;
            this.chosenAffinity = chosenAffinity;
            this.affinity = affinity;
            this.dungeonLevel = dungeonLevel;
            this.x = x;
            this.y = y;
            this.level = level;
            this.exp = exp;
            this.expNeeded = expNeeded;
            this.gold = gold;
            this.weapon = weapon;
            this.maxHealth = maxHealth;
            this.health = health;
            this.attackDamage = attackDamage;
            this.magic = magic;
            this.defense = defense;
            this.resist = resist;
            this.status = status;
            this.inventory = inventory;
        }

        public void Update(ConsoleKey key, Room room)
        {
            //Make affinity come into play starting at room 10
            if (dungeonLevel >= 10 && affinity != chosenAffinity) 
                affinity = chosenAffinity;

            if (key == ConsoleKey.UpArrow)
            {
                y--;

                if (y == 0 || y == room.height - 1)
                    y++;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                y++;

                if (y == 0 || y == room.height - 1)
                    y--;
            }
            else if (key == ConsoleKey.LeftArrow)
            {
                x--;

                if (x == 0 || x == room.width - 1)
                    x++;
            }
            else if (key == ConsoleKey.RightArrow)
            {
                x++;

                if (x == 0 || x == room.width - 1)
                    x--;
            }
            else if (key == ConsoleKey.B)
            {
                CheckInventory();
            }
            else if (key == ConsoleKey.Escape)
            {
                int selectedItem = 0;

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("###Save Menu###");
                    Console.WriteLine();

                    if (selectedItem == 0)
                    {
                        Console.WriteLine("#Save#");
                        Console.WriteLine("=Save and Quit=");
                        Console.WriteLine("=Quit without Saving=");
                        Console.WriteLine("=Return to game=");
                    }
                    else if (selectedItem == 1)
                    {
                        Console.WriteLine("=Save=");
                        Console.WriteLine("#Save and Quit#");
                        Console.WriteLine("=Quit without Saving=");
                        Console.WriteLine("=Return to game=");
                    }
                    else if (selectedItem == 2) 
                    {
                        Console.WriteLine("=Save=");
                        Console.WriteLine("=Save and Quit=");
                        Console.WriteLine("#Quit without Saving#");
                        Console.WriteLine("=Return to game=");
                    }
                    else if (selectedItem == 3)
                    {
                        Console.WriteLine("=Save=");
                        Console.WriteLine("=Save and Quit=");
                        Console.WriteLine("=Quit without Saving=");
                        Console.WriteLine("#Return to game#");
                    }

                    ConsoleKey key2 = Console.ReadKey().Key;

                    if (key2 == ConsoleKey.UpArrow)
                    {
                        if (selectedItem == 0)
                            selectedItem = 3;
                        else selectedItem--;
                    }
                    else if (key2 == ConsoleKey.DownArrow)
                    {
                        if (selectedItem == 3)
                            selectedItem = 0;
                        else selectedItem++;
                    }
                    else if (key2 == ConsoleKey.Enter)
                    {
                        if (selectedItem == 0 || selectedItem == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("Choose a save file.");
                            Console.WriteLine();
                            Console.WriteLine("##Save 1##");
                            Console.WriteLine("==Save 2==");
                            Console.WriteLine("==Save 3==");
                            Console.WriteLine();
                            Console.WriteLine("==Back==");

                            int selectedSave = 0;

                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("Choose a save file.");
                                Console.WriteLine();
                                if (selectedSave == 0)
                                {
                                    Console.WriteLine("##Save 1##");
                                    Console.WriteLine("==Save 2==");
                                    Console.WriteLine("==Save 3==");
                                    Console.WriteLine();
                                    Console.WriteLine("==Back==");
                                }
                                else if (selectedSave == 1)
                                {
                                    Console.WriteLine("==Save 1==");
                                    Console.WriteLine("##Save 2##");
                                    Console.WriteLine("==Save 3==");
                                    Console.WriteLine();
                                    Console.WriteLine("==Back==");
                                }
                                else if (selectedSave == 2)
                                {
                                    Console.WriteLine("==Save 1==");
                                    Console.WriteLine("==Save 2==");
                                    Console.WriteLine("##Save 3##");
                                    Console.WriteLine();
                                    Console.WriteLine("==Back==");
                                }
                                else
                                {
                                    Console.WriteLine("==Save 1==");
                                    Console.WriteLine("==Save 2==");
                                    Console.WriteLine("==Save 3==");
                                    Console.WriteLine();
                                    Console.WriteLine("##Back##");
                                }

                                ConsoleKey key3 = Console.ReadKey().Key;

                                if (key3 == ConsoleKey.DownArrow)
                                {
                                    if (selectedSave == 3)
                                        selectedSave = 0;
                                    else selectedSave++;
                                }
                                else if (key3 == ConsoleKey.UpArrow)
                                {
                                    if (selectedSave == 0)
                                        selectedSave = 3;
                                    else selectedSave--;
                                }
                                else if (key3 == ConsoleKey.Enter)
                                {
                                    if (selectedSave == 3)
                                        break;
                                    else
                                    {
                                        SaveGame("Save" + (selectedSave + 1) + ".txt", room);
                                        if (selectedItem == 1)
                                            Environment.Exit(0);
                                        break;
                                    }
                                }
                            }
                        }
                        else if (selectedItem == 2)
                        {
                            System.Environment.Exit(0);
                        }
                        else break;
                    }
                }
            }
        }

        public override char ToChar()
        {
            return '@';
        }

        public void Attack(Enemy enemy)
        {
            enemy.TakeDamage(attackDamage + weapon.damage, weapon.effect);
        }

        public void MagicAttack(Enemy enemy, MagicWeapon magicWeapon)
        {
            enemy.TakeMagicDamage(magicWeapon.magicDamage + magic, magicWeapon.effect);
        }

        public void Loot(Enemy enemy)
        {
            exp += enemy.expDropped;
            gold += enemy.goldDropped;

            Console.WriteLine("You got: \n\nExperience: " + enemy.expDropped + "\nGold: " + enemy.goldDropped);

            Console.ReadKey();

            if (exp >= expNeeded)
            {
                Console.WriteLine("\nYou leveled up!\n");
                Console.WriteLine(level + " → " + (level + 1) + "\n");

                exp -= expNeeded;
                level++;
                expNeeded = Convert.ToInt32(expNeeded * 1.25f);

                Random random = new Random();

                int newHealth = maxHealth + random.Next(0, 7);
                int newAttack = attackDamage + random.Next(0, 4 + affinity);
                int newMagic = magic + random.Next(0, 3 - affinity);
                int newDefence = defense + random.Next(0, 3 + affinity);
                int newResist = resist + random.Next(0, 3 - affinity);

                Console.WriteLine("HP: " + maxHealth + " → " + newHealth + " +" + (newHealth - maxHealth));
                Console.WriteLine("Att: " + attackDamage + " → " + newAttack + " +" + (newAttack - attackDamage));
                Console.WriteLine("Mag: " + magic + " → " + newMagic + " +" + (newMagic - magic));
                Console.WriteLine("Def: " + defense + " → " + newDefence + " +" + (newDefence - defense));
                Console.WriteLine("Res: " + resist + " → " + newResist + " +" + (newResist - resist));

                health += newHealth - maxHealth;

                attackDamage = newAttack;
                magic = newMagic;
                maxHealth = newHealth;
                defense = newDefence;
                resist = newResist;

                Console.ReadKey();
            }
        }

        public void CheckInventory()
        {
            int selectedItem = 0;

            while (true)
            {

                Console.Clear();
                Console.WriteLine("##Bag## ==Stats==\n");

                if (!(selectedItem <= inventory.Count - 1))
                    selectedItem = inventory.Count - 1;

                foreach (GameItem item in inventory)
                {
                    if (inventory.IndexOf(item) == selectedItem)
                        Console.Write(">> ");
                    else Console.Write("$  ");

                    Console.WriteLine(item.name);
                }

                Console.WriteLine("Info: " + inventory[selectedItem].info + "\n");

                ConsoleKey key = Console.ReadKey().Key;

                if (key == ConsoleKey.UpArrow)
                {
                    if (selectedItem == 0)
                        selectedItem = inventory.Count - 1;
                    else selectedItem--;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    if (selectedItem == inventory.Count - 1)
                        selectedItem = 0;
                    else selectedItem++;
                }
                else if (key == ConsoleKey.Enter)
                {
                    if (inventory[selectedItem].UseItem(this))
                        inventory.RemoveAt(selectedItem);

                    Console.ReadKey();
                }
                else if (key == ConsoleKey.Escape || key == ConsoleKey.B)
                    return;
                else if (key == ConsoleKey.RightArrow)
                {
                    bool hasMagic = false;
                    List<MagicWeapon> magicWeapons = new List<MagicWeapon>();

                    foreach (GameItem item in inventory)
                    {
                        if (item is MagicWeapon)
                        {
                            hasMagic = true;
                            magicWeapons.Add((MagicWeapon)item);
                        }
                    }

                    string affinityString;

                    if (chosenAffinity == 0)
                        affinityString = "Stars";
                    else if (chosenAffinity == 1)
                        affinityString = "Sun";
                    else affinityString = "Moon";


                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("==Bag== ##Stats##\n");

                        Console.WriteLine(name + " the " + gender + " " + race);
                        Console.WriteLine("Affinity: " + affinityString);
                        Console.WriteLine("Level: " + level);
                        Console.WriteLine("Exp: " + exp + " / " + expNeeded);
                        Console.WriteLine();
                        Console.WriteLine("Room: " + dungeonLevel);
                        Console.WriteLine();
                        Console.WriteLine("Gold: " + gold + "\n");
                        Console.WriteLine("Health: " + health + " / " + maxHealth);
                        Console.WriteLine("Weapon: " + weapon.name);
                        if (hasMagic)
                        {
                            Console.WriteLine("Magic Weapons: ");
                            foreach (MagicWeapon mw in magicWeapons)
                            {
                                Console.WriteLine("  " + mw.name);
                            }
                        }
                        Console.WriteLine();
                        Console.WriteLine("Attack: " + attackDamage);
                        Console.WriteLine("Magic: " + magic);
                        Console.WriteLine("Defense: " + defense);
                        Console.WriteLine("Resistance: " + resist);

                        ConsoleKey key2 = Console.ReadKey().Key;

                        if (key2 == ConsoleKey.LeftArrow)
                            break;
                        else if (key2 == ConsoleKey.B || key2 == ConsoleKey.Escape)
                            return;
                    }
                }
            }
        }

        private void SaveGame(string filename, Room room)
        {
            Console.Clear();
            Console.WriteLine("\nSaving...");

            StreamWriter saveFile = File.CreateText(filename);
            saveFile.WriteLine("player:");
            saveFile.WriteLine("name:" + name);
            saveFile.WriteLine("gender:" + gender);
            saveFile.WriteLine("race:" + race);
            saveFile.WriteLine("chosenAffinity:" + chosenAffinity);
            saveFile.WriteLine("affinity:" + affinity);
            saveFile.WriteLine("dungeonLevel:" + dungeonLevel);
            saveFile.WriteLine("x:" + x);
            saveFile.WriteLine("y:" + y);
            saveFile.WriteLine("level:" + level);
            saveFile.WriteLine("exp:" + exp);
            saveFile.WriteLine("expNeeded:" + expNeeded);
            saveFile.WriteLine("gold:" + gold);
            saveFile.WriteLine("weapon:\n" + weapon.SaveDataAsString());
            saveFile.WriteLine("maxHealth:" + maxHealth);
            saveFile.WriteLine("health:" + health);
            saveFile.WriteLine("attackDamage:" + attackDamage);
            saveFile.WriteLine("magic:" + magic);
            saveFile.WriteLine("defense:" + defense);
            saveFile.WriteLine("resist:" + resist);
            saveFile.WriteLine("status:" + status);
            saveFile.WriteLine("inventory:");
            foreach (GameItem item in inventory)
            {
                saveFile.WriteLine(item.SaveDataAsString());
            }
            saveFile.WriteLine("end:\n");
            saveFile.WriteLine("room:\n");
            saveFile.WriteLine(room.SaveDataAsString());

            saveFile.Close();

            Console.Clear();
            Console.WriteLine("Saving Done!");
            Console.ReadKey();
        }
    }
}
