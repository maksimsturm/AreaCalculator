using AreaCalculator.Enums;

namespace AreaCalculator.Models
{
    public abstract class FigureBase
    {
        protected List<FigureParameter> Parameters;

        protected List<ParameterType> AcceptebleParameterTypes { get; set; }

        protected FigureBase(List<FigureParameter>? parameters = null)
        {
            Parameters = parameters;
        }

        protected FigureBase(List<FigureParameter> parameters, List<ParameterType> acceptebleParameterTypes)
        {
            Parameters = parameters;
            AcceptebleParameterTypes = acceptebleParameterTypes;
        }
    }
}
