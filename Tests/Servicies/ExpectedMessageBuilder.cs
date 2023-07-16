using AreaCalculator.Constants;
using AreaCalculator.Enums;

namespace Tests.Servicies
{
    public class ExpectedMessageBuilder
    {
        private FigureType _figureType;

        private double _areaValue;

        public ExpectedMessageBuilder()
        { 
        }

        public ExpectedMessageBuilder ForFigureType(FigureType figureType)
        {
            _figureType = figureType;
            return this;
        }

        public ExpectedMessageBuilder WithAreaValue(double value)
        {
            _areaValue = value;
            return this;
        }

        public string GetSuccessfullCalculationMessage()
        {
            return string.Format(MessageTexts.SuccesfullCalculatedArea, _figureType, _areaValue);
        }

        public string GetAreaCalculationIsNotImplementedMessage()
        {
            return string.Format(MessageTexts.AreaCalculationIsNotImplemented, _figureType);
        }
    }
}
