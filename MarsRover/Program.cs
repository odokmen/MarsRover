using MarsRover.Abstract;
using MarsRover.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = new ServiceCollection().AddSingleton<IPlanetSurface, Surface>().AddSingleton<IRoverManager, RoverManager>().BuildServiceProvider();
            var req = new RequestManager(collection);
            while (true)
            {
                Console.WriteLine("Plateau surface size :");
                var reqSize = Console.ReadLine().Trim();
                req.Request(reqSize, Enum.RequestType.Size);

                Console.WriteLine("Rover position :");
                var reqLocation = Console.ReadLine().Trim();
                req.Request(reqLocation, Enum.RequestType.Position);

                Console.WriteLine("Rover command :");
                var reqMove = Console.ReadLine().Trim();
                req.Request(reqMove, Enum.RequestType.Move);

                Console.WriteLine("Do you want to add another rover ? (Y/N)");
                var addRoverInput = Console.ReadLine();
                if (!addRoverInput.Equals("Y", StringComparison.InvariantCultureIgnoreCase)) { break; }
            }
            Console.Write("Press <enter> to exit...");
            Console.ReadLine();

        }
    }
}
