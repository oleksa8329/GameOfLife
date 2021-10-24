using System.Collections.Generic;
using System.Linq;
using GameOfLife.Core.Models;

namespace GameOfLife.Core.Engine
{
    /// <summary>
    /// This class looks for the adjacent cells for the game with CONSTANT BOUNDARY CONDITIONS.
    /// If I would like to change that to use PERIODIC conditions I'd have to just implement a single class derived from IAdjacentCellFinder
    /// </summary>
    public class ConstantBordersCellFinder : IAdjacentCellFinder
    {
        private static readonly List<(int xdiff, int ydiff)> DistanceList = new List<(int xdiff, int ydiff)>
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

        public ConstantBordersCellFinder(int sizeX, int sizeY)
        {
            _sizeX = sizeX;
            _sizeY = sizeY;
        }

        public IList<Cell> FindAdjacentCells(Cell cell)
        {
            return DistanceList
                .Select(d => new Cell(cell.X + d.xdiff, cell.Y + d.ydiff))
                .Where(c => this.IsInBoundaries(c))
                .ToList();
        }

        private bool IsInBoundaries(Cell cell)
        {
            return cell.X >= 0 && 
                   cell.X < _sizeX && 
                   cell.Y >= 0 && 
                   cell.Y < _sizeY;
        }
    }
}
