using System;

namespace GameOfLife
{
    public static class Program
    {
        private static readonly TimeSpan PauseDuration = TimeSpan.FromMilliseconds(500);

        static void Main(string[] args)
        {
            var inputReader = new ConsoleInputReader();
            ReadInputParameters(inputReader);
            
            var consoleDrawer = new ConsoleDrawer();
            consoleDrawer.Clear();

            consoleDrawer.SetHeaderText("Generation 0:");
            consoleDrawer.DrawBox(12, 11);
            consoleDrawer.DrawBox(13, 12);
            consoleDrawer.DrawBox(11, 13);
            consoleDrawer.DrawBox(12, 13);
            consoleDrawer.DrawBox(13, 13);
            
            consoleDrawer.SetHeaderText("Generation 0. Pres any key to exit");
            Console.ReadKey(false);
        }

        private static void ReadInputParameters(ConsoleInputReader inputReader)
        {
            Console.WriteLine("Welcome to the game of life!");

            inputReader.ReadSize();

            inputReader.ReadGliderStartPosition();
            
            Console.WriteLine();
            Console.WriteLine($"Each generation will change every {PauseDuration.Milliseconds}ms.");

            Console.WriteLine();
            Console.WriteLine("Press any key to start the game");
            Console.ReadKey(false);
        }
        
        
    }
}
