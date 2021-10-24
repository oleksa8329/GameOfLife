using System.Collections.Generic;
using System.Linq;
using GameOfLife.Core.Models;

namespace GameOfLife.Core.Engine
{
    /// <summary>
    /// This class looks for the adjacent cells for the game with PERIODIC BOUNDARY CONDITIONS.
    /// <remarks>
    /// This class have some parts in common with ConstantBordersCellFinder,
    /// but I believe that it is better to keep them separate just in case
    /// the implementation will change or I will find out an easier way to find adjacent cells
    /// So for now lets keep code duplication.
    /// </remarks>
    /// </summary>
    public class PeriodicBordersCellFinder : IAdjacentCellFinder
    {
        private static readonly (int xdiff, int ydiff)[] DistanceList = 
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

        public PeriodicBordersCellFinder(int sizeX, int sizeY)
        {
            _sizeX = sizeX;
            _sizeY = sizeY;
        }

        public IList<Cell> FindAdjacentCells(Cell cell)
        {
            return DistanceList
                .Select(d => new Cell(cell.X + d.xdiff, cell.Y + d.ydiff))
                .Select(c => this.PlaceInBoundaries(c))
                .ToList();
        }

        private Cell PlaceInBoundaries(Cell cell)
        {
            if (cell.X < 0)
            {
                cell.X = _sizeX + cell.X;
            }

            if (cell.X >= _sizeX)
            {
                cell.X = _sizeX - cell.X;
            }

            if (cell.Y < 0)
            {
                cell.Y = _sizeY + cell.Y;
            }

            if (cell.Y >= _sizeY)
            {
                cell.Y = _sizeY - cell.Y;
            }

            return cell;
        }
    }
}