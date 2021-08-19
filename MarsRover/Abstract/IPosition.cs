using MarsRover.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Abstract
{
    public interface IPosition
    {
        int X { get; }

        int Y { get; }

        IPlanetSurface PlanetSurface { get; }

        Directions Direction { get; }

        void Move(Movement movement);
    }
}
