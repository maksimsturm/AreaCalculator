using AreaCalculator;
using AreaCalculator.Constants;
using AreaCalculator.Enums;
using AreaCalculator.Extentions;
using AreaCalculator.Models;
using AreaCalculator.Models.Figure.Figures;
using AreaCalculator.Servicies;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Tests.Servicies;

namespace Tests
{
    public class CalculatorTests
    {
        private ICalculator _areaCalculator => new Calculator();

        private CalculationService calculationService => new CalculationService();

        private ExpectedMessageBuilder messageBuilder => new ExpectedMessageBuilder();

        [Test]
        public void CalculateAreaWithNoPrameters()
        {
            // Arrange

            // Act
            var value = _areaCalculator.CalculateArea();

            // Assert
            value.Should().Be(MessageTexts.CanNotCalculateAreaByEmptyPrameters);
        }

        [Test]
        public void CalculateAreaWithToManyParameters()
        {
            // Arrange
            var parameters = new List<FigureParameter>();
            for (int i = 0; i <= new Random().Next(4, 10); i++)
            {
                parameters.Add(new FigureParameter(ParameterType.Side, i));
            }

            // Act
            var value = _areaCalculator.CalculateArea(parameters);

            // Assert
            value.Should().Be(MessageTexts.CanNotDetermineFigureType);
        }

        [Test]
        [TestCase(FigureType.Circle)]
        [TestCase(FigureType.Triangle)]
        public void SuccessCalculateAreaWithFigureAutodetect(FigureType figureType)
        {
            // Arrange
            var parameters = GetFigureParameters(figureType);

            // Act
            var value = _areaCalculator.CalculateArea(parameters);

            // Assert
            CheckReceivedMessageSuccessfull(figureType, parameters, value);
        }

        [Test]
        [TestCase(FigureType.Circle)]
        [TestCase(FigureType.Triangle)]
        public void SuccessCalculateArea(FigureType figureType)
        {
            // Arrange
            var parameters = GetFigureParameters(figureType);
            var figure = GetFigure(figureType, parameters);

            // Act
            var value = _areaCalculator.CalculateArea(figure);

            // Assert
            CheckReceivedMessageSuccessfull(figureType, parameters, value);
        }

        [Test]
        [TestCase(FigureType.Circle)]
        [TestCase(FigureType.Triangle)]
        public void CalculateAreaWithInvalidParameters(FigureType figureType)
        {
            // Arrange
            var parameters = figureType == FigureType.Circle 
                ? new List<FigureParameter>() { new FigureParameter(ParameterType.Side, new Random().Next(4, 10)) } 
                : new List<FigureParameter>() 
                {
                    new FigureParameter(ParameterType.Side, 4),
                    new FigureParameter(ParameterType.Side, 5),
                    new FigureParameter(ParameterType.Side, 16)
                };

            var figure = GetFigure(figureType, parameters);


            // Act
            var value = _areaCalculator.CalculateArea(figure);

            // Assert
            value.Should().Be(messageBuilder.ForFigureType(figureType).GetInvalidFigureParametersMessage());
        }

        private List<FigureParameter> GetFigureParameters(FigureType figureType)
        {
            if (figureType == FigureType.Circle)
            {
                return new List<FigureParameter>() { new FigureParameter(ParameterType.Radius, new Random().Next(10, 100)) };
            }

            if (figureType == FigureType.Triangle)
            {
                var parameters = new List<FigureParameter>();
                while (!new Triangle(parameters).IsTheFigureValid())
                {
                    parameters = new List<FigureParameter>() 
                    {
                        new FigureParameter(ParameterType.Side, new Random().Next(10, 200)),
                        new FigureParameter(ParameterType.Side, new Random().Next(10, 200)),
                        new FigureParameter(ParameterType.Side, new Random().Next(10, 200)) 
                    };
                }

                return parameters;
            }

            return new List<FigureParameter>();
        }

        private IFigure? GetFigure(FigureType figureType, List<FigureParameter> parameters) => 
            figureType == FigureType.Circle ? new Circle(parameters) : new Triangle(parameters);

        private void CheckReceivedMessageSuccessfull(FigureType figureType, List<FigureParameter> parameters, string receivedMessage)
        {
            var expectedArea = calculationService.CalculateArea(figureType, parameters);
            expectedArea.Should().NotBeNull("The was a problem to check area");
            var expectedSuccessMessage = messageBuilder.ForFigureType(figureType).WithAreaValue((double)expectedArea).GetSuccessfullCalculationMessage();
            receivedMessage.Should().Be(expectedSuccessMessage);
        }
    }
}