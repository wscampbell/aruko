using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPSPolygon
{
    private List<GPSPoint> points = new List<GPSPoint>();

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

    // based on cross product
    public int orientation(GPSPoint p, GPSPoint q, GPSPoint r)
    {
        double val = (q.y - p.y) * (r.x - q.x) - (q.x - p.x) * (r.y - q.y);
        if (val == 0) return 0; // colinear 
        return (val > 0) ? 1 : -1; // clock or counterclock wise 
    }
}
