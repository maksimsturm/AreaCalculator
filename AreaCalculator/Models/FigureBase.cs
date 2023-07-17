using AreaCalculator.Enums;
using AreaCalculator.Servicies;
using Microsoft.Extensions.DependencyInjection;

namespace AreaCalculator.Models
{
    public abstract class FigureBase
    {
        protected List<FigureParameter> Parameters;

        protected FigureType FigureType;

        protected List<ParameterType> AcceptebleParameterTypes { get; set; }

        protected FigureBase(List<FigureParameter> parameters, List<ParameterType> acceptebleParameterTypes)
        {
            Parameters = parameters;
            AcceptebleParameterTypes = acceptebleParameterTypes;
        }
    }
}
