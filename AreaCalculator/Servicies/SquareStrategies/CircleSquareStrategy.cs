using AreaCalculator.Enums;
using AreaCalculator.Models;
using AreaCalculator.Models.Figure.Figures;
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

        public double Calculate(IFigure figure)
        {
            var radius = figure.GetParameters().First().Value;
            return Math.Pow(radius, 2) * Math.PI;
        }

        public IFigure GetFigure(List<FigureParameter> parameters)
        {
            return new Circle(parameters);
        }
    }
}
