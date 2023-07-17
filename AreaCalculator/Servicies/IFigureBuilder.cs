using AreaCalculator.Enums;
using AreaCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculator.Servicies
{
    public interface IFigureBuilder
    {
        public IFigure? GetFigure(List<FigureParameter> parameters);

        public IFigure? GetFigure(FigureType figureType, List<FigureParameter> parameters);
    }
}
