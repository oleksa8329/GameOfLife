using System.Collections.Generic;
using GameOfLife.Core.Models;

namespace GameOfLife.Core.Engine
{
    /// <summary>
    /// Represents game algorithm
    /// </summary>
    public interface IGameEngine
    {
        /// <summary>
        /// Find next generation for the given cell list.
        /// </summary>
        /// <param name="currentLiveCells">List of live cells in the current generation.</param>
        /// <returns>List of live cells in the next generation.</returns>
        HashSet<Cell> GetNextGeneration(HashSet<Cell> currentLiveCells);
    }
}
