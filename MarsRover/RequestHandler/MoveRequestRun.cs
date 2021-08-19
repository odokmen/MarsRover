using MarsRover.Abstract;
using MarsRover.Enum;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MarsRover.RequestHandler
{
    public class MoveRequestRun : RequestRun
    {
        public override RequestType RequestType => RequestType.Move;
        private readonly IRoverManager _roverManager;
        public MoveRequestRun(IServiceProvider serviceProvider) => _roverManager = serviceProvider.GetService<IRoverManager>();
        public override void Run(string request)
        {
            var validate = ValidateRequest(request);
            if (!validate.isValid)
            {
                throw new Exception(validate.message);
            }

            var rover = _roverManager.Rovers.SingleOrDefault(x => x.IsActive);
            if (rover != null)
            {
                foreach (var req in request)
                {
                    var movement = System.Enum.Parse<Movement>(req.ToString());
                    rover?.Move(movement);
                }
                rover.IsActive = false;

                Console.WriteLine("Expected Output :");
                Console.WriteLine($"{rover.X} {rover.Y} {rover.Direction.ToString()}");
                Console.WriteLine("--------------------------------------------------");
            }
        }
    }
}
