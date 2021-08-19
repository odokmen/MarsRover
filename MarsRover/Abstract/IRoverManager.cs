using MarsRover.Concrete;
using MarsRover.Enum;
using System.Collections.Generic;

namespace MarsRover.Abstract
{
    public interface IRoverManager
    {
        List<Rover> Rovers { get; }        
        IPlanetSurface  PlanetSurface { get; }
        void SetPosition(int x, int y, Directions direction);
    }
}
