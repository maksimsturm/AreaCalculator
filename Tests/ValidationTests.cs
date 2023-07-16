using AreaCalculator;
using AreaCalculator.Constants;
using AreaCalculator.Enums;
using AreaCalculator.Models;
using AreaCalculator.Models.Figure.Figures;
using AreaCalculator.Servicies;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Tests.Servicies;

namespace Tests
{
    public class ValidationTests
    {

        private ICalculator _areaCalculator => new Calculator();

        private CalculationService calculationService => new CalculationService();

        private ExpectedMessageBuilder messageBuilder => new ExpectedMessageBuilder();


        [SetUp]
        public void Setup()
        {
            
        }

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

            // Act
            var value = _areaCalculator.CalculateArea(figureType, parameters);

            // Assert
            CheckReceivedMessageSuccessfull(figureType, parameters, value);
        }

        private List<FigureParameter> GetFigureParameters(FigureType figureType)
        {
            return figureType == FigureType.Circle
                ? new List<FigureParameter>() { new FigureParameter(ParameterType.Radius, new Random().Next(10, 100)) }
                : new List<FigureParameter>() {
                    new FigureParameter(ParameterType.Side, new Random().Next(10, 100)),
                    new FigureParameter(ParameterType.Side, new Random().Next(10, 100)),
                    new FigureParameter(ParameterType.Side, new Random().Next(10, 100)),
                };
        }

        private void CheckReceivedMessageSuccessfull(FigureType figureType, List<FigureParameter> parameters, string receivedMessage)
        {
            var expectedArea = calculationService.CalculateArea(figureType, parameters);
            expectedArea.Should().NotBeNull("The was a problem to check area");
            var expectedSuccessMessage = messageBuilder.ForFigureType(figureType).WithAreaValue((double)expectedArea).GetSuccessfullCalculationMessage();
            receivedMessage.Should().Be(expectedSuccessMessage);
        }
    }
}