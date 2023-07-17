using AreaCalculator.Constants;
using AreaCalculator.Enums;
using AreaCalculator.Models;
using AreaCalculator.Servicies.SquareStrategies;

namespace AreaCalculator
{
    public class Calculator : ICalculator
    {
        private readonly FigureBuilder figureBuilder = new FigureBuilder();

        public Calculator()
        {
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
                var figure = figureBuilder.GetFigure(FigureType.Triangle, parameters);
                return DeterminedFigureMessage(figure);
            }

            if (parameters.Count == 1 && parameters.First().Type == ParameterType.Radius)
            {
                var figure = figureBuilder.GetFigure(FigureType.Circle, parameters);
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