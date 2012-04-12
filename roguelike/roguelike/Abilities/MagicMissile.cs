using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Abilities
{
    class MagicMissile : Ability
    {
        public override string Name
        {
            get { return "Magic Missile"; }
        }

        public override int LevelRequired
        {
            get { return 1; }
        }

        public override void Invoke(World w, Entity invoker, int direction)
        {
            throw new NotImplementedException();
        }
    }
}
