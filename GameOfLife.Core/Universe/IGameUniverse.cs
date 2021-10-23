using System.Collections.Generic;
using GameOfLife.Core.Models;

namespace GameOfLife.Core.Universe
{
    /// <summary>
    /// Represents game universe in the specific discrete moment of time.
    /// </summary>
    public interface IGameUniverse
    {
        /// <summary>
        /// Generation number.
        /// </summary>
        int Generation { get; }

        /// <summary>
        /// Collection of live cells at current generation.
        /// </summary>
        IEnumerable<Cell> LiveCells { get; }

        /// <summary>
        /// Checks if current generation has live cells.
        /// </summary>
        bool HasLiveCells { get; }

        /// <summary>
        /// Moves universe to the next generation.
        /// </summary>
        void Tick();
    }
}
