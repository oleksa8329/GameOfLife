using System;

namespace GameOfLife.Core.Models
{
    public struct Cell : IEquatable<Cell>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Cell(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is Cell other))
            {
                return false;
            }

            return this.Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.X, this.Y);
        }

        public bool Equals(Cell other)
        {
            return this.X == other.X && this.Y == other.Y;
        }
    }
}
