using AreaCalculator.Enums;
using AreaCalculator.Servicies;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Tests.Servicies;

namespace Tests.Unit_tests
{
    public class SquareStrategyTests
    {
        private List<ISquareStrategy> _squareStrategies;

        private CalculationService calculationService => new CalculationService();

        [SetUp]
        public void SetUp()
        {
            _squareStrategies = new List<ISquareStrategy>() 
            {
                new CircleSquareStrategy(),
                new TriangleSquareStrategy()
            };
        }

        [Test]
        [TestCase(FigureType.Circle)]
        [TestCase(FigureType.Triangle)]
        public void SquareStrategyCalculationTest(FigureType figureType)
        {
            // Arrange
            var strategy = _squareStrategies.First(e => e.FigureType == figureType);
            var validParameters = TestDataService.GetValidFigureParameters(figureType);

            // Act
            var figure = strategy.GetFigure(validParameters);

            // Assert
            using var assertionScope = new AssertionScope();
            var expectedCalculationArea = calculationService.CalculateArea(figure.CurrentFigureType, figure.GetParameters());
            strategy.FigureType.Should().Be(figureType, "Invalid Figure type");
            strategy.Calculate(figure).Should().Be(expectedCalculationArea, "Invalid calculation area value");
        }
    }
}
