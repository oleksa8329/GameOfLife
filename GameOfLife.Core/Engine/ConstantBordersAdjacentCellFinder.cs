using System.Collections.Generic;
using System.Linq;
using GameOfLife.Core.Models;

namespace GameOfLife.Core.Engine
{
    /// <summary>
    /// This class looks for the adjacent cells for the game with CONSTANT BOUNDARY CONDITIONS.
    /// If I would like to change that to use PERIODIC conditions I'd have to just implement a single class derived from IAdjacentCellFinder
    /// </summary>
    public class ConstantBordersAdjacentCellFinder : IAdjacentCellFinder
    {
        private const int FromX = 0;
        private const int FromY = 0;

        private static readonly List<(int xdiff, int ydiff)> neighbourList = new List<(int xdiff, int ydiff)>
        {
            (-1, -1),
            (-1, 0),
            (-1, 1),
            (0, -1),
            // exclude self (0, 0)
            (0, 1),
            (1, -1),
            (1, 0),
            (1, 1),
        };

        private readonly int _sizeX;
        private readonly int _sizeY;

        public ConstantBordersAdjacentCellFinder(int sizeX, int sizeY)
        {
            this._sizeX = sizeX;
            this._sizeY = sizeY;
        }

        public IList<Cell> FindAdjacentCells(Cell cell)
        {
            return neighbourList
                .Select(n => new Cell(cell.X + n.xdiff, cell.Y + n.ydiff))
                .Where(c => this.IsInBoundaries(c))
                .ToList();
        }

        private bool IsInBoundaries(Cell cell)
        {
            return cell.X >= FromX && 
                   cell.X < this._sizeX && 
                   cell.Y >= FromY && 
                   cell.Y < this._sizeY;
        }
    }
}
