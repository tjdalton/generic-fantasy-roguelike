using System;
using System.Collections.Generic;

namespace Roguelike.Items
{
    abstract class Item
    {
        protected String unidentifiedDesc = "";
        protected String identifiedDesc = "";
        protected List<Abilities.Ability> abilities;
        protected String actionDescription = "";
        public enum Items
        {
            StrengthPotion,
            WaterPotion
        };

        public static Item CreateItem(Items i)
        {
            switch (i)
            {
                case Items.StrengthPotion:
                    return new Potions.StrengthPotion();
                case Items.WaterPotion:
                    return new Potions.WaterPotion();
                default:
                    return new Potions.WaterPotion();
            }
        }

        public static void DisplayInventory(Entity e, Type t)
        {
            Dictionary<char, Item> list = new Dictionary<char, Item>();
            e.World.ClearConsole();
            Console.SetCursorPosition(2, 2);
            Console.Write("Inventory");
            int i = 65;
            int x = 2;
            int y = 5;
            foreach (Item tmp in e.Inventory)
            {
                if (t.IsAssignableFrom(tmp.GetType()))
                {
                    list.Add((char)i, tmp);
                    Console.SetCursorPosition(x, y);
                    Console.Write("{0}) {1}", (char)i, tmp.Description);
                    y = y + 2;
                    if (y >= 20)
                    {
                        x = x + 25;
                        y = 5;
                    }
                    i++;
                }
            }
            if (e.Inventory.Count == 0)
            {
                Console.SetCursorPosition(x, y);
                Console.Write("You aren't carrying anything");
            }
            Console.SetCursorPosition(2, 24);
            Console.Write("Spacebar to exit");
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            while (key.Key != ConsoleKey.Spacebar)
            {
                key = Console.ReadKey(true);
                try
                {
                    list[key.KeyChar].Use(e);
                    break;
                }
                catch (Exception ex)
                {
                }
            }
        }
        public bool Identified
        {
            get;
            set;
        }
        public bool Useable
        {
            get;
            protected set;
        }
        public abstract double Weight
        {
            get;
        }

        public abstract char Icon
        {
            get;
        }
        public abstract void Use(Entity e);

        public String Description
        {
            get
            {
                if (Identified)
                    return identifiedDesc;
                else
                    return unidentifiedDesc;
            }
        }

        public String UseText
        {
            get
            {
                return actionDescription;
            }
        }
        public abstract ConsoleColor Colour
        {
            get;
        }
    }
}
