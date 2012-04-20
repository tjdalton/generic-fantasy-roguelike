using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roguelike.Abilities;

namespace Roguelike.Classes
{
    class Wizard : Class
    {
        public override ConsoleColor Colour
        {
            get { return ConsoleColor.DarkMagenta; }
        }

        internal Wizard()
        {
            shortName = "Wiz";
            abilities = new List<Ability>();
            abilities.Add(Ability.CreateAbility(Ability.Abilities.MagicMissile));
        }

        public override int HPModifier
        {
            get { return 4; }
        }

        public override void HandleInput(World w, ConsoleKeyInfo c)
        {
            throw new NotImplementedException();
        }
        public override string Name
        {
            get { return "Wizard"; }
        }
    }
}
