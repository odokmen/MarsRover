using MarsRover.Abstract;
using MarsRover.Concrete;
using MarsRover.Enum;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Xunit;

namespace MarsRover.Test
{
    public class RoverTest
    {

        [Theory]
        [InlineData(new object[] { "5 5", "1 2 N", "LMLMLMLMM", "1 3 N" })]
        [InlineData(new object[] { "5 5", "3 3 E", "MMRMMRMRRM", "5 1 E" })]

        [InlineData(new object[] { "1 1", "3 3 E", "MMRMMRMRRM", "5 1 E" })]

        [InlineData(new object[] { "5 A", "1 2 N", "LMLMLMLMM", "1 3 N" })]
        [InlineData(new object[] { "5 5", "3 3 X", "MMRMMRMRRM", "5 1 E" })]
        [InlineData(new object[] { "5 5", "3 3 E", "XX", "5 1 E" })]
        public void GenerateRoverRequest(string reqSize, string reqPosition, string reqMove, string expectedOutput)
        {

            var collection = new ServiceCollection().AddSingleton<IPlanetSurface, Surface>()
                .AddSingleton<IRoverManager, RoverManager>()
                .BuildServiceProvider();

            var req = new RequestManager(collection);            
            req.Request(reqSize, RequestType.Size);
            req.Request(reqPosition, RequestType.Position);
            
            var rover = collection.GetService<IRoverManager>();
            req.Request(reqMove, RequestType.Move);

            var actualOutput = $"{rover.Rovers.Single().X} {rover.Rovers.Single().Y} {rover.Rovers.Single().Direction.ToString()}";

            Assert.NotNull(rover);
            Assert.Equal(expectedOutput, actualOutput);
        }        
    }
}
