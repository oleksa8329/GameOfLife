using System.Collections.Generic;
using System.Linq;
using GameOfLife.Core.Engine;
using GameOfLife.Core.Models;

namespace GameOfLife.Core.Universe
{
    /// <inheritdoc />
    public class GameUniverse : IGameUniverse
    {
        private readonly IGameEngine _gameEngine;
        private HashSet<Cell> _liveCells;

        /// <summary>
        ///  Creates a new instance of the <see cref="GameUniverse"/> class.
        /// </summary>
        /// <param name="seedCells">Initial cells.</param>
        /// <param name="gameEngine">Game engine.</param>
        public GameUniverse(IGameEngine gameEngine, IEnumerable<Cell> seedCells)
        {
            this._gameEngine = gameEngine;
            this._liveCells = seedCells?.ToHashSet() ?? new HashSet<Cell>();

            this.Generation = 0;
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
            var nextGeneration = _gameEngine.GetNextGeneration(_liveCells);
            this._liveCells = nextGeneration;

            this.Generation++;
        }
    }
}