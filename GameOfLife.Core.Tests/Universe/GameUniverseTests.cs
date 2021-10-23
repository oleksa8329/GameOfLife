using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using GameOfLife.Core.Engine;
using GameOfLife.Core.Models;
using GameOfLife.Core.Universe;
using Moq;
using NUnit.Framework;

namespace GameOfLife.Core.Tests.Universe
{
    [TestFixture]
    public class GameUniverseTests
    {
        private Mock<IGameEngine> _gameEngineMock;

        [SetUp]
        public void SetUp()
        {
            _gameEngineMock = new Mock<IGameEngine>();
            _gameEngineMock
                .Setup(x => x.GetNextGeneration(It.IsAny<HashSet<Cell>>()))
                .Returns(new HashSet<Cell>());
        }

        [Test]
        public void LiveCells_Should_ReturnCollectionOfLiveCells()
        {
            // Arrange
            var seedCells = new List<Cell>
            {
                new Cell(0, 0),
                new Cell(3, 4)
            };
            var universe = new GameUniverse(_gameEngineMock.Object, seedCells);

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
            var universe = new GameUniverse(_gameEngineMock.Object, seedCells);

            // Act
            var hasLiveCells = universe.HasLiveCells;

            // Assert
            hasLiveCells.Should().BeTrue();
        }

        [Test]
        public void HasLiveCells_Should_ReturnFalse_IfEmpty()
        {
            // Arrange
            var universe = new GameUniverse(_gameEngineMock.Object, Enumerable.Empty<Cell>());

            // Act
            var hasLiveCells = universe.HasLiveCells;

            // Assert
            hasLiveCells.Should().BeFalse();
        }

        [Test]
        public void Tick_Should_IncreaseGeneration()
        {
            // Arrange
            var universe = new GameUniverse(_gameEngineMock.Object, Enumerable.Empty<Cell>());

            // Act & Assert
            universe.Tick();
            universe.Generation.Should().Be(1);

            universe.Tick();
            universe.Tick();
            universe.Generation.Should().Be(3);
        }
    }
}
