using AreaCalculator.Enums;
using AreaCalculator.Models;
using AreaCalculator.Models.Figure.Figures;
using System;
using System.Collections.Generic;

namespace Tests.Servicies
{
    public static class TestDataService
    {
        public static List<FigureParameter> GetValidFigureParameters(FigureType figureType)
        {
            if (figureType == FigureType.Circle)
            {
                return new List<FigureParameter>() { new FigureParameter(ParameterType.Radius, new Random().Next(10, 100)) };
            }

            if (figureType == FigureType.Triangle)
            {
                var parameters = new List<FigureParameter>();
                while (!new Triangle(parameters).IsTheFigureValid())
                {
                    parameters = new List<FigureParameter>()
                    {
                        new FigureParameter(ParameterType.Side, new Random().Next(10, 200)),
                        new FigureParameter(ParameterType.Side, new Random().Next(10, 200)),
                        new FigureParameter(ParameterType.Side, new Random().Next(10, 200))
                    };
                }

                return parameters;
            }

            return new List<FigureParameter>();
        }
    }
}
