using AreaCalculator.Enums;
using AreaCalculator.Models;
using AreaCalculator.Models.Figure.Figures;
using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using Tests.Servicies;

namespace Tests.Unit_tests
{
    public class FigureTests
    {
        [Test]
        [TestCase(FigureType.Circle)]
        [TestCase(FigureType.Triangle)]
        public void SquareStrategyFigureGenerationTest(FigureType figureType)
        {
            // Arrange
            var validPrameters = TestDataService.GetValidFigureParameters(figureType);

            // Act
            var figure = GetFigure(figureType, validPrameters);

            // Assert
            using var assertionScope = new AssertionScope();
            figure.CurrentFigureType.Should().Be(figureType, "Invalid Figure type");
            figure.IsTheFigureValid().Should().BeTrue("Fiure should be ");
            figure.GetParameters().Should().BeEquivalentTo(validPrameters);
        }

        private IFigure GetFigure(FigureType figureType, List<FigureParameter> parameters)
        {
            return figureType == FigureType.Circle ? new Circle(parameters) : new Triangle(parameters);
        }
    }
}
