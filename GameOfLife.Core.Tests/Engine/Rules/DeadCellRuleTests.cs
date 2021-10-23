using FluentAssertions;
using GameOfLife.Core.Engine.Rules;
using NUnit.Framework;

namespace GameOfLife.Core.Tests.Engine.Rules
{
    [TestFixture]
    public class DeadCellRuleTests
    {
        [TestCase(3)]
        public void ShouldLive_Should_ReturnTrue_When_NeighboursCountIsValid(int neighboursCount)
        {
            // Arrange
            var rule = new DeadCellRule();

            // Act
            var shouldLive = rule.ShouldLive(neighboursCount);

            // Assert
            shouldLive.Should().BeTrue();
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(37)]
        public void ShouldLive_Should_ReturnTrue_When_NeighboursCountIsInvalid(int neighboursCount)
        {
            // Arrange
            var rule = new DeadCellRule();

            // Act
            var shouldLive = rule.ShouldLive(neighboursCount);

            // Assert
            shouldLive.Should().BeFalse();
        }
    }
}
