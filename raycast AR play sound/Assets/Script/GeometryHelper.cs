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

    private static double min(double num1, double num2)
    {
        return num1 < num2 ? num1 : num2;
    }

    private static double max(double num1, double num2)
    {
        return num1 < num2 ? num2 : num1;
    }

    // checks if q is on line segment pr
    public static bool onSegment(GPSPoint p, GPSPoint q, GPSPoint r)
    {
        return q.x <= max(p.x, r.x) && q.x >= min(p.x, r.x) && q.y <= max(p.y, r.y) && q.y >= min(p.y, r.y);
    }
}
