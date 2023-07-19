using AreaCalculator.Enums;

namespace AreaCalculator.Models.Figure.Figures
{
    public class Triangle : FigureBase, IFigure
    {
        private static List<ParameterType> acceptebleParameterTypes => new List<ParameterType> { ParameterType.Side };

        private List<double> Sides => Parameters.Select(e => Convert.ToDouble(e.Value)).ToList();

        public FigureType CurrentFigureType => FigureType.Triangle;

        public Triangle(List<FigureParameter> parameters) : base(parameters, acceptebleParameterTypes)
        {
            FigureType = FigureType.Triangle;
        }

        public bool isThisTraingleRectangular()
        {
            foreach (var side in Sides)
            {
                var otherSides = Sides.Where(e => e != side);
                if (Math.Sqrt(side) == Math.Sqrt(otherSides.First()) + Math.Sqrt(otherSides.Last()))
                {
                    return true;                    
                }
            }

            return false;
        }

        public bool IsTheFigureValid()
        {
            if (Parameters == null || !Parameters.Any())
            {
                return false;
            }

            if (Parameters.Count != 3 && !Parameters.All(e => e.Type == acceptebleParameterTypes.First()))
            {
                return false;
            }

            var longSide = Sides.OrderByDescending(e => e).First();
            return Sides.Where(e => e != longSide).Sum() > longSide;
        }

        public List<FigureParameter> GetParameters() => Parameters;
    }
}
