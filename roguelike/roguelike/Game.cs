using System;
using System.Collections.Generic;
using Roguelike.Items;
using Roguelike.Races;
using Roguelike.Tiles;
namespace Roguelike
{
    class Game
    {
        public static World world;
        static void Main(string[] args)
        {
            Game game = new Game();
            game.initScreen();
            game.InitWorld();
            game.NewGame();
            game.PrintWorld();
            game.Populate();
            game.GameLoop();

        }
        public void NewGame()
        {
            List<Classes.Class> classList = new List<Classes.Class>();
            Dictionary<char, Classes.Class> list = new Dictionary<char, Classes.Class>();
            foreach (Classes.Class.Classes c in Enum.GetValues(typeof(Classes.Class.Classes)))
            {
                classList.Add(Classes.Class.CreateClass(c));
            }
            Console.SetCursorPosition(2, 2);
            Console.Write("What is your name?");
            Console.SetCursorPosition(21, 3);
            Console.CursorVisible = true;
            String name = Console.ReadLine();
            Console.CursorVisible = false;
            world.Player.Name = name;
            world.ClearConsole();
            Console.SetCursorPosition(2, 2);
            Console.Write("What is your class?");
            Console.SetCursorPosition(21, 3);
            int i = 65;
            int x = 2;
            int y = 5;
            foreach (Classes.Class tmp in classList)
            {
                list.Add((char)i, tmp);
                Console.SetCursorPosition(x, y);
                Console.Write("{0}) {1}", (char)i, tmp.Name);
                y = y + 2;
                if (y >= 20)
                {
                    x = x + 25;
                    y = 5;
                }
                i++;
            }
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            while (key.Key != ConsoleKey.Spacebar)
            {
                key = Console.ReadKey(true);
                try
                {
                   world.Player.Class = list[key.KeyChar];
                    break;
                }
                catch (Exception ex)
                {
                }
            }
        }
        
        public void InitWorld()
        {
            world = new World(this);
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 60; j++)
                {
                    for (int k = 0; k < 30; k++)
                    {
                        world.Level = k;
                        if (i == 0 || j == 0 || i == 19 || j == 59)
                        {
                            world.SetCell(i, j, Tile.CreateTile(Tile.Tiles.Wall));
                        }
                    }
                }
            }
            world.Level = 0;
        }
        public bool ExitPressed(ConsoleKeyInfo c)
        {
            bool exit = false;
            if (c.Key == ConsoleKey.Q)
            {
                if (c.Modifiers == ConsoleModifiers.Shift)
                    exit = true;
            }

            return exit;
        }
        public void GameLoop()
        {
            ConsoleKeyInfo tmp = new ConsoleKeyInfo();
            while (!ExitPressed(tmp))
            {
                tmp = Console.ReadKey(true);
                world.HandleInput(world.Player, tmp);
                world.Tick();
                if (!ExitPressed(tmp))
                {
                    ProcessMessage();

                }
            }
        }

        public void Populate()
        {
            world.GetCell(5, 5).Mob = world.Player;
            Entity tmp = new Entity(Race.CreateRace(Race.Races.Orc));
            tmp.SetPos(10, 10);
            world.GetCell(10, 10).Mob = tmp;
            world.AddMob(tmp);
            world.GetCell(5, 5).Mob.SetPos(5, 5);
            world.GetCell(9, 3).AddContents(Item.CreateItem(Item.Items.StrengthPotion));
            world.GetCell(5, 25).AddContents(Item.CreateItem(Item.Items.WaterPotion));
            world.SetCell(15, 10, Tile.CreateTile(Tile.Tiles.StairsDown));
            world.Level = 1;
            world.SetCell(15, 10, Tile.CreateTile(Tile.Tiles.StairsUp));
            world.Level = 0;
            PrintWorld();

        }

        public void ProcessMessage()
        {
            ClearConsole(20, 24, 0, 80);
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(0, 20 + i);
                Console.Write(World.ViewMessage());
                World.PopMessage();
            }
            Console.ResetColor();
        }
        public void ClearConsole(int startX, int endX, int startY, int endY)
        {
            for (int i = startX; i < endX; i++)
            {
                for (int j = startY; j < endY; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.Write(" ");
                }
            }
        }
        public void PrintWorld()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 60; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.ForegroundColor = world.GetCell(i, j).Colour;
                    Console.Write(world.GetCell(i, j).Icon);
                }
            }
            Console.SetCursorPosition(61, 0);
            Console.Write(world.Player.Name);
            Console.SetCursorPosition(61, 1);
            Console.Write("{0}  Lv. {1}", world.Player.Class.Name, world.Player.Level);
            Console.SetCursorPosition(61, 3);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Str: ");
            Console.SetCursorPosition(61, 4);
            Console.Write("Dex: ");
            Console.SetCursorPosition(61, 5);
            Console.Write("Con: ");
            Console.SetCursorPosition(61, 6);
            Console.Write("Int: ");
            Console.SetCursorPosition(61, 7);
            Console.Write("Wis: ");
            Console.SetCursorPosition(61, 8);
            Console.Write("Cha: ");
            Console.ResetColor();
            world.DisplayStats();
        }

        public void initScreen()
        {
            Console.CursorVisible = false;
        }


        public void drawcell(int i, int j)
        {
        }

    }
}
