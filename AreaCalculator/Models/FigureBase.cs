using AreaCalculator.Enums;

namespace AreaCalculator.Models
{
    internal abstract class FigureBase
    {
        protected List<FigureParameter> Parameters;
        private List<FigureParameter> acceptebleParameterTypes;

        protected List<ParameterType> AcceptebleParameterTypes { get; set; }

        protected FigureBase(List<FigureParameter> parameters)
        {
            Parameters = parameters;
            ParametersAreValid();
        }

        protected FigureBase(List<FigureParameter> parameters, List<ParameterType> acceptebleParameterTypes)
        {
            Parameters = parameters;
            AcceptebleParameterTypes = acceptebleParameterTypes;
            ParametersAreValid();
        }


        protected virtual bool ParametersAreValid()
        {
            return Parameters.All(e => AcceptebleParameterTypes.Contains(e.Type));
        }
    }
}
