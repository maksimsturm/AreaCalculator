using AreaCalculator.Models;
using AreaCalculator.Models.Figure.Figures;
using AreaCalculator.Servicies;
using AreaCalculator.Servicies.SquareStrategies;
using Microsoft.Extensions.DependencyInjection;

namespace AreaCalculator.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddTransient<ISquareStrategy, CircleSquareStrategy>()
                .AddTransient<ISquareStrategy, TriangleSquareStrategy>()
                .AddTransient<ISquareStrategyFactory, SquareStrategyFactory>()
                .AddTransient<ICalculator, Calculator>()
                .AddTransient<IFigureBuilder, FigureBuilder>()
                .AddTransient<IFigure, Circle>()
                .AddTransient<IFigure, Triangle>();
        }
    }
}
