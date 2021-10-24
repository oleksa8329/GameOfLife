using System;
using System.Text.RegularExpressions;
using GameOfLife.Core.Models;

namespace GameOfLife
{
    public class ConsoleInputReader
    {
        private const int GliderSize = 3;

        public ConsoleInputReader()
        {
            this.InputSizeX = 25;
            this.InputSizeY = 25;
            this.InputPositionX = 11;
            this.InputPositionY = 11;
            this.InputBoundaryConditions = BoundaryConditions.Constant;
        }

        public int InputSizeX { get; private set; }
        public int InputSizeY { get; private set; }
        public int InputPositionX { get; private set; }
        public int InputPositionY { get; private set; }
        public BoundaryConditions InputBoundaryConditions { get; private set; }

        public void ReadSize()
        {
            Console.WriteLine();
            Console.WriteLine($"Please enter universe size in format \"x y\" (default is {this.InputSizeX}x{this.InputSizeY}, min is {GliderSize}x{GliderSize}):");
            var inputString = Console.ReadLine();

            var match = Regex.Match(inputString, @"(?<x>\d+)\s+(?<y>\d+)\s*");
            if (!match.Success ||
                !int.TryParse(match.Groups["x"].Value, out var parsedSizeX) ||
                !int.TryParse(match.Groups["y"].Value, out var parsedSizeY))
            {
                Console.WriteLine($"Sorry, didn't quite catch that. Returning to default size {this.InputSizeX}x{this.InputSizeY}");
                return;
            }

            if (parsedSizeX < 3 || parsedSizeY < 3)
            {
                Console.WriteLine($"Sorry, min size is {GliderSize}x{GliderSize}. Returning to default size {this.InputSizeX}x{this.InputSizeY}");
                return;
            }

            this.InputSizeX = parsedSizeX;
            this.InputSizeY = parsedSizeY;
        }

        public void ReadGliderStartPosition()
        {
            this.RecalculateDefaultPosition();

            Console.WriteLine();
            Console.WriteLine($"Please enter 'Glider' initial position in format \"x y\" (default is {this.InputPositionX},{this.InputPositionY}):");
            var inputString = Console.ReadLine();

            var match = Regex.Match(inputString, @"(?<x>\d+)\s+(?<y>\d+)\s*");
            if (!match.Success ||
                !int.TryParse(match.Groups["x"].Value, out var parsedPositionX) ||
                !int.TryParse(match.Groups["y"].Value, out var parsedPositionY))
            {
                Console.WriteLine($"Sorry, didn't quite catch that. Returning to default position {this.InputPositionX},{this.InputPositionY}");
                return;
            }

            if (parsedPositionX < 0 ||
                parsedPositionX > this.InputSizeX - GliderSize ||
                parsedPositionY < 0 ||
                parsedPositionY > this.InputSizeY - GliderSize)
            {
                Console.WriteLine($"Sorry, 'Glider' is out of borders. Returning to default position {this.InputPositionX},{this.InputPositionY}");
                return;
            }

            this.InputPositionX = parsedPositionX;
            this.InputPositionY = parsedPositionY;
        }

        public void ReadBoundaryConditions()
        {
            Console.WriteLine();
            Console.WriteLine($"Please enter game boundary conditions (type in '{nameof(BoundaryConditions.Constant)}' or '{nameof(BoundaryConditions.Periodic)}'):");
            var inputString = Console.ReadLine();

            if (!Enum.TryParse<BoundaryConditions>(inputString.Trim(), true, out var parsedBoundaryConditions))
            {
                Console.WriteLine($"Sorry, didn't quite catch that. Returning to default conditions {this.InputBoundaryConditions:G}");
                return;
            }

            this.InputBoundaryConditions = parsedBoundaryConditions;
        }

        private void RecalculateDefaultPosition()
        {
            this.InputPositionX = this.InputSizeX / 2 - 1;
            this.InputPositionY = this.InputSizeY / 2 - 1;
        }
    }
}
