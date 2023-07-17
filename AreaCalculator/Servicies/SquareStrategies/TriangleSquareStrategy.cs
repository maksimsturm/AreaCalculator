using AreaCalculator.Enums;
using AreaCalculator.Models;

namespace AreaCalculator.Servicies
{
    public class TriangleSquareStrategy : ISquareStrategy
    {
        public FigureType FigureType => FigureType.Triangle;

        public double Calculate(List<FigureParameter> parameters)
        {
            var sides = parameters.Select(e => Convert.ToDouble(e.Value)).ToList();
            var halfOfPerimeter = sides.Sum() / 2;
            var product = 1D;
            for (var i = 0; i < sides.Count; i++)
            {
                product *= halfOfPerimeter - sides[i];
            }
            return Math.Sqrt(halfOfPerimeter * product);
        }
    }
}
