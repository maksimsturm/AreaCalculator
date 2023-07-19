using AreaCalculator.Enums;

namespace AreaCalculator.Servicies
{
    public interface ISquareStrategyFactory
    {
        public ISquareStrategy GetSquareStrategy(FigureType figureType);
    }
}
