using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Abstract
{
    public interface IPlanetSurface
    {
        SurfaceSize Size { get; }

        void SetSize(int width, int height);
    }
}
