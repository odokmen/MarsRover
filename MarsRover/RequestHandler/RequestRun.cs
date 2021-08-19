using MarsRover.Abstract;
using MarsRover.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MarsRover.RequestHandler
{
    public abstract class RequestRun : IRequestRun
    {
        public abstract RequestType RequestType { get; }
        public abstract void Run(string request);
        protected virtual (bool isValid, string message) ValidateRequest(string request)
        {
            if (string.IsNullOrWhiteSpace(request))
                return (isValid: false, message: "Request can not be null or empty");

            if (RequestType == RequestType.Size)            
                return (isValid: new Regex("^\\d+ \\d+$").IsMatch(request), message: "Plateau surface size request not valid");
            if (RequestType == RequestType.Position)
                return (isValid: new Regex("^\\d+ \\d+ [NSWE]$").IsMatch(request), message: "Rover position request not valid");
            if (RequestType == RequestType.Move)
                return (isValid: new Regex("^[LMR]+$").IsMatch(request), message: "Rover command request not valid");

            return (isValid: true, message: "");
        }
    }

}

