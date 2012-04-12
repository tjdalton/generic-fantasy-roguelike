using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Abilities
{
    abstract class Ability
    {
        public abstract String Name
        {
            get;
        }

        public abstract int LevelRequired
        {
            get;
        }

        public abstract void Invoke(World w, Entity invoker, int direction);
    }
}
