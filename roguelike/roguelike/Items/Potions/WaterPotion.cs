using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roguelike.Abilities;

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
            actionDescription = "You drink the liquid and feel refreshed";
            Useable = true;
            abilities = new List<Ability>();
            abilities.Add(Ability.CreateAbility(Ability.Abilities.DefaultAbility));
        }
    }
}
