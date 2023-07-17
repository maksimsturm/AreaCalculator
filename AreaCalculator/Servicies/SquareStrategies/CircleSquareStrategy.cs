using AreaCalculator.Enums;
using AreaCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculator.Servicies
{
    public class CircleSquareStrategy : ISquareStrategy
    {
        public FigureType FigureType => FigureType.Circle;

        public double Calculate(List<FigureParameter> parameters)
        {
            var radius = parameters.First().Value;
            return Math.Pow(radius, 2) * Math.PI;
        }

        public double Calculate()
        {
            throw new NotImplementedException();
        }
    }
}
