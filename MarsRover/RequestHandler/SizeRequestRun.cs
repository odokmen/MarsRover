using MarsRover.Abstract;
using MarsRover.Enum;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Text;
using MarsRover.RequestHandler;

namespace MarsRover.Concrete
{
    public class SizeRequestRun : RequestRun
    {
        public override RequestType RequestType => RequestType.Size;
        private readonly IPlanetSurface _surface;
        public SizeRequestRun(IServiceProvider provider) => _surface = provider.GetService<IPlanetSurface>();
        public override void Run(string request)
        {
            var validate = ValidateRequest(request);
            if (!validate.isValid)
            {
                throw new Exception(validate.message);
            }
            var gridSize = request.Split(' ');
            if (int.TryParse(gridSize[0], out int width))
            {
                if (int.TryParse(gridSize[1], out int height))
                {
                    _surface.SetSize(width + 1, height + 1);
                }
            }


        }
    }
}
