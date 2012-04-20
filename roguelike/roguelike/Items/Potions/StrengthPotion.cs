using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roguelike.Abilities;

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
            actionDescription = "You feel strength course through you";
            Useable = true;
            abilities = new List<Ability>();
            abilities.Add(Ability.CreateAbility(Ability.Abilities.StrengthBuff));
        }
    }
}
