using MarsRover.Abstract;
using MarsRover.Enum;
using MarsRover.RequestHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MarsRover.Concrete
{
    public class RequestManager : IRequestManager
    {
        private readonly IServiceProvider provider;
        public RequestManager(IServiceProvider provider) => this.provider = provider;
        public void Request(string request, RequestType requestType)
        {
            var req = Assembly.GetExecutingAssembly()
                .DefinedTypes
                .Where(type => type.IsSubclassOf(typeof(RequestRun)) && !type.IsAbstract)
                .Select(x => Activator.CreateInstance(x, this.provider) as RequestRun)
                .ToList();

            var reqRun = req.SingleOrDefault(x => x.RequestType == requestType);
            reqRun?.Run(request);
        }
    }
}
