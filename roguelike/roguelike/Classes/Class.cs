using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roguelike.Abilities;

namespace Roguelike.Classes
{
    abstract class Class
    {
        protected List<Ability> abilities;
        protected String shortName = "";
        public enum Classes
        {
            Wizard
        };

        public abstract ConsoleColor Colour
        {
            get;
        }

        public static Class CreateClass(Classes c)
        {
            switch (c)
            {
                case Classes.Wizard:
                    return new Wizard();
                default:
                    return new Wizard();
            }
        }

        public abstract void HandleInput(World w, ConsoleKeyInfo c);

        public abstract int HPModifier
        {
            get;
        }

        public abstract String Name
        {
            get;
        }

        public String ShortName
        {
            get { return shortName; }
        }
    }
}
