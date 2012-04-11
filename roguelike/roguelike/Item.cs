using System;
using System.Collections.Generic;

namespace roguelike
{
    class Item
    {

        public Item(char c)
        {
            Icon = c;
            Description = "a murky red liquid";
        }

        public char Icon
        {
            get;
            set;
        }

        public String Description
        {
            get;
            set;
        }
        public ConsoleColor Colour
        {
            get;
            set;
        }
    }
}
