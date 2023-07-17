using AreaCalculator.Enums;

namespace AreaCalculator.Models
{
    public interface IFigure
    {
        public FigureType CurrentFigureType { get; }

        public double CalculateArea();

        public bool IsTheFigureValid();
    }
}
