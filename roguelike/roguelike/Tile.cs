using System;
using System.Collections;
using System.Collections.Generic;

namespace roguelike
{
    class Tile
    {
        //private Entity mob;
        //Queue<Item> contents;
        public enum TileType { Floor = 46, Wall = 35, OpenDoor = 47, ClosedDoor = 43, StairsDown = 62, StairsUp = 60 };


        public char Icon
        {
            get
            {
                if (this.Occupied)
                    return Mob.Icon;
                else if (Contents.Count != 0)
                    return Contents.Peek().Icon;
                else
                    return (char)Type;
            }
        }

        public TileType Type
        {
            set;
            get;
        }

        public String Description
        {
            get
            {
                String output = "";
                if (this.Occupied && this.Mob.Icon != '@'){
                    output = String.Concat(output,"You see: ", this.Mob.Description, " ");
                }
                if (Contents.Count != 0)
                {
                    if (output == "")
                        output = "You see: ";
                    output = String.Concat(output, Contents.Peek().Description, " ");
                }
                if (output.Length == 0)
                    output = "You see nothing on the floor";
                return output;
            }

        }

        public Queue<Item> Contents
        {
            get;
            private set;
        }

        public Entity Mob
        {
            set;
            get;
        }

        public ConsoleColor Colour
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

        public bool Solid
        {
            get
            {
                if (Type == TileType.Floor || Type == TileType.OpenDoor || Type == TileType.StairsDown || Type == TileType.StairsUp)
                    return false;
                else
                    return true;
            }
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

        public Tile()
        {
            Contents = new Queue<Item>();
            Type = TileType.Floor;
        }

        public void RemoveMob()
        {
            Mob = null;
        }

    }
}
