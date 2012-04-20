using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Abilities
{
    class StrengthBuff : Ability
    {
        public override string Name
        {
            get { return "Strength Buff"; }
        }

        public override int LevelRequired
        {
            get { return 1; }
        }
        public override void Invoke(World w, Entity invoker, int direction)
        {
            throw new NotImplementedException();
        }

        public override void Invoke(Entity invoker, Items.Item item)
        {
            invoker.ModifyStat("STR", 5);
            invoker.Inventory.Remove(item);
            World.AddMessage(item.UseText);
        }
    }
}
