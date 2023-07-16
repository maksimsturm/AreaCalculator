using AreaCalculator.Enums;
using AreaCalculator.Models;

namespace AreaCalculator.Servicies
{
    public interface IFigureIdentifyingServiceFactory
    {
        public IFigure GetFigure(FigureType figureType, List<FigureParameter>? parameters = null);
    }
}
