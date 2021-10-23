using FluentAssertions;
using GameOfLife.Core.Engine;
using GameOfLife.Core.Models;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;

namespace GameOfLife.Core.Tests.Engine
{
    [TestFixture]
    public class ConstantBordersAdjacentCellFinderTests
    {
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        public void FindAdjacentCells_Should_ReturnEmptyList_ForSmallSize(int sizeX, int sizeY)
        {
            // Arrange
            var adjacentCellFinder = new ConstantBordersAdjacentCellFinder(sizeX, sizeY);
            var cell = new Cell(0, 0);

            // Act
            var adjacentCells = adjacentCellFinder.FindAdjacentCells(cell);

            // Assert
            adjacentCells.Should().BeEmpty();
        }

        [TestCase(0, 0)]
        [TestCase(0, 24)]
        [TestCase(24, 0)]
        [TestCase(24, 24)]
        public void FindAdjacentCells_Should_Return3Cells_ForCornerCells(int x, int y)
        {
            // Arrange
            var adjacentCellFinder = new ConstantBordersAdjacentCellFinder(25, 25);
            var cell = new Cell(x, y);

            // Act
            var adjacentCells = adjacentCellFinder.FindAdjacentCells(cell);

            // Assert
            adjacentCells.Should().HaveCount(3);
        }

        [TestCase(0, 5)]
        [TestCase(13, 0)]
        [TestCase(22, 0)]
        public void FindAdjacentCells_Should_Return5Cells_ForBorderCells(int x, int y)
        {
            // Arrange
            var adjacentCellFinder = new ConstantBordersAdjacentCellFinder(25, 25);
            var cell = new Cell(x, y);

            // Act
            var adjacentCells = adjacentCellFinder.FindAdjacentCells(cell);

            // Assert
            adjacentCells.Should().HaveCount(5);
        }

        [TestCase(3, 5)]
        [TestCase(13, 1)]
        [TestCase(9, 9)]
        public void FindAdjacentCells_Should_Return8Cells_ForInsideCells(int x, int y)
        {
            // Arrange
            var adjacentCellFinder = new ConstantBordersAdjacentCellFinder(25, 25);
            var cell = new Cell(x, y);

            // Act
            var adjacentCells = adjacentCellFinder.FindAdjacentCells(cell);

            // Assert
            adjacentCells.Should().HaveCount(8);
        }

        [TestCase(-1, -2)]
        [TestCase(3, 41)]
        [TestCase(-2, 9)]
        [TestCase(26, 26)]
        public void FindAdjacentCells_Should_ReturnEmptyList_ForOutsideCells(int x, int y)
        {
            // Arrange
            var adjacentCellFinder = new ConstantBordersAdjacentCellFinder(25, 25);
            var cell = new Cell(x, y);

            // Act
            var adjacentCells = adjacentCellFinder.FindAdjacentCells(cell);

            // Assert
            adjacentCells.Should().BeEmpty();
        }
    }
}
