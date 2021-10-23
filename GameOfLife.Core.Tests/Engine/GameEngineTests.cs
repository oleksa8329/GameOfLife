using System.Collections.Generic;
using FluentAssertions;
using GameOfLife.Core.Engine;
using GameOfLife.Core.Engine.Rules;
using GameOfLife.Core.Models;
using NUnit.Framework;

namespace GameOfLife.Core.Tests.Engine
{
    [TestFixture]
    public class GameEngineTests
    {
        private GameEngine _gameEngine;

        [SetUp]
        public void SetUp()
        {
            _gameEngine = new GameEngine(
                new ConstantBordersAdjacentCellFinder(25, 25),
                new LiveCellRule(),
                new DeadCellRule());
        }

        [Test]
        public void GetNextGeneration_Should_ReturnEmptyList_IfCurrentGenerationIsEmpty()
        {
            // Arrange
            var currentGeneration = new HashSet<Cell>();

            // Act
            var nextGeneration = _gameEngine.GetNextGeneration(currentGeneration);

            // Assert
            nextGeneration.Should().BeEmpty();
        }
    }
}
