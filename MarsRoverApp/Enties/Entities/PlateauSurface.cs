namespace MarsRoverApp.Enties
{
    public class PlateauSurface : IEntity
    {
        public PlateauSurface(int height, int width)
        {
            this.Height = height;
            this.Width = width;
        }
        public int Height { get; set; }
        public int Width { get; set; }
    }
}