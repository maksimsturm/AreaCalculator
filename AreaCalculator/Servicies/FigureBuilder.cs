using AreaCalculator.Enums;
using AreaCalculator.Models;
using AreaCalculator.Models.Figure.Figures;

namespace AreaCalculator.Servicies.SquareStrategies
{
    public class FigureBuilder : IFigureBuilder
    {
        private readonly ISquareStrategyFactory _squareStrategyFactory;

        public FigureBuilder(ISquareStrategyFactory squareStrategyFactory)
        {
            _squareStrategyFactory = squareStrategyFactory;
        }

        public IFigure? GetFigure(List<FigureParameter> parameters)
        {
            if (parameters.Count == 3)
            {
                return new Triangle(parameters);
            }

            if (parameters.Any(e => e.Type == ParameterType.Radius))
            {
                return new Circle(parameters);
            }

            return null;
        }

        public IFigure? GetFigure(FigureType figureType, List<FigureParameter> parameters)
        {
            var squareStrategy = _squareStrategyFactory.GetSquareStrategy(figureType);
            return squareStrategy.GetFigure(parameters);
        }
    }
}
