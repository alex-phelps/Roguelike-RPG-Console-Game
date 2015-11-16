using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike_RPG_Console_Game
{
    public class BattleScreen
    {
        Random random;
        private Player player;
        private Enemy enemy;

        public BattleScreen(Player player, Enemy enemy)
        {
            random = new Random();

            this.player = player;
            this.enemy = enemy;
        }

        public void DoBattle()
        {
            bool? battleWon = null;

            while (battleWon != null)
            {
                
            }
        }
    }
}
