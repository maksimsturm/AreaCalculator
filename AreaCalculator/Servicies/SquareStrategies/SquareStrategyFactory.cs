using AreaCalculator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculator.Servicies
{
    public class SquareStrategyFactory : ISquareStrategyFactory
    {
        private readonly IEnumerable<ISquareStrategy> _squareStrategies;

        public SquareStrategyFactory(IEnumerable<ISquareStrategy> squareStrategies)
        {
            _squareStrategies = squareStrategies;
        }

        public ISquareStrategy GetSquareStrategy(FigureType figureType)
        {
            return _squareStrategies.First(s => s.FigureType == figureType);
        }
    }
}
