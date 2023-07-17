using AreaCalculator.Constants;
using AreaCalculator.Enums;
using AreaCalculator.Extentions;
using AreaCalculator.Models;
using AreaCalculator.Servicies;
using Microsoft.Extensions.DependencyInjection;

namespace AreaCalculator
{
    public class Calculator : ICalculator
    {
        private readonly IFigureBuilder _figureBuilder;

        private readonly ISquareStrategyFactory _strategyFactory;

        public Calculator()
        {
            var serviceCollection = new ServiceCollection()
                .AddServices();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            _figureBuilder = serviceProvider.GetService<IFigureBuilder>();
            _strategyFactory = serviceProvider.GetService<ISquareStrategyFactory>();
        }

        public string CalculateArea(IFigure figure)
        {
            return DeterminedFigureMessage(figure);
        }

        public string CalculateArea(List<FigureParameter>? parameters = null)
        {
            if (parameters == null || !parameters.Any())
            {
                return MessageTexts.CanNotCalculateAreaByEmptyPrameters;
            }

            if (parameters.Count == 2 && parameters.All(e => e.Type == ParameterType.Side) && parameters.Distinct().Count() == 1)
            {
                return string.Format(MessageTexts.AreaCalculationIsNotImplemented, FigureType.Square);
            }

            if (parameters.Count == 3)
            {
                var figure = _figureBuilder.GetFigure(FigureType.Triangle, parameters);
                return DeterminedFigureMessage(figure);
            }

            if (parameters.Count == 1 && parameters.First().Type == ParameterType.Radius)
            {
                var figure = _figureBuilder.GetFigure(FigureType.Circle, parameters);
                return DeterminedFigureMessage(figure);
            }

            return MessageTexts.CanNotDetermineFigureType;
        }

        private string DeterminedFigureMessage(IFigure figure)
        {
            var squareStrategy = _strategyFactory.GetSquareStrategy(figure.CurrentFigureType);

            return figure.IsTheFigureValid()
                ? string.Format(MessageTexts.SuccesfullCalculatedArea, figure.CurrentFigureType, squareStrategy.Calculate(figure))
                : string.Format(MessageTexts.InvalidFigureParameters, figure.CurrentFigureType);
        }
    }
}