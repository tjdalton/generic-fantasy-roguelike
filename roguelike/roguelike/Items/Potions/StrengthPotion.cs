﻿using System;
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

        public StrengthPotion()
        {
            unidentifiedDesc = "a murky red potion";
            identifiedDesc = "A Potion of Strength";
            Useable = true;
        }

        public override void Use(Entity e)
        {
            e.ModifyStat("STR", 5);
            e.Inventory.Remove(this);
            World.AddMessage("You drink the potion, and feel stronger");
        }
    }
}
