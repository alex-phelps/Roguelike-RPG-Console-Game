﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike_RPG_Console_Game
{
    public enum RandomItemType
    {
        basicHealthTonic
    }

    public class GameItem
    {
        public string name { get; protected set; }
        public int x;
        public int y;
        protected int cost;

        public GameItem(string name, int cost)
        {
            this.cost = cost;
            this.name = name;
        }
        public GameItem(string name, int cost, int x, int y)
        {
            this.cost = cost;
            this.name = name;
            this.x = x;
            this.y = y;
        }

        public virtual bool UseItem(Player player)
        {
            Console.WriteLine("NO USE");

            return true;
        }
    }
}
