using MarsRover.Abstract;
using MarsRover.Enum;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarsRover.RequestHandler
{
    public class PositionRequestRun : RequestRun
    {
        public override RequestType RequestType => RequestType.Position;
        private readonly IRoverManager _roverManager;
        public PositionRequestRun(IServiceProvider serviceProvider) => _roverManager = serviceProvider.GetService<IRoverManager>();
        public override void Run(string request)
        {
            var validate = ValidateRequest(request);
            if (!validate.isValid)
            {
                throw new Exception(validate.message);
            }
            var split = request.Split(' ');
            _roverManager.SetPosition(int.Parse(split[0]), int.Parse(split[1]), System.Enum.Parse<Directions>(split[2].ToUpper()));
        }
    }
}
