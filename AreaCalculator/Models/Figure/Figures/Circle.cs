using AreaCalculator.Enums;

namespace AreaCalculator.Models.Figure.Figures
{
    public class Circle : FigureBase, IFigure
    {
        private static List<ParameterType> acceptebleParameterTypes => new List<ParameterType> { ParameterType.Radius };

        public FigureType CurrentFigureType => FigureType.Circle;

        public List<FigureParameter> FigureParameters;

        public Circle(List<FigureParameter> parameters) : base(parameters, acceptebleParameterTypes)
        {
        }

        public bool IsTheFigureValid()
        {
            return Parameters.Count == 1 && Parameters.All(e => e.Type == acceptebleParameterTypes.First());
        }

        public List<FigureParameter> GetParameters()
        {
            return Parameters;
        }
    }
}
