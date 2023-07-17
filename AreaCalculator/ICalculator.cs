using AreaCalculator.Enums;
using AreaCalculator.Models;

namespace AreaCalculator
{
    public interface ICalculator
    {
        public string CalculateArea(IFigure figure);

        public string CalculateArea(List<FigureParameter>? parameters = null);
    }
}
