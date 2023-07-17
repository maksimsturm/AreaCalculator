using AreaCalculator.Enums;
using AreaCalculator.Models;
using AreaCalculator.Models.Figure.Figures;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculator.Servicies.SquareStrategies
{
    public class FigureBuilder
    {

        private readonly IEnumerable<IFigure> _figures;

        public FigureBuilder()
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<IFigure, Circle>()
                .AddTransient<IFigure, Triangle>()
                .BuildServiceProvider();

            _figures = serviceProvider.GetServices<IFigure>();
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
            switch (figureType)
            {
                case FigureType.Circle:
                    return new Circle(parameters);
                case FigureType.Triangle:
                    return new Triangle(parameters);
                default:
                    return _figures.FirstOrDefault(e => e.CurrentFigureType == figureType);
            }
        }
    }
}
