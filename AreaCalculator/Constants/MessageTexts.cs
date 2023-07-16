using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculator.Constants
{
    public static class MessageTexts
    {
        public const string DeterminedFigureType = "You have entered parameters for: {0}";

        public const string SuccesfullCalculatedArea = "Area of {0} equal: {1}";

        public const string AreaCalculationIsNotImplemented = "Area calclulation for {0} figure type is not implemented yet.";

        public const string CanNotCalculateAreaByEmptyPrameters = "Can not calclulate area by empty parameters";

        public const string CanNotDetermineFigureType = "Can not determine figure type by inserted parameters.";
    }
}
