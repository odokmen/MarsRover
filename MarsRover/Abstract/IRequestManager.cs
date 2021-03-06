using MarsRover.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Abstract
{
    public interface IRequestManager
    {
        void Request(string request, RequestType requestType);
    }
}
