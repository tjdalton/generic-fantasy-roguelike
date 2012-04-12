using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Races
{
    abstract class Race
    {
        List<Abilities.Ability> abilities;

        public abstract bool Playable
        {
            get;
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
        }

        public abstract int HPModifier
        {
            get;
        }

        public abstract String Name
        {
            get;
        }

        public abstract void HandleInput(World w, ConsoleKeyInfo c);
    }
}
