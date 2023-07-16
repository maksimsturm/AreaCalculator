using AreaCalculator.Enums;

namespace AreaCalculator.Models.Figure.Figures
{
    internal class Triangle : FigureBase, IFigure
    {
        private static List<ParameterType> acceptebleParameterTypes => new List<ParameterType> { ParameterType.Side };

        private List<double> Sides => Parameters.Select(e => Convert.ToDouble(e.Value)).ToList();

        public FigureType CurrentFigureType => FigureType.Triangle;

        public Triangle(List<FigureParameter> parameters) : base(parameters, acceptebleParameterTypes)
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

        protected override bool ParametersAreValid()
        {
            return Parameters.Count == 3 && Parameters.All(e => e.Type == acceptebleParameterTypes.First());
        }

        public bool IsItRightTriangle()
        {
            for (var i = 0; i < Sides.Count; i++)
            {
                var currentSide = Sides[i];
                var otherSides = Sides.Where((v, j) => j != i).ToList();
                if (Math.Pow(currentSide, 2) == Math.Pow(otherSides.First(), 2) + Math.Pow(otherSides.Last(), 2))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
