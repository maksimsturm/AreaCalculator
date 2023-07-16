using AreaCalculator.Enums;
using AreaCalculator.Models;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculator.Servicies
{
    [Export(typeof(IFigureIdentifyingServiceFactory))]
    internal class FigureIdentifyingService : IFigureIdentifyingServiceFactory
    {
        private readonly IEnumerable<IFigure> _implementedFigureTypes;

        public IFigure? GetFigure(List<FigureParameter> parameters)
        {
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

        public IFigure? GetFigure(FigureType figureType, List<FigureParameter> parameters = null)
        {
            var figure = _implementedFigureTypes.First(e => e.CurrentFigureType == figureType);
            if (figure == null && parameters != null)
            {
                return GetFigure(parameters);
            }

            return figure;
        }
    }
}
