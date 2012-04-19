using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Tiles
{
    class Door : Tile
    {
        public override ConsoleColor Colour
        {
            get
            {
                if (Open)
                {
                    if (this.Occupied)
                        return Mob.Colour;
                    else if (Contents.Count != 0)
                        return Contents.Peek().Colour;
                    else
                        return ConsoleColor.Gray;
                }
                else
                    return ConsoleColor.Gray;
            }
        }

        public override char Icon
        {
            get
            {
                if (Open)
                    return '/';
                else
                    return '+';
            }
        }

        public override bool Solid
        {
            get 
            {
                if (Open)
                    return true;
                else
                    return false;
            }
        }
    }
}
