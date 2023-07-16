using AreaCalculator.Enums;

namespace AreaCalculator.Models
{
    public class FigureParameter
    {
        public ParameterType Type { get; set; }

        public double Value { get; set; }

        public FigureParameter(ParameterType type, double value)
        {
            Type = type;
            Value = value;
        }
    }
}
