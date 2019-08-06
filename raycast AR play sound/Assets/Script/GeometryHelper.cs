public class GeometryHelper
{
    // based on cross product
    public static int orientation(GPSPoint p, GPSPoint q, GPSPoint r)
    {
        double val = (q.y - p.y) * (r.x - q.x) - (q.x - p.x) * (r.y - q.y);
        if (val == 0) return 0; // colinear 
        return (val > 0) ? 1 : -1; // clock or counterclock wise 
    }
}
