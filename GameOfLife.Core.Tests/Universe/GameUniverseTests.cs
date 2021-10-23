using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using GameOfLife.Core.Models;
using GameOfLife.Core.Universe;
using NUnit.Framework;

namespace GameOfLife.Core.Tests.Universe
{
    [TestFixture]
    public class GameUniverseTests
    {
        public void LiveCells_Should_ReturnCollectionOfLiveCells()
        {
            // Arrange
            var seedCells = new List<Cell>
            {
                new Cell(0, 0),
                new Cell(3, 4)
            };
            var universe = new GameUniverse(25, 25, seedCells);

            // Act
            var liveCells = universe.LiveCells;

            // Assert
            liveCells.Count().Should().Be(2);
        }

        [Test]
        public void HasLiveCells_Should_ReturnTrue_IfHasAnyLiveCells()
        {
            // Arrange
            var seedCells = new List<Cell>
            {
                new Cell(0, 0),
                new Cell(3, 4)
            };
            var universe = new GameUniverse(25, 25, seedCells);

            // Act
            var hasLiveCells = universe.HasLiveCells;

            // Assert
            hasLiveCells.Should().BeTrue();
        }

        [Test]
        public void HasLiveCells_Should_ReturnFalse_IfEmpty()
        {
            // Arrange
            var universe = new GameUniverse(25, 25, Enumerable.Empty<Cell>());

            // Act
            var hasLiveCells = universe.HasLiveCells;

            // Assert
            hasLiveCells.Should().BeFalse();
        }

        [Test]
        public void Tick_Should_IncreaseGeneration()
        {
            // Arrange
            var universe = new GameUniverse(25, 25, Enumerable.Empty<Cell>());

            // Act & Assert
            universe.Tick();
            universe.Generation.Should().Be(1);

            universe.Tick();
            universe.Tick();
            universe.Generation.Should().Be(3);
        }
    }
}
