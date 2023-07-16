using AreaCalculator.Enums;
using AreaCalculator.Models;

namespace AreaCalculator
{
    public interface ICalculator
    {
        public string CalculateArea(FigureType figureType, List<FigureParameter>? parameters = null);

        public string CalculateArea(List<FigureParameter>? parameters = null);
    }
}
