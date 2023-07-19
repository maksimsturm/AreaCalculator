using AreaCalculator.Enums;

namespace AreaCalculator.Models
{
    public interface IFigure
    {
        public FigureType CurrentFigureType { get; }

        public bool IsTheFigureValid();

        public List<FigureParameter> GetParameters();
    }
}
