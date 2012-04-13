using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Tiles
{
    class Wall : Tile
    {
        public override char Icon
        {
            get { return '#'; }
        }

        public override bool Solid
        {
            get { return true; }
        }

        public override ConsoleColor Colour
        {
            get
            { return ConsoleColor.Gray; }
        }
    }
}
