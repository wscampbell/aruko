using System;

public class GPSBubble : IRegion
{
    GPSPoint center;
    // in degrees. Default = 0.0001, which is about 10 meters in Japan
    private double radius;

    public GPSBubble(GPSPoint center, double radius = 0.0001)
    {
        this.center = center;
        this.radius = radius;
    }

    public bool encompasses(GPSPoint point)
    {
        return Math.Pow(radius, 2) > Math.Pow(center.x - point.x, 2) + Math.Pow(center.y - point.y, 2);
    }

    public override string ToString()
    {
        return "Coordinate: lat=" + center.x + ", lon=" + center.y;
    }
}