using System;
using System.Collections.Generic;
using System.Linq;
using GameOfLife.Core.Engine;
using GameOfLife.Core.Engine.Rules;
using GameOfLife.Core.Models;

namespace GameOfLife.Core.Universe
{
    /// <inheritdoc />
    public class GameUniverseBuilder : IGameUniverseBuilder
    {
        private int _sizeX;
        private int _sizeY;
        private BoundaryConditions _conditions;
        private readonly List<Cell> _seedCells;

        /// <summary>
        /// Creates a new instance of the <see cref="GameUniverseBuilder"/> class.
        /// </summary>
        public GameUniverseBuilder()
        {
            _sizeX = 0;
            _sizeY = 0;
            _conditions = BoundaryConditions.Constant;
            _seedCells = new List<Cell>();
        }

        /// <inheritdoc />
        public IGameUniverseBuilder WithSize(int sizeX, int sizeY)
        {
            if (sizeX < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(sizeX), $"Universe {nameof(sizeX)} cannot be less than 0.");
            }

            if (sizeY < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(sizeY), $"Universe {nameof(sizeY)} cannot be less than 0.");
            }

            _sizeX = sizeX;
            _sizeY = sizeY;

            return this;
        }

        /// <inheritdoc />
        public IGameUniverseBuilder WithCell(int x, int y)
        {
            if (x < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(x), "Cell cannot be out of borders of the universe.");
            }

            if (y < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(y), "Cell cannot be  out of borders of the universe.");
            }

            // Here we cannot check for _sizeX,_sizeY borders because WithSize() method can be called after WithCell()

            _seedCells.Add(new Cell(x, y));

            return this;
        }

        public IGameUniverseBuilder WithBoundaryConditions(BoundaryConditions conditions)
        {
            _conditions = conditions;

            return this;
        }

        /// <inheritdoc />
        public IGameUniverse Build()
        {
            var gameEngine = new GameEngine(
                this.BuildAdjacentCellFinder(),
                new LiveCellRule(), 
                new DeadCellRule());

            var validCells = _seedCells.Where(c => c.X < _sizeX && c.Y < _sizeY); // check upper borders

            return new GameUniverse(gameEngine, validCells);
        }

        private IAdjacentCellFinder BuildAdjacentCellFinder()
        {
            switch (_conditions)
            {
                case BoundaryConditions.Periodic:
                    return new PeriodicBordersCellFinder(_sizeX, _sizeY);

                case BoundaryConditions.Constant:
                default:
                    return new ConstantBordersCellFinder(_sizeX, _sizeY);
            }
        }
    }
}