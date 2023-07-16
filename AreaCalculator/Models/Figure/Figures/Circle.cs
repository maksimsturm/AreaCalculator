﻿using AreaCalculator.Enums;

namespace AreaCalculator.Models.Figure.Figures
{
    public class Circle : FigureBase, IFigure
    {
        private static List<ParameterType> acceptebleParameterTypes => new List<ParameterType> { ParameterType.Radius };

        FigureType IFigure.CurrentFigureType => FigureType.Circle;

        public Circle(List<FigureParameter> parameters) : base(parameters, acceptebleParameterTypes)
        {
        }

        public Circle()
        { 
        }

        public double CalculateArea()
        {
            var radius = Convert.ToDouble(Parameters.First().Value);
            return Math.Pow(radius, 2) * Math.PI;
        }

        protected override bool ParametersAreValid()
        {
            return Parameters.Count == 1 && Parameters.All(e => e.Type == acceptebleParameterTypes.First());
        }
    }
}
