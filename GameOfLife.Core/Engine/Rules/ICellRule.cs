namespace GameOfLife.Core.Engine.Rules
{
    /// <summary>
    /// Represents rules of the game for cells.
    /// </summary>
    public interface ICellRule
    {
        /// <summary>
        /// Determines if cell should live in next generation.
        /// </summary>
        /// <param name="liveNeighboursCount">Count of live neighbour cells.</param>
        /// <returns>true if cell should live in next generation; otherwise false</returns>
        bool ShouldLive(int liveNeighboursCount);
    }
}
