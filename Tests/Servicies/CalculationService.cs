using AreaCalculator.Enums;
using AreaCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests.Servicies
{
    public class CalculationService
    {
        public double? CalculateArea(FigureType figureType, List<FigureParameter> parameters)
        {
            switch (figureType)
            {
                case FigureType.Circle:
                    var radius = parameters.First().Value;
                    return Math.Pow(radius, 2) * Math.PI;
                case FigureType.Triangle:
                    var sides = parameters.Select(e => Convert.ToDouble(e.Value)).ToList();
                    var halfOfPerimeter = sides.Sum() / 2;
                    var product = 1D;
                    for (var i = 0; i < sides.Count; i++)
                    {
                        product *= halfOfPerimeter - sides[i];
                    }
                    return Math.Sqrt(halfOfPerimeter * product);
            }

            return null;
        }
    }
}
