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
    }
}
