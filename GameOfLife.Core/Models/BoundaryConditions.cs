namespace GameOfLife.Core.Models
{
    /// <summary>
    /// Represents game boundary conditions
    /// </summary>
    public enum BoundaryConditions
    {
        /// <summary>
        /// All cells on the perimeter of the edge are dead.
        /// </summary>
        Constant = 0,

        /// <summary>
        /// Assumes that the neighbors to a cell at the edge of the grid are those cells at the opposite edge of the grid.
        /// </summary>
        Periodic = 1
    }
}
