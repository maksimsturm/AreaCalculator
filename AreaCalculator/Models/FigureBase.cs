using AreaCalculator.Enums;
using AreaCalculator.Servicies;
using Microsoft.Extensions.DependencyInjection;

namespace AreaCalculator.Models
{
    public abstract class FigureBase
    {
        private ISquareStrategyFactory _squareFactory => _serviceProvider.GetService<ISquareStrategyFactory>();

        private readonly ServiceProvider _serviceProvider = new ServiceCollection()
                .AddTransient<ISquareStrategy, CircleSquareStrategy>()
                .AddTransient<ISquareStrategy, TriangleSquareStrategy>()
                .AddTransient<ISquareStrategyFactory, SquareStrategyFactory>()
                .BuildServiceProvider();

        protected List<FigureParameter> Parameters;

        protected FigureType FigureType;

        protected List<ParameterType> AcceptebleParameterTypes { get; set; }

        protected FigureBase(List<FigureParameter>? parameters = null)
        {
            Parameters = parameters;
        }

        protected FigureBase(List<FigureParameter> parameters, List<ParameterType> acceptebleParameterTypes)
        {
            Parameters = parameters;
            AcceptebleParameterTypes = acceptebleParameterTypes;
        }

        protected double Calculate()
        {
            return _squareFactory.GetSquareStrategy(FigureType).Calculate(Parameters);
        }
    }
}
