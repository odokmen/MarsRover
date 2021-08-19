using MarsRover.Abstract;
using MarsRover.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Concrete
{
    public class RoverManager : IRoverManager
    {
        public List<Rover> Rovers { get; } = new List<Rover>();        
        public IPlanetSurface PlanetSurface { get; }
        public RoverManager(IPlanetSurface planetSurface) => PlanetSurface = planetSurface;
        public void SetPosition(int x, int y, Directions direction)
        {
            if (!(x >= 0 && x < PlanetSurface.Size.Width && y >= 0 && y < PlanetSurface.Size.Height))
                throw new Exception($"Position outside of bounds ({PlanetSurface.Size.Width - 1} , {PlanetSurface.Size.Height - 1})");
            else
                Rovers.Add(new Rover(x, y, direction, PlanetSurface));
        }
    }
}
