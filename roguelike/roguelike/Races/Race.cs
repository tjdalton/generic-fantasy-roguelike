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
        public enum Races
        {
            Human,
            Orc
        };
        public abstract bool Playable
        {
            get;
        }
        public static Race CreateRace(Races r)
        {
            switch (r)
            {
                case Races.Human:
                    return new Human();
                case Races.Orc:
                    return new Orc();
                default:
                    return new Human();
            }
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
