using AreaCalculator.Enums;

namespace AreaCalculator.Models.Figure.Figures
{
    public class Circle : FigureBase, IFigure
    {
        private static List<ParameterType> acceptebleParameterTypes => new List<ParameterType> { ParameterType.Radius };

        public FigureType CurrentFigureType => FigureType.Circle;

        public Circle(List<FigureParameter> parameters) : base(parameters, acceptebleParameterTypes)
        {
            FigureType = FigureType.Circle;
        }

        public Circle()
        { 
        }

        public double CalculateArea()
        {
            return Calculate();
        }

        public bool IsTheFigureValid()
        {
            return Parameters.Count == 1 && Parameters.All(e => e.Type == acceptebleParameterTypes.First());
        }
    }
}
