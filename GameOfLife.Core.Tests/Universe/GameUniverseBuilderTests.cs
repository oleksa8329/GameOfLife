using System;
using FluentAssertions;
using GameOfLife.Core.Universe;
using NUnit.Framework;

namespace GameOfLife.Core.Tests.Universe
{
    [TestFixture]
    public class GameUniverseBuilderTests
    {
        [TestCase(-1, 2)]
        [TestCase(-1, 0)]
        [TestCase(3, -2)]
        [TestCase(0, -2)]
        [TestCase(-5, -2)]
        public void WithSize_Should_ThrowArgumentOutOfRangeException_When_ParamIsLessThanZero(int sizeX, int sizeY)
        {
            // Arrange
            var builder = new GameUniverseBuilder();

            // Act
            Action withSize = () => builder.WithSize(sizeX, sizeY);

            // Assert
            withSize.Should().Throw<ArgumentOutOfRangeException>();
        }

        [TestCase(0, 0)]
        [TestCase(0, 1)]
        [TestCase(2, 0)]
        [TestCase(25, 25)]
        public void WithSize_Should_NotThrow_When_ParamsAreInRange(int sizeX, int sizeY)
        {
            // Arrange
            var builder = new GameUniverseBuilder();

            // Act
            Action withSize = () => builder.WithSize(sizeX, sizeY);

            // Assert
            withSize.Should().NotThrow();
        }


        [TestCase(-1, 2)]
        [TestCase(-1, 0)]
        [TestCase(3, -2)]
        [TestCase(0, -2)]
        [TestCase(-5, -2)]
        public void WithCell_Should_ThrowArgumentOutOfRangeException_When_ParameIsLessThanZero(int x, int y)
        {
            // Arrange
            var builder = new GameUniverseBuilder();

            // Act
            Action withCell = () => builder.WithCell(x, y);

            // Assert
            withCell.Should().Throw<ArgumentOutOfRangeException>();
        }

        [TestCase(0, 0)]
        [TestCase(0, 1)]
        [TestCase(2, 0)]
        [TestCase(25, 11)]
        public void WithCell_Should_NotThrow_When_ParamsAreInRange(int x, int y)
        {
            // Arrange
            var builder = new GameUniverseBuilder();

            // Act
            Action withCell = () => builder.WithCell(x, y);

            // Assert
            withCell.Should().NotThrow();
        }

        [Test]
        public void Build_Should_ReturnInstance()
        {
            // Arrange
            var builder = new GameUniverseBuilder();

            // Act
            var universe = builder.Build();

            // Assert
            universe.Should().NotBeNull();
        }
    }
}
