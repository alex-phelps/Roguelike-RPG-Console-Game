using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike_RPG_Console_Game
{
    
    public class Enemy : DamagableEntity
    {
        public int expDropped { get; protected set; }
        public int goldDropped { get; protected set; }

        protected Random random;
        protected int baseHealth = 0;
        protected int baseAttack = 0;
        protected int baseMagic = 0;
        protected int baseDefense = 0;
        protected int baseResist = 0;
        protected int expDropBase = 0;
        protected int goldDropBase = 0;

        protected float healthModifier = 1.5f;
        protected float attackModifier = 1.5f;
        protected float magicModifier = 1.5f;
        protected float defenseModifier = 1.5f;
        protected float resistModifier = 1.5f;
        protected float expModifier = 1.5f;
        protected float goldModifier = 1.5f;

        public WeaponEffect effect = WeaponEffect.none;

        public Enemy(int x, int y)
            : base()
        {
            random = new Random();

            this.x = x;
            this.y = y;
        }

        public Enemy(string name, int x, int y, int level, WeaponEffect effect, int maxHealth,
            int health, int attackDamage, int magic, int defense, int resist, int expDropped,
            int goldDropped, int baseHealth, int baseAttack, int baseMagic, int baseDefense, 
            int baseResist, int expDropBase, int goldDropBase, float healthModifier, 
            float attackModifier, float magicModifier, float defenseModifier, float resistModifier,
            float expModifier, float goldModifier) 
            : base()
        {
            this.name = name;
            this.x = x;
            this.y = y;
            this.level = level;
            this.effect = effect;
            this.maxHealth = maxHealth;
            this.health = health;
            this.attackDamage = attackDamage;
            this.magic = magic;
            this.defense = defense;
            this.resist = resist;
            this.expDropped = expDropped;
            this.goldDropped = goldDropped;
            this.baseHealth = baseHealth;
            this.baseAttack = baseAttack;
            this.baseMagic = baseMagic;
            this.baseDefense = baseDefense;
            this.baseResist = baseResist;
            this.expDropBase = expDropBase;
            this.goldDropBase = goldDropBase;
            this.healthModifier = healthModifier;
            this.attackModifier = attackModifier;
            this.magicModifier = magicModifier;
            this.defenseModifier = defenseModifier;
            this.resistModifier = resistModifier;
            this.expDropBase = expDropBase;
            this.goldDropBase = goldDropBase;
        }

        public virtual void Update(Player player)
        {
            if (Math.Abs(player.x - x) > Math.Abs(player.y - y))
            {
                if (player.x > x)
                {
                    x++;
                }
                else if (player.x < x)
                {
                    x--;
                }
                else if (player.y < y)
                {
                    y--;
                }
                else if (player.y > y)
                {
                    y++;
                }
                
            }
            else
            {
                if (player.y < y)
                {
                    y--;
                }
                else if (player.y > y)
                {
                    y++;
                }
                else if (player.x > x)
                {
                    x++;
                }
                else if (player.x < x)
                {
                    x--;
                }
            }
        }

        public void Attack(Player player)
        {
            player.TakeDamage(attackDamage, effect);
        }

        public override string ToString()
        {
            return
                "Level " + level + " " + name + "\n" +
                "Health: " + healthBar + "\n" +
                "#####################\n" +
                "IMAGE HERE\n" +
                "#####################\n";

        }

        protected void SetupStats()
        {
            maxHealth = baseHealth + (int)(level * healthModifier * Math.Sign(Math.Abs(baseHealth)));
            attackDamage = baseAttack + (int)(level * attackModifier * Math.Sign(Math.Abs(baseAttack)));
            magic = baseMagic + (int)(level * magicModifier * Math.Sign(Math.Abs(baseMagic)));
            defense = baseDefense + (int)(level * defenseModifier * Math.Sign(Math.Abs(baseDefense)));
            resist = baseResist + (int)(level * resistModifier * Math.Sign(Math.Abs(baseResist)));

            expDropped = expDropBase + (int)(level * expModifier * Math.Sign(Math.Abs(expDropBase)));
            goldDropped = goldDropBase + (int)(level * goldModifier * Math.Sign(Math.Abs(goldDropBase)));

            health = maxHealth;
        }

        public virtual string SaveDataAsString()
        {
            string saveData = "";
            saveData += "name:" + name + ":\n";
            saveData += "x:" + x + ":\n";
            saveData += "y:" + y + ":\n";
            saveData += "level:" + level + ":\n";
            saveData += "effect:" + effect + ":\n";
            saveData += "maxHealth:" + maxHealth + ":\n";
            saveData += "health:" + health + ":\n";
            saveData += "attackDamage:" + attackDamage + ":\n";
            saveData += "magic:" + magic + ":\n";
            saveData += "defense:" + defense + ":\n";
            saveData += "resist:" + resist + ":\n";
            saveData += "expDropped:" + expDropped + ":\n";
            saveData += "goldDropped:" + goldDropped + ":\n";
            saveData += "baseHealth:" + baseHealth + ":\n";
            saveData += "baseAttack:" + baseAttack + ":\n";
            saveData += "baseMagic:" + baseMagic + ":\n";
            saveData += "baseDefense:" + baseDefense + ":\n";
            saveData += "baseResist:" + baseResist + ":\n";
            saveData += "expDropBase:" + expDropBase + ":\n";
            saveData += "goldDropBase:" + goldDropBase + ":\n";
            saveData += "healthModifier:" + healthModifier + ":\n";
            saveData += "attackModifier:" + attackModifier + ":\n";
            saveData += "magicModifier:" + magicModifier + ":\n";
            saveData += "defenseModifier:" + defenseModifier + ":\n";
            saveData += "resistModifier:" + resistModifier + ":\n";
            saveData += "expModifier:" + expModifier + ":\n";
            saveData += "goldModifer:" + goldModifier + ":\n";
            saveData += "end:\n";
            return saveData;
        }
    }
}
