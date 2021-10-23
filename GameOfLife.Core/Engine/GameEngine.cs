using System.Collections.Generic;
using System.Linq;
using GameOfLife.Core.Engine.Rules;
using GameOfLife.Core.Models;

namespace GameOfLife.Core.Engine
{
    public class GameEngine : IGameEngine
    {
        private readonly IAdjacentCellFinder _adjacentCellFinder;
        private readonly ICellRule _liveCellRule;
        private readonly ICellRule _deadCellRule;

        public GameEngine(IAdjacentCellFinder adjacentCellFinder, ICellRule liveCellRule, ICellRule deadCellRule)
        {
            this._adjacentCellFinder = adjacentCellFinder;
            this._liveCellRule = liveCellRule;
            this._deadCellRule = deadCellRule;
        }

        public HashSet<Cell> GetNextGeneration(HashSet<Cell> currentLiveCells)
        {
            if (!currentLiveCells.Any())
            {
                return currentLiveCells;
            }

            var nextLiveCells = new HashSet<Cell>();
            var currentDeadCells = new HashSet<Cell>();

            foreach (var cell in currentLiveCells)
            {
                var adjacentCells = this._adjacentCellFinder.FindAdjacentCells(cell);
                var liveNeighbours = this.FilterLiveCells(adjacentCells, currentLiveCells);
                if (_liveCellRule.ShouldLive(liveNeighbours.Count))
                {
                    nextLiveCells.Add(cell);
                }

                var deadNeighbours = this.FilterDeadCells(adjacentCells, currentLiveCells);
                foreach (var deadCell in deadNeighbours)
                {
                    currentDeadCells.Add(deadCell);
                }
            }

            foreach (var cell in currentDeadCells)
            {
                var adjacentCells = this._adjacentCellFinder.FindAdjacentCells(cell);
                var liveNeighbours = this.FilterLiveCells(adjacentCells, currentLiveCells);
                if (_deadCellRule.ShouldLive(liveNeighbours.Count))
                {
                    nextLiveCells.Add(cell);
                }
            }

            return nextLiveCells;
        }

        private IList<Cell> FilterLiveCells(IList<Cell> cells, HashSet<Cell> liveCells)
        {
            return cells.Where(liveCells.Contains).ToList();
        }

        private IList<Cell> FilterDeadCells(IList<Cell> cells, HashSet<Cell> liveCells)
        {
            return cells.Where(c => !liveCells.Contains(c)).ToList();
        }
    }
}
