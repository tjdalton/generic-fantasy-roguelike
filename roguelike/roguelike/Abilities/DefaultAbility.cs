using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Abilities
{
    class DefaultAbility : Ability
    {
        public override string Name
        {
            get { return "Default Ability"; }
        }

        public override int LevelRequired
        {
            get { return 0; }
        }
        public override void Invoke(World w, Entity invoker, int direction)
        {
        }

        public override void Invoke(Entity invoker, Items.Item item)
        {
            World.AddMessage(item.UseText);
        }
    }
}
