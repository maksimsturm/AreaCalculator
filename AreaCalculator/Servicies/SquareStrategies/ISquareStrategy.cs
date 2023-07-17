using AreaCalculator.Enums;
using AreaCalculator.Models;

namespace AreaCalculator.Servicies
{
    public interface ISquareStrategy
    {
        public FigureType FigureType { get; }

        public double Calculate(List<FigureParameter> parameters);
    }
}
