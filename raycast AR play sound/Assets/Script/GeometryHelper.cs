using System.Collections.Generic;

public class GeometryHelper
{
    // based on cross product
    public static int orientation(GPSPoint p, GPSPoint q, GPSPoint r)
    {
        double val = (q.y - p.y) * (r.x - q.x) - (q.x - p.x) * (r.y - q.y);
        if (val == 0) return 0; // colinear 
        return (val > 0) ? 1 : -1; // clockwise or counterclockwise 
    }

    public static bool intersect(GPSPoint p1, GPSPoint q1, GPSPoint p2, GPSPoint q2)
    {
        int o1 = orientation(p1, q1, p2);
        int o2 = orientation(p1, q1, q2);
        int o3 = orientation(p2, q2, p1);
        int o4 = orientation(p2, q2, q1);

        // don't need to worry about colinear
        return o1 != o2 && o3 != o4;
    }

    public static bool inside(GPSPolygon polygon, GPSPoint point)
    {
        return countIntersections(polygon, point) % 2 == 1;
    }

    public static int countIntersections(GPSPolygon polygon, GPSPoint point)
    {
        int intersections = 0;
        // TODO make these large numbers constants, or just outside 
        GPSPoint p1 = new GPSPoint(999999, 999999);
        GPSPoint q1 = point;
        for (int i = 0; i < polygon.points.Count; i++)
        {
            GPSPoint p2 = polygon.points[i];
            GPSPoint q2;
            if (i == polygon.points.Count - 1)
            {
                q2 = polygon.points[0]; // wrap around at the end
            }
            else
            {
                q2 = polygon.points[i + 1];
            }
            if (intersect(p1, q1, p2, q2))
            {
                intersections++;
            }
        }
        return intersections;
    }
}
