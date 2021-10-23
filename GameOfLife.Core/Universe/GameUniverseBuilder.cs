using System;
using System.Collections.Generic;
using System.Linq;
using GameOfLife.Core.Models;

namespace GameOfLife.Core.Universe
{
    /// <inheritdoc />
    public class GameUniverseBuilder : IGameUniverseBuilder
    {
        private int _sizeX;
        private int _sizeY;
        private readonly List<Cell> _seedCells;

        /// <summary>
        /// Creates a new instance of the <see cref="GameUniverseBuilder"/> class.
        /// </summary>
        public GameUniverseBuilder()
        {
            this._sizeX = 0;
            this._sizeY = 0;
            this._seedCells = new List<Cell>();
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

            this._sizeX = sizeX;
            this._sizeY = sizeY;

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

            this._seedCells.Add(new Cell(x, y));

            return this;
        }

        /// <inheritdoc />
        public IGameUniverse Build()
        {
            var validCells = this._seedCells.Where(c => c.X < this._sizeX && c.Y < this._sizeY); // check upper borders
            return new GameUniverse(this._sizeX, this._sizeY, validCells);
        }
    }
}