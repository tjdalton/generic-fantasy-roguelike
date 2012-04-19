using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Abilities
{
    abstract class Ability
    {
        public enum Abilities
        {
            MagicMissile
        };
        public abstract String Name
        {
            get;
        }
        public static Ability CreateAbility(Abilities a)
        {
            switch (a)
            {
                case Abilities.MagicMissile:
                    return new MagicMissile();
                default:
                    return new MagicMissile();
            }
        }
        public abstract int LevelRequired
        {
            get;
        }

        public abstract void Invoke(World w, Entity invoker, int direction);
    }
}
