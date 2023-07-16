using AreaCalculator.Constants;
using AreaCalculator.Enums;
using AreaCalculator.Models;
using AreaCalculator.Servicies;
using System.Composition;

namespace AreaCalculator
{
    public class Calculator : ICalculator
    {
        private readonly IFigureIdentifyingServiceFactory _figureIdentifyingServiceFactory;

        [ImportingConstructor]
        public Calculator([Import] IFigureIdentifyingServiceFactory figureIdentifyingServiceFactory)
        {
            _figureIdentifyingServiceFactory = figureIdentifyingServiceFactory;
        }

        public string CalculateArea(FigureType figureType, List<FigureParameter>? parameters = null)
        {
            var figure = _figureIdentifyingServiceFactory.GetFigure(figureType, parameters);
            return figure.CalculateArea().ToString();
        }

        public string CalculateArea(List<FigureParameter>? parameters = null)
        {
            if (parameters.Count == 2 && parameters.All(e => e.Type == ParameterType.Side) && parameters.Distinct().Count() == 1)
            {
                return String.Format(MessageTexts.AreaCalculationIsNotImplemented, FigureType.Square);
            }

            if (parameters.Count == 3)
            {
                var figure = _figureIdentifyingServiceFactory.GetFigure(FigureType.Triangle, parameters);
                return String.Format(MessageTexts.SuccesfullCalculatedArea, figure.CurrentFigureType, figure.CalculateArea());
            }

            if (parameters.Count == 1 && parameters.First().Type == ParameterType.Radius)
            {
                var figure = _figureIdentifyingServiceFactory.GetFigure(FigureType.Circle, parameters);
                return String.Format(MessageTexts.SuccesfullCalculatedArea, figure.CurrentFigureType, figure.CalculateArea());
            }

            if (parameters == null || !parameters.Any())
            {
                return MessageTexts.CanNotCalclulateAreaByEmptyPrameters;
            }

            return MessageTexts.CanNotDetermineFigureType;
        }
    }
}