using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Items.Potions
{
    class StrengthPotion : Potion
    {
        public override ConsoleColor Colour
        {
            get { return ConsoleColor.DarkRed; }
        }

        public override string Description
        {
            get { return "a murky red potion"; }
        }
    }
}
