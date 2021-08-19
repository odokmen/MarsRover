using MarsRover.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Abstract
{
    public interface IRequestRun
    {
       RequestType RequestType { get; }
        void Run(string request);
    }
}
