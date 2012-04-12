using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Races
{
    class Orc : Race
    {
        public override ConsoleColor Colour
        {
            get { return ConsoleColor.DarkGreen; }
        }

        public override void HandleInput(World w, ConsoleKeyInfo c)
        {
            throw new NotImplementedException();
        }

        public override string Name
        {
            get { return "Orc"; }
        }

        public override bool Playable
        {
            get { return false; }
        }

        public override int HPModifier
        {
            get { throw new NotImplementedException(); }
        }

        public override string Description
        {
            get { return "An angry looking orc"; }
        }

        public override char Icon
        {
            get { return 'o'; }
        }
    }
}
