using System;
using System.Collections.Generic;

namespace Roguelike.Items
{
   abstract class Item
    {
       public enum Items
       {
           StrengthPotion
       };

        //public Item(char c)
       // {
            //Icon = c;
           // Description = "a murky red liquid";
       // }

        public static Item CreateItem(Items i)
        {
            switch (i)
            {
                case Items.StrengthPotion:
                    return new Potions.StrengthPotion();
                default:
                    return new Potions.StrengthPotion();
            }
        }

        public abstract char Icon
        {
            get;
        }

        public abstract String Description
        {
            get;
        }
        public abstract ConsoleColor Colour
        {
            get;
           // set;
        }
    }
}
