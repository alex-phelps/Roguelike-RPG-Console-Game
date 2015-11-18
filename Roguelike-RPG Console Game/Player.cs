using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike_RPG_Console_Game
{
    public class Player
    {
        public string healthBar
        {
            get
            {
                string healthBar = "[";

                for (int i = 1; i <= 8; i++)
                {
                    if ((float)health >= (float)(maxHealth * (i / 8f)))
                        healthBar += "█";
                    else healthBar += " ";
                }

                healthBar += "]";

                return healthBar;
            }
        }

        public bool alive = true;
        public int level = 1;
        public int maxHealth = 100;
        public int health;
        public int attackDamage = 4;
        public int defence = 0;
        public int exp = 0;
        public int gold = 0;
        public int dungeonLevel = 1;
        public List<GameItem> inventory;
        public Weapon weapon;
        public int x = 0;
        public int y = 0;

        private int expNeeded = 10;

        public Player(Weapon weapon)
        {
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
            if (key == ConsoleKey.DownArrow)
            {
                y++;

                if (y == 0 || y == room.height - 1)
                    y--;
            }
            if (key == ConsoleKey.LeftArrow)
            {
                x--;

                if (x == 0 || x == room.width - 1)
                    x++;
            }
            if (key == ConsoleKey.RightArrow)
            {
                x++;

                if (x == 0 || x == room.width - 1)
                    x--;
            }
            if (key == ConsoleKey.B)
            {
                CheckInventory();
            }
        }

        public void TakeDamage(int damage)
        {
            damage -= defence / 2;

            if (damage < 0)
                damage = 0;

            health -= damage;

            if (health < 0)
                alive = false;
        }

        public void Attack(Enemy enemy)
        {
            enemy.TakeDamage(attackDamage + weapon.damage);
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

                int newAttack = attackDamage + random.Next(0, 5);
                int newDefence = defence + random.Next(0, 3);
                int newHealth = maxHealth + random.Next(0, 9);

                Console.WriteLine("HP: " + maxHealth + " → " + newHealth + " +" + (newHealth - maxHealth));
                Console.WriteLine("Att: " + attackDamage + " → " + newAttack + " +" + (newAttack - attackDamage));
                Console.WriteLine("Def: " + defence + " → " + newDefence + " +" + (newDefence - defence));

                health += newHealth - maxHealth;

                attackDamage = newAttack;
                maxHealth = newHealth;
                defence = newDefence;

                Console.ReadKey();
            }
        }

        public void CheckInventory()
        {
            int selectedItem = 0;

            while (true)
            {

                Console.Clear();
                Console.WriteLine("##Inventory##");

                if (!(selectedItem <= inventory.Count - 1))
                    selectedItem = inventory.Count - 1;

                foreach (GameItem item in inventory)
                {
                    if (inventory.IndexOf(item) == selectedItem)
                        Console.Write(">> ");
                    else Console.Write("$  ");

                    Console.WriteLine(item.name);
                }

                ConsoleKey key = Console.ReadKey().Key;

                if (key == ConsoleKey.UpArrow)
                {
                    if (selectedItem == 0)
                        selectedItem = inventory.Count - 1;
                    else selectedItem--;
                }
                if (key == ConsoleKey.DownArrow)
                {
                    if (selectedItem == inventory.Count - 1)
                        selectedItem = 0;
                    else selectedItem++;
                }
                if (key == ConsoleKey.Enter)
                {
                    if (inventory[selectedItem].UseItem(this))
                        inventory.RemoveAt(selectedItem);

                    Console.ReadKey();
                }
                if (key == ConsoleKey.Escape)
                    break;
            }
        }
    }
}
