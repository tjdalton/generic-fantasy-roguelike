using System;
using System.Collections.Generic;
using Roguelike.Tiles;
using Roguelike.Items;
using Roguelike.Races;
namespace Roguelike
{
    class World
    {
        private Tile[, ,] grid = new Tile[20, 60, 30];
        private List<Entity> mobs;
        private static Queue<String> msgQueue;
        private Game game;

        public Tile GetCell(int i, int j)
        {
            return grid[i, j, Level];
        }

        public void SetCell(int i, int j, Tile t)
        {
            grid[i, j, Level] = t;
        }

        public Entity Player
        {
            get;
            set;
        }

        public int Level
        {
            get;
            set;
        }

        public World(Game g)
        {
            game = g;
            mobs = new List<Entity>();
            msgQueue = new Queue<String>();
            Player = new Entity(Race.CreateRace(Race.Races.Human), this);
            Player.Player = true;
            Player.SetPos(5, 5);
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 60; j++)
                {
                    for (int k = 0; k < 30; k++)
                    {
                        Level = k;
                        grid[i, j, Level] = Tile.CreateTile(Tile.Tiles.Floor);
                    }
                }
            }
            Level = 0;
        }

        public void MoveMob(int i, int j, Entity e)
        {
            Level = e.DungeonLevel;
            if (!GetCell(j, i).Solid && !GetCell(j, i).Occupied)
            {
                GetCell(e.Y, e.X).RemoveMob();
                Redraw(e);
                e.SetPos(i, j);
                GetCell(e.Y, e.X).Mob = e;
                Redraw(e);
            }

            else if (!GetCell(j, i).Solid && GetCell(j, i).Occupied)
            {
                e.Fight(GetCell(j, i).Mob);
                if (GetCell(j, i).Mob.Dead)
                {
                    AddMessage("You slay the " + GetCell(j, i).Mob.Name);
                    mobs.Remove(GetCell(j, i).Mob);
                    GetCell(j, i).RemoveMob();
                    MoveMob(i, j, e);
                }
            }
            Level = Player.DungeonLevel;
        }

        public void Redraw(Entity e)
        {
            if (e.DungeonLevel == Player.DungeonLevel)
            {
                Console.SetCursorPosition(e.X, e.Y);
                Console.ForegroundColor = GetCell(e.Y, e.X).Colour;
                Console.Write(GetCell(e.Y, e.X).Icon);
                Console.ResetColor();
            }

        }
        public void ChangeLevel()
        {
            if (GetCell(Player.Y, Player.X).GetType().ToString() == "Roguelike.Tiles.StairsDown")
            {
                if (Level < 30)
                {
                    GetCell(Player.Y, Player.X).RemoveMob();
                    Level += 1;
                    Player.DungeonLevel = Level;
                    GetCell(Player.Y, Player.X).Mob = Player;
                    game.PrintWorld();
                }
            }
            else if (GetCell(Player.Y, Player.X).GetType().ToString() == "Roguelike.Tiles.StairsUp")
            {
                if (Level >= 1)
                {
                    GetCell(Player.Y, Player.X).RemoveMob();
                    Level -= 1;
                    Player.DungeonLevel = Level;
                    GetCell(Player.Y, Player.X).Mob = Player;
                    game.PrintWorld();
                }
            }
        }
        public void HandleInput(Entity e, ConsoleKeyInfo c)
        {
            switch (c.Key)
            {
                case ConsoleKey.NumPad1:
                    MoveMob(e.X - 1, e.Y + 1, e);
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.NumPad2:
                    MoveMob(e.X, e.Y + 1, e);
                    break;
                case ConsoleKey.NumPad3:
                    MoveMob(e.X + 1, e.Y + 1, e);
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.NumPad4:
                    MoveMob(e.X - 1, e.Y, e);
                    break;
                case ConsoleKey.NumPad5:
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.NumPad6:
                    MoveMob(e.X + 1, e.Y, e);
                    break;
                case ConsoleKey.NumPad7:
                    MoveMob(e.X - 1, e.Y - 1, e);
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.NumPad8:
                    MoveMob(e.X, e.Y - 1, e);
                    break;
                case ConsoleKey.NumPad9:
                    MoveMob(e.X + 1, e.Y - 1, e);
                    break;
                case ConsoleKey.Q:
                    if (c.Modifiers != ConsoleModifiers.Shift)
                        Quaff();
                    break;
                case ConsoleKey.OemComma:
                    if (c.Modifiers != ConsoleModifiers.Shift)
                        PickUp(e);
                    else if (c.Modifiers == ConsoleModifiers.Shift)
                        ChangeLevel();
                    break;
                case ConsoleKey.L:
                    if (c.Modifiers != ConsoleModifiers.Shift)
                    {
                        AddMessage(GetCell(Player.Y, Player.X).Description);
                    }
                    break;
                case ConsoleKey.OemPeriod:
                    if (c.Modifiers == ConsoleModifiers.Shift)
                        ChangeLevel();
                    break;
            }
        }
        public void HandleInput(Entity e, int c)
        {
            ConsoleKeyInfo tmp;
            switch (c)
            {
                case 1:
                    tmp = new ConsoleKeyInfo('\0', ConsoleKey.NumPad1, false, false, false);
                    HandleInput(e, tmp);
                    break;
                case 2:
                    tmp = new ConsoleKeyInfo('\0', ConsoleKey.NumPad2, false, false, false);
                    HandleInput(e, tmp);
                    break;
                case 3:
                    tmp = new ConsoleKeyInfo('\0', ConsoleKey.NumPad3, false, false, false);
                    HandleInput(e, tmp);
                    break;
                case 4:
                    tmp = new ConsoleKeyInfo('\0', ConsoleKey.NumPad4, false, false, false);
                    HandleInput(e, tmp);
                    break;
                case 5:
                    break;
                case 6:
                    tmp = new ConsoleKeyInfo('\0', ConsoleKey.NumPad6, false, false, false);
                    HandleInput(e, tmp);
                    break;
                case 7:
                    tmp = new ConsoleKeyInfo('\0', ConsoleKey.NumPad7, false, false, false);
                    HandleInput(e, tmp);
                    break;
                case 8:
                    tmp = new ConsoleKeyInfo('\0', ConsoleKey.NumPad8, false, false, false);
                    HandleInput(e, tmp);
                    break;
                case 9:
                    tmp = new ConsoleKeyInfo('\0', ConsoleKey.NumPad9, false, false, false);
                    HandleInput(e, tmp);
                    break;
            }
        }
        public Entity GetMob(Entity e)
        {
            Entity tmp = null;
            foreach (Entity m in mobs)
            {
                if (m.UniqueId == e.UniqueId)
                    tmp = m;
                break;
            }

            return tmp;
        }
        public void ClearConsole()
        {
            game.ClearConsole(0, 24, 0, 80);
        }
        public void PrintWorld()
        {
            game.PrintWorld();
        }
        public void AddMob(Entity e)
        {
            mobs.Add(e);
        }

        public void Tick()
        {
            Random random = new Random();
            foreach (Entity e in mobs)
            {
                HandleInput(e, random.Next(1, 9));
            }
            DisplayStats();
        }

        public void DisplayStats()
        {
            Console.SetCursorPosition(66, 1);
            Console.Write(Player.GetStat("STR"));
            Console.SetCursorPosition(66, 2);
            Console.Write(Player.GetStat("DEX"));
            Console.SetCursorPosition(66, 3);
            Console.Write(Player.GetStat("CON"));
            Console.SetCursorPosition(66, 4);
            Console.Write(Player.GetStat("INT"));
            Console.SetCursorPosition(66, 5);
            Console.Write(Player.GetStat("WIS"));
            Console.SetCursorPosition(66, 6);
            Console.Write(Player.GetStat("CHA"));
        }

        public void PickUp(Entity e)
        {
            int x = e.X;
            int y = e.Y;
            while (GetCell(y, x).Contents.Count != 0)
            {
                Item tmp = GetCell(y, x).Contents.Dequeue();
                Player.AddItem(tmp);
                AddMessage("You have picked up " + tmp.Description);
            }
        }

        public void Quaff()
        {
            Item.DisplayInventory(Player);
            game.ClearConsole(20, 25, 0, 80);
            game.PrintWorld();
        }
        static public void AddMessage(String s)
        {
            msgQueue.Enqueue(s);
        }

        static public void PopMessage()
        {
            if (!MsgEmpty())
                msgQueue.Dequeue();
        }

        static public bool MsgEmpty()
        {
            return msgQueue.Count == 0;
        }

        static public String ViewMessage()
        {
            if (!MsgEmpty())
            {
                return msgQueue.Peek();
            }
            else
            {
                return "";
            }
        }

    }
}
