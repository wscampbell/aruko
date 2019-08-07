using System.Collections.Generic;

public class GPSPolygon : IRegion
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

    public bool encompasses(GPSPoint point)
    {
        return countIntersections(point) % 2 == 1;
    }

    // visible for testing
    public int countIntersections(GPSPoint point)
    {
        int intersections = 0;
        // TODO make these large numbers constants, or just outside 
        GPSPoint p1 = new GPSPoint(999999, 999999);
        GPSPoint q1 = point;
        for (int i = 0; i < points.Count; i++)
        {
            GPSPoint p2 = points[i];
            GPSPoint q2;
            if (i == points.Count - 1)
            {
                q2 = points[0]; // wrap around at the end
            }
            else
            {
                q2 = points[i + 1];
            }
            if (GeometryHelper.intersect(p1, q1, p2, q2))
            {
                intersections++;
            }
        }
        return intersections;
    }
}
