﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Tiles
{
    class StairsDown : Tile
    {
        public override char Icon
        {
            get
            {
                if (this.Occupied)
                    return Mob.Icon;
                else if (Contents.Count != 0)
                    return Contents.Peek().Icon;
                else
                    return icon;
            }
        }

        public override bool Solid
        {
            get
            {
                return false;
            }
        }

        public StairsDown()
        {
            icon = '>';
            description = "There are stairs leading down here";
            Contents = new Queue<Item>();
        }

        public override ConsoleColor Colour
        {
            get
            {
                if (this.Occupied)
                    return Mob.Colour;
                else if (Contents.Count != 0)
                    return Contents.Peek().Colour;
                else
                    return ConsoleColor.Gray;
            }
        }
    }
}
