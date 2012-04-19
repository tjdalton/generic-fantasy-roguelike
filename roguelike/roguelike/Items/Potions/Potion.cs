using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Items.Potions
{
   abstract class Potion : Item
    {
       public override char Icon
       {
           get { return '!'; }
       }

       public abstract override ConsoleColor Colour
       {
           get;
       }

       public abstract override string Description
       {
           get;
       }
    }
}
