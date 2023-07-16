using AreaCalculator.Enums;
using AreaCalculator.Models;
using System.Composition;

namespace AreaCalculator.Servicies
{
    public class FigureFactory : IFigureFactory
    {
        private readonly IEnumerable<IFigure> _figures;

        public FigureFactory(IEnumerable<IFigure> figures)
        {
            _figures = figures;
        }

        public IFigure? GetFigure(List<FigureParameter> parameters)
        {
            var type = typeof(IFigure);
            var test = (IEnumerable<IFigure>)AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()).Where(p => type.IsAssignableFrom(p));
            if (parameters.Count == 3)
            {
                return new Models.Figure.Figures.Triangle(parameters);
            }

            if (parameters.Any(e => e.Type == ParameterType.Radius))
            {
                return new Models.Figure.Figures.Circle(parameters);
            }

            return null;
        }

        public IFigure? GetFigure(FigureType figureType, List<FigureParameter> parameters)
        {
            var figure = _figures.First(e => e.CurrentFigureType == figureType);
            if (figure == null && parameters != null)
            {
                return GetFigure(parameters);
            }
            else
            {
                switch (figureType)
                {
                    case FigureType.Circle:
                        return new Models.Figure.Figures.Circle(parameters);
                    case FigureType.Triangle:
                        return new Models.Figure.Figures.Triangle(parameters);
                }
            }

            return figure;
        }
    }
}
