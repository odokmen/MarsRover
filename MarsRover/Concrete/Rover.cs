using MarsRover.Abstract;
using MarsRover.Enum;
using System;

namespace MarsRover.Concrete
{
    public class Rover : IPosition
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public bool IsActive { get; set; } = true;
        public Directions Direction { get; private set; }      
        public IPlanetSurface PlanetSurface { get; }
        public Rover(int x, int y, Directions direction, IPlanetSurface  planetSurface)
        {
            X = x;
            Y = y;
            Direction = direction;
            PlanetSurface = planetSurface;
        }
        public void Move(Movement movement)
        {
            switch (movement)
            {
                case Movement.L:                 
                case Movement.R:
                    switch (this.Direction)
                    {
                        case Directions.N:
                            this.Direction = movement == Movement.L ?  Directions.W : Directions.E;
                            break;
                        case Directions.S:
                            this.Direction = movement == Movement.L ?  Directions.E : Directions.W;
                            break;
                        case Directions.E:
                            this.Direction = movement == Movement.L ? Directions.N : Directions.S;
                            break;
                        case Directions.W:
                            this.Direction = movement == Movement.L ? Directions.S : Directions.N;
                            break;
                        default:
                            Console.WriteLine($"Invalid Character {this.Direction}");
                            break;
                    }
                    break;
                case Movement.M:
                    switch (this.Direction)
                    {
                        case Directions.N:
                            this.Y += 1;
                            break;
                        case Directions.S:
                            this.Y -= 1;
                            break;
                        case Directions.E:
                            this.X += 1;
                            break;
                        case Directions.W:
                            this.X -= 1;
                            break;
                        default:
                            Console.WriteLine($"Invalid Character {this.Direction}");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine($"Invalid Character {movement}");
                    break;
            }
        }       

       
    }
}
