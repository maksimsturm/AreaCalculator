using AreaCalculator.Models;
using AreaCalculator.Models.Figure.Figures;
using AreaCalculator.Servicies;
using Microsoft.Extensions.DependencyInjection;

namespace AreaCalculator.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddTransient<IFigureFactory, FigureFactory>()
                .AddTransient<ICalculator, Calculator>()
                .AddTransient<IFigure, Circle>()
                .AddTransient<IFigure, Triangle>();
        }
    }
}
