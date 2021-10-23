using System;
using System.Text.RegularExpressions;

namespace GameOfLife
{
    public class ConsoleInputReader
    {
        private const int GliderSize = 3;

        public ConsoleInputReader()
        {
            InputSizeX = 25;
            InputSizeY = 25;
            InputPositionX = 11;
            InputPositionY = 11;
        }

        public int InputSizeX { get; private set; }
        public int InputSizeY { get; private set; }
        public int InputPositionX { get; private set; }
        public int InputPositionY { get; private set; }

        public void ReadSize()
        {
            Console.WriteLine();
            Console.WriteLine($"Please enter universe size in format \"x y\" (default is {InputSizeX}x{InputSizeY}, min is {GliderSize}x{GliderSize}):");
            var inputString = Console.ReadLine();

            var match = Regex.Match(inputString, @"(?<x>\d+)\s+(?<y>\d+)\s*");
            if (!match.Success ||
                !int.TryParse(match.Groups["x"].Value, out var parsedSizeX) ||
                !int.TryParse(match.Groups["y"].Value, out var parsedSizeY))
            {
                Console.WriteLine($"Sorry, didn't quite catch that. Returning to default size {InputSizeX}x{InputSizeY}");
                return;
            }

            if (parsedSizeX < 3 || parsedSizeY < 3)
            {
                Console.WriteLine($"Sorry, min size is {GliderSize}x{GliderSize}. Returning to default size {InputSizeX}x{InputSizeY}");
                return;
            }

            InputSizeX = parsedSizeX;
            InputSizeY = parsedSizeY;
        }

        public void ReadGliderStartPosition()
        {
            this.RecalculateDefaultPosition();

            Console.WriteLine();
            Console.WriteLine($"Please enter 'Glider' initial position in format \"x y\" (default is {InputPositionX},{InputPositionY}):");
            var inputString = Console.ReadLine();

            var match = Regex.Match(inputString, @"(?<x>\d+)\s+(?<y>\d+)\s*");
            if (!match.Success ||
                !int.TryParse(match.Groups["x"].Value, out var parsedPositionX) ||
                !int.TryParse(match.Groups["y"].Value, out var parsedPositionY))
            {
                Console.WriteLine($"Sorry, didn't quite catch that. Returning to default position {InputPositionX},{InputPositionY}");
                return;
            }

            if (parsedPositionX < 0 ||
                parsedPositionX > InputSizeX - GliderSize ||
                parsedPositionY < 0 ||
                parsedPositionY > InputSizeY - GliderSize)
            {
                Console.WriteLine($"Sorry, 'Glider' is out of borders. Returning to default position {InputPositionX},{InputPositionY}");
                return;
            }

            InputPositionX = parsedPositionX;
            InputPositionY = parsedPositionY;
        }

        private void RecalculateDefaultPosition()
        {
            this.InputPositionX = this.InputSizeX / 2 - 1;
            this.InputPositionY = this.InputSizeY / 2 - 1;
        }
    }
}
