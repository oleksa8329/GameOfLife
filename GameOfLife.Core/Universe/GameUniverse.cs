using System.Collections.Generic;
using System.Linq;
using GameOfLife.Core.Models;

namespace GameOfLife.Core.Universe
{
    /// <inheritdoc />
    public class GameUniverse : IGameUniverse
    {
        private int _sizeX;
        private int _sizeY;
        private HashSet<Cell> _liveCells;

        /// <summary>
        ///  Creates a new instance of the <see cref="GameUniverse"/> class.
        /// </summary>
        /// <param name="sizeX"></param>
        /// <param name="sizeY"></param>
        /// <param name="seedCells"></param>
        public GameUniverse(int sizeX, int sizeY, IEnumerable<Cell> seedCells)
        {
            this._sizeX = sizeX;
            this._sizeY = sizeY;
            this.Generation = 0;
            this._liveCells = seedCells?.ToHashSet() ?? new HashSet<Cell>();
        }

        /// <inheritdoc />
        public int Generation { get; private set; }

        /// <inheritdoc />
        public IEnumerable<Cell> LiveCells => this._liveCells;

        /// <inheritdoc />
        public bool HasLiveCells => this._liveCells.Any();

        /// <inheritdoc />
        public void Tick()
        {
            // TODO

            this.Generation++;
        }
    }
}