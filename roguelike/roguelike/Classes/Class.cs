using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Classes
{
   abstract class Class
    {
       protected List<Abilities.Ability> abilities;

       public abstract ConsoleColor Colour
       {
           get;
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
    }
}
