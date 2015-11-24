﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike_RPG_Console_Game
{
    public class Player : DamagableEntity
    {
        
        public int exp = 0;
        public int gold = 0;
        public int dungeonLevel = 1;
        public List<GameItem> inventory;
        public Weapon weapon;

        private int expNeeded = 10;

        public Player(Weapon weapon)
            : base()
        {
            level = 1;
            maxHealth = 100;
            attackDamage = 4;
            defence = 0;
            resist = 0;
            magic = 0;

            inventory = new List<GameItem>();
            this.weapon = weapon;

            health = maxHealth;

            inventory.Add(weapon);
        }

        public void Update(ConsoleKey key, Room room)
        {
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

                int newAttack = attackDamage + random.Next(0, 3);
                int newMagic = magic + random.Next(0, 3);
                int newDefence = defence + random.Next(0, 3);
                int newResist = resist + random.Next(0, 2);
                int newHealth = maxHealth + random.Next(0, 11);

                Console.WriteLine("HP: " + maxHealth + " → " + newHealth + " +" + (newHealth - maxHealth));
                Console.WriteLine("Att: " + attackDamage + " → " + newAttack + " +" + (newAttack - attackDamage));
                Console.WriteLine("Mag: " + magic + " → " + newMagic + " +" + (newMagic - magic));
                Console.WriteLine("Def: " + defence + " → " + newDefence + " +" + (newDefence - defence));
                Console.WriteLine("Res: " + resist + " → " + newResist + " +" + (newResist - resist));

                health += newHealth - maxHealth;

                attackDamage = newAttack;
                magic = newMagic;
                maxHealth = newHealth;
                defence = newDefence;
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

                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("==Bag== ##Stats##\n");
                        Console.WriteLine("Room: " + dungeonLevel);
                        Console.WriteLine("Level: " + level);
                        Console.WriteLine("Exp: " + exp + " / " + expNeeded);
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
                        Console.WriteLine("Defense: " + defence);
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
    }
}
