using System.Collections.Generic;

public class GPSPolygon
{
    public List<GPSPoint> points { get; } = new List<GPSPoint>();

    public GPSPolygon(List<GPSPoint> points)
    {
        this.points = points;
    }

    public void clear()
    {
        points.Clear();
    }

    public void addPoint(GPSPoint point)
    {
        points.Add(point);
    }
}
