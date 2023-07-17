using AreaCalculator.Constants;
using AreaCalculator.Enums;
using AreaCalculator.Models;
using AreaCalculator.Models.Figure.Figures;
using AreaCalculator.Servicies;
using Microsoft.Extensions.DependencyInjection;

namespace AreaCalculator
{
    public class Calculator : ICalculator
    {
        private readonly IFigureFactory _figureFactory;
        
        public Calculator()
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<IFigure, Circle>()
                .AddTransient<IFigure, Triangle>()
                .AddScoped<IFigureFactory, FigureFactory>()
                .BuildServiceProvider();

                _figureFactory = serviceProvider.GetService<IFigureFactory>();
        }
        
        public string CalculateArea(FigureType figureType, List<FigureParameter>? parameters = null)
        {
            var figure = _figureFactory.GetFigure(figureType, parameters);
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
                var figure = _figureFactory.GetFigure(FigureType.Triangle, parameters);
                return DeterminedFigureMessage(figure);
            }

            if (parameters.Count == 1 && parameters.First().Type == ParameterType.Radius)
            {
                var figure = _figureFactory.GetFigure(FigureType.Circle, parameters);
                return DeterminedFigureMessage(figure);
            }

            return MessageTexts.CanNotDetermineFigureType;
        }

        private string DeterminedFigureMessage(IFigure figure)
        {
            return figure.IsTheFigureValid()
                ? string.Format(MessageTexts.SuccesfullCalculatedArea, figure.CurrentFigureType, figure.CalculateArea())
                : string.Format(MessageTexts.InvalidFigureParameters, figure.CurrentFigureType);
        }
    }
}