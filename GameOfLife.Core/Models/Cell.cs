using System;

namespace GameOfLife.Core.Models
{
    /// <summary>
    /// Represents single cell.
    /// </summary>
    public struct Cell : IEquatable<Cell>
    {
        /// <summary>
        /// Cell horizontal position.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Cell vertical position.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> struct.
        /// </summary>
        /// <param name="x">Cell horizontal position.</param>
        /// <param name="y">Cell horizontal position.</param>
        public Cell(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.X, this.Y);
        }

        /// <inheritdoc/>
        public bool Equals(Cell other)
        {
            return this.X == other.X && this.Y == other.Y;
        }
    }
}
