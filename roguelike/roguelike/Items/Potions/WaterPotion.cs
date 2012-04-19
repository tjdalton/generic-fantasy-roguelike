using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Items.Potions
{
    class WaterPotion : Potion
    {
        public override ConsoleColor Colour
        {
            get { return ConsoleColor.White; }
        }

        public WaterPotion()
        {
            unidentifiedDesc = "a clear potion";
            identifiedDesc = "A bottle of water";
            Useable = true;
        }

        public override void Use(Entity e)
        {
            e.Inventory.Remove(this);
            World.AddMessage("You drink the liquid, and feel refreshed.");
        }
    }
}
