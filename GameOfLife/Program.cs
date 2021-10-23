using System;
using System.Threading;
using GameOfLife.Core.Universe;

namespace GameOfLife
{
    public static class Program
    {
        private static readonly TimeSpan PauseDuration = TimeSpan.FromMilliseconds(400);

        public static void Main()
        {
            var input = ReadInputParameters();
            var universe = BuildUniverseFromInputParameters(input);
            PlayTheGame(universe);
        }

        private static ConsoleInputReader ReadInputParameters()
        {
            Console.WriteLine("Welcome to the game of life!");

            var inputReader = new ConsoleInputReader();
            inputReader.ReadSize();
            inputReader.ReadGliderStartPosition();
            
            Console.WriteLine();
            Console.WriteLine($"Each generation will change every {PauseDuration.Milliseconds}ms.");

            Console.WriteLine();
            Console.WriteLine("Press any key to start the game");
            Console.ReadKey(false);

            return inputReader;
        }

        private static IGameUniverse BuildUniverseFromInputParameters(ConsoleInputReader input)
        {
            var builder = new GameUniverseBuilder();

            builder.WithSize(input.InputSizeX, input.InputSizeY)
                .WithCell(input.InputPositionX + 1, input.InputPositionY)
                .WithCell(input.InputPositionX + 2, input.InputPositionY + 1)
                .WithCell(input.InputPositionX, input.InputPositionY + 2)
                .WithCell(input.InputPositionX + 1, input.InputPositionY + 2)
                .WithCell(input.InputPositionX + 2, input.InputPositionY + 2);

            return builder.Build();
        }

        private static void PlayTheGame(IGameUniverse universe)
        {
            var consoleDrawer = new ConsoleDrawer();

            while (universe.HasLiveCells)
            {
                DrawCurrentGeneration(consoleDrawer, universe);
                
                Thread.Sleep(PauseDuration);

                universe.Tick();
            }

            consoleDrawer.SetHeaderText($"Stopped at generation {universe.Generation}. Press any key to exit.");
            Console.ReadKey(false);
        }

        private static void DrawCurrentGeneration(ConsoleDrawer consoleDrawer, IGameUniverse universe)
        {
            consoleDrawer.Clear();
            consoleDrawer.SetHeaderText($"Generation {universe.Generation}:");

            foreach (var cell in universe.LiveCells)
            {
                consoleDrawer.DrawBox(cell.X, cell.Y);
            }
        }
    }
}
