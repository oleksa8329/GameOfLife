namespace GameOfLife.Core.Universe
{
    /// <summary>
    /// Interface for creating <see cref="IGameUniverse"/> instances.
    /// </summary>
    public interface IGameUniverseBuilder
    {
        /// <summary>
        /// Instructs builder to use specified size when creating the universe.
        /// </summary>
        /// <param name="sizeX">Universe horizontal size.</param>
        /// <param name="sizeY">Universe vertical size.</param>
        /// <returns>Builder object instance.</returns>
        IGameUniverseBuilder WithSize(int sizeX, int sizeY);

        /// <summary>
        /// Instructs builder to add live cell when creating the universe.
        /// </summary>
        /// <param name="x">Cell horizontal position.</param>
        /// <param name="y">Cell vertical position.</param>
        /// <returns>Builder object instance.</returns>
        IGameUniverseBuilder WithCell(int x, int y);

        /// <summary>
        /// Creates a new instance of the <see cref="IGameUniverse"/> interface.
        /// </summary>
        /// <returns>A new instance of the <see cref="IGameUniverse"/> interface.</returns>
        IGameUniverse Build();
    }
}
