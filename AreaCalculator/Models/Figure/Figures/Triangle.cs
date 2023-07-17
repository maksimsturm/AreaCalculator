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

        }

        public Triangle()
        { 
        }

        public double CalculateArea()
        {
            var halfOfPerimeter = Sides.Sum() / 2;
            var product = 1D;
            for (var i = 0; i < Sides.Count; i++)
            {
                product *= halfOfPerimeter - Sides[i];
            }
            return Math.Sqrt(halfOfPerimeter * product);
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
            if (Parameters == null)
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
    }
}
