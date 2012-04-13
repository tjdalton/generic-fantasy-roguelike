using System;
using System.Collections;
using System.Collections.Generic;

namespace Roguelike.Tiles
{
    abstract class Tile
    {
        protected char icon;
        protected String description = "";

        abstract public char Icon
        {
            get;
        }

        public String Description
        {
            get
            {
                String output = "";
                if (this.Occupied && this.Mob.Icon != '@')
                {
                    output = String.Concat(output, "You see: ", this.Mob.Description, " ");
                }
                if (Contents.Count != 0)
                {
                    if (output == "")
                        output = "You see: ";
                    output = String.Concat(output, Contents.Peek().Description, " ");
                }
                if (description.Length != 0)
                {
                    if (output.Length != 0)
                        output += "\n";
                    output += description;
                }
                if (output.Length == 0 && description.Length == 0)
                    output = "You see nothing on the floor";
                return output;
            }
        }

        public Queue<Item> Contents
        {
            get;
            protected set;
        }

        public Entity Mob
        {
            set;
            get;
        }

        abstract public ConsoleColor Colour
        {
            get;
        }

        abstract public bool Solid
        {
            get;

        }
        public bool Occupied
        {
            get
            {
                if (Mob == null)
                    return false;
                else
                    return true;
            }
        }

        public void AddContents(Item i)
        {
            Contents.Enqueue(i);
        }

        public void RemoveMob()
        {
            Mob = null;
        }

    }
}
