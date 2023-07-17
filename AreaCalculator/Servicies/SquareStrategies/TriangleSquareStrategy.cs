using AreaCalculator.Enums;
using AreaCalculator.Models;
using AreaCalculator.Models.Figure.Figures;

namespace AreaCalculator.Servicies
{
    public class TriangleSquareStrategy : ISquareStrategy
    {
        public FigureType FigureType => FigureType.Triangle;

        public double Calculate(IFigure figure)
        {
            var sides = figure.GetParameters().Select(e => Convert.ToDouble(e.Value)).ToList();
            var halfOfPerimeter = sides.Sum() / 2;
            var product = 1D;
            for (var i = 0; i < sides.Count; i++)
            {
                product *= halfOfPerimeter - sides[i];
            }
            return Math.Sqrt(halfOfPerimeter * product);
        }

        public IFigure GetFigure(List<FigureParameter> parameters)
        {
            return new Triangle(parameters);
        }
    }
}
