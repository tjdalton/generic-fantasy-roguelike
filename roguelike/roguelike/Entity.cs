using System;
using System.Collections.Generic;
using Roguelike.Items;
using Roguelike.Classes;
using Roguelike.Races;

namespace Roguelike
{

    class Entity
    {
        private List<Item> inventory;
        private Dictionary<String, int> stats;
        private int currentHP;
        private int maxHP;
        private String name;
        private int currentXP = 0;

        public Entity(Race r)
        {
            X = 1;
            Y = 1;
            UniqueId = GenerateId();
            inventory = new List<Item>();
            stats = new Dictionary<String, int>();
            stats.Add("STR", 25);
            stats.Add("CON", 12);
            stats.Add("DEX", 9);
            stats.Add("INT", 20);
            stats.Add("WIS", 14);
            stats.Add("CHA", 5);
            maxHP = stats["CON"];
            currentHP = maxHP;
            Class = Class.CreateClass(Class.Classes.Wizard);
            Race = r;
        }

        public Entity(Race r, World w):this(r)
        {
            World = w;
        }
        public World World
        {
            get;
            private set;
        }
        public void Fight(Entity e)
        {
            if (e.Icon != '@')
            {
                e.Damage(5);
                World.AddMessage("You swing mightily at the " + e.Name);
            }
        }
        public void ModifyStat(String s, int i)
        {
            stats[s] += i;
            if (stats[s] <= 0)
                stats[s] = 1;
        }
        public Classes.Class Class
        {
            get;
            set;
        }
        public bool Player
        {
            get;
            set;
        }
        public int DungeonLevel
        {
            get;
            set;
        }

        public Races.Race Race
        {
            get;
            private set;
        }

        public void Damage(int i)
        {
            currentHP -= i;
        }

        public bool Dead
        {
            get { return currentHP <= 0; }
        }
        public char Icon
        {
            get
            {
                if (Player)
                    return '@';
                else
                    return Race.Icon;
            }
        }

        public ConsoleColor Colour
        {
            get
            {
                if (Race.Playable)
                    return Class.Colour;
                else
                    return Race.Colour;
            }
        }

        public String Description
        {
            get
            {
                return Race.Description;
            }
        }

        public int Level
        {
            get
            {
                if (currentXP <= 1000)
                    return 1;
                else
                    return currentXP / 1000;
            }

        }
        public String Name
        {
            get
            {
                if (Race.Playable)
                    return name;
                else
                    return Race.Name;
            }
            set { name = value; }
        }

        public int X
        {
            get;
            set;
        }

        public int Y
        {
            get;
            set;
        }

        public void SetPos(int i, int j)
        {
            X = i;
            Y = j;
        }

        public List<Item> Inventory
        {
            get
            {
                return inventory;
            }
        }
        public String UniqueId
        {
            get;
            private set;
        }


        public String GenerateId()
        {
            String output = "#";
            Random random = new Random();
            for (int i = 0; i <= 10; i++)
            {
                output += (char)random.Next(65, 122);
            }
            return output;
        }

        public void AddItem(Item i)
        {
            inventory.Add(i);
        }

        public int GetStat(String s)
        {
            return stats[s];
        }
    }
}