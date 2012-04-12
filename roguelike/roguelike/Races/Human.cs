using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Races
{
    class Human : Race
    {
        public override void HandleInput(World w, ConsoleKeyInfo c)
        {
            throw new NotImplementedException();
        }

        public override string Description
        {
            get { return "A generic Human"; }
        }

        public override int HPModifier
        {
            get { throw new NotImplementedException(); }
        }

        public override bool Playable
        {
            get { return true; }
        }

        public override string Name
        {
            get { return "Human"; }
        }

        public override ConsoleColor Colour
        {
            get { return ConsoleColor.Cyan; }
        }

        public override char Icon
        {
            get { return '@';}
        }
    }
}
