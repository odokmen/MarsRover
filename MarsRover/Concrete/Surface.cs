using MarsRover.Abstract;

namespace MarsRover.Concrete
{
    public class Surface : IPlanetSurface
    {
        public SurfaceSize Size { get; private set; }
        public void SetSize(int width, int height) => Size = new SurfaceSize(width, height);
 
    }
}
