using System;
using System.Text.RegularExpressions;

namespace GameOfLife
{
    class Program
    {
        private const int GliderSize = 3;

        private static int InputSizeX = 25;
        private static int InputSizeY = 25;
        private static int InputPositionX = 11;
        private static int InputPositionY = 11;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the game of life!");

            ReadSize();
            ReadGliderStartPosition();
            
            Console.WriteLine("Press any key to start the game");
            Console.ReadKey(false);
            
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

        private static void ReadSize()
        {
            Console.WriteLine($"Please enter universe size in format \"x y\" (default is {InputSizeX}x{InputSizeY}, min is {GliderSize}x{GliderSize}):");
            var input = Console.ReadLine();

            var match = Regex.Match(input, @"(?<x>\d+)\s+(?<y>\d+)\s*");
            if(!match.Success ||
               !int.TryParse(match.Groups["x"].Value, out var sizeX) ||
               !int.TryParse(match.Groups["y"].Value, out var sizeY))
            {
                Console.WriteLine($"Sorry, didn't quite catch that. Returning to default size {InputSizeX}x{InputSizeY}");
                return;
            }

            if (sizeX < 3 || sizeY < 3)
            {
                Console.WriteLine($"Sorry, min size is {GliderSize}x{GliderSize}. Returning to default size {InputSizeX}x{InputSizeY}");
                return;
            }

            InputSizeX = sizeX;
            InputSizeY = sizeY;
        }
        
        private static void ReadGliderStartPosition()
        {
            InputPositionX = InputSizeX / 2 - 1;
            InputPositionY = InputSizeY / 2 - 1;

            Console.WriteLine($"Please enter 'Glider' initial position in format \"x y\" (default is {InputPositionX},{InputPositionY}):");
            var input = Console.ReadLine();

            var match = Regex.Match(input, @"(?<x>\d+)\s+(?<y>\d+)\s*");
            if (!match.Success ||
                !int.TryParse(match.Groups["x"].Value, out var positionX) ||
                !int.TryParse(match.Groups["y"].Value, out var positionY))
            {
                Console.WriteLine($"Sorry, didn't quite catch that. Returning to default position {InputPositionX},{InputPositionY}");
                return;
            }

            if (positionX < 0 || 
                positionX > InputSizeX - GliderSize ||
                positionY < 0 ||
                positionY > InputSizeY - GliderSize)
            {
                Console.WriteLine($"Sorry, 'Glider' is out of borders. Returning to default position {InputPositionX},{InputPositionY}");
                return;
            }

            InputPositionX = positionX;
            InputPositionY = positionY;
        }
    }
}
