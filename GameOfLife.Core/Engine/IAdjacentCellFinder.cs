using System.Collections.Generic;
using GameOfLife.Core.Models;

namespace GameOfLife.Core.Engine
{
    /// <summary>
    /// Finds cells adjacent to the given cell
    /// </summary>
    public interface IAdjacentCellFinder
    {
        /// <summary>
        /// Finds adjacent neighbour cells for the provided cell.
        /// </summary>
        /// <param name="cell">Cell to find adjacent cells to.</param>
        /// <returns>List of cells adjacent to the given cell.</returns>
        IList<Cell> FindAdjacentCells(Cell cell);
    }
}
