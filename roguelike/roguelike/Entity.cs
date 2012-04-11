using System;
using System.Collections.Generic;

namespace roguelike
{
    

    //struct CharacterClass
    //{
    //    public ClassType Type
    //    {
    //        get;
    //        set;
    //    }
    //    public String Name
    //    {
    //        get;
    //        set;
    //    }
    //    public ConsoleColor Colour
    //    {
    //        get;
    //        set;
    //    }

    //    public CharacterClass(ClassType t, String n, ConsoleColor c)
    //    {
    //        Type = t;
    //        Name = n;
    //        Colour = c;
    //    }
    //}
    class Entity
    {
        private List<Item> inventory;
        private Dictionary<String, int> stats;
        private int currentHP;
        private int maxHP;

        enum CharacterClass
        {
            Fighter, Wizard, Cleric, Rogue
        }

        public Entity(char c)
        {
            Icon = c;
            X = 1;
            Y = 1;
            String tmp = GenerateId();
            inventory = new List<Item>();
            stats = new Dictionary<String, int>();
            Description = "an angry looking Orc";
            //ids.push_front(tmp);
            UniqueId = tmp;
            stats.Add("STR", 25);
            stats.Add("CON", 12);
            stats.Add("DEX", 9);
            stats.Add("INT", 20);
            stats.Add("WIS", 14);
            stats.Add("CHA", 5);
            maxHP = stats["CON"];
            currentHP = maxHP;
            if (c == '@')
                Class = CharacterClass.Wizard;
        }

        public void Fight(Entity e)
        {
            if (e.Icon != '@')
            {
                e.Damage(5);
                World.AddMessage("You swing mightily at the " + e.Name);
            }
        }
        public CharacterClass Class
        {
            get;
            set;
        }
        public int DungeonLevel
        {
            get;
            set;
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
            get;
            set;
        }

        public ConsoleColor Colour
        {
            get;
            set;
        }

        public String Description
        {
            get;
            set;
        }
        public String Name
        {
            get;
            set;
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
