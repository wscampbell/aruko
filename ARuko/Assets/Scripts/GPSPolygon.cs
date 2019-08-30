﻿using UnityEngine;
using System.Collections.Generic;
using System.Text;

public class GPSPolygon : IRegion
{
    public List<GPSPoint> points { get; } = new List<GPSPoint>();

    public List<string> imageNames { get; } = new List<string>();

    public string name { get; set; }

    public GPSPolygon(List<GPSPoint> points, string name = "unnamed polygon")
    {
        this.points = points;
        this.name = name;
    }

    public GPSPolygon(List<GPSPoint> points, List<string> imageNames, string name)
    {
        this.points = points;
        this.name = name;
        this.imageNames = imageNames;
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
        GPSPoint p1 = new GPSPoint(1000, 1000);
        GPSPoint q1 = point;

        for (int i = 0; i < points.Count; i++)
        {
            GPSPoint p2 = points[i];
            GPSPoint q2;
            GPSPoint p0;

            // next point
            if (i == points.Count - 1)
            {
                q2 = points[0]; // wrap around at the end
            }
            else
            {
                q2 = points[i + 1];
            }

            // prev point
            if (i == 0)
            {
                p0 = points[points.Count - 1];
            }
            else
            {
                p0 = points[i - 1];
            }

            // count intersection if line is intersecting
            if (GeometryHelper.intersect(p1, q1, p2, q2))
            {
                intersections++;
                // deals with raycast passing over exact vertex problem
                if (GeometryHelper.orientation(q1, p2, p1) == 0)
                {
                    Debug.Log("intersection: " + q1.ToString() + p2.ToString() + p1.ToString());
                    int o1 = (GeometryHelper.orientation(p0, p2, q1));
                    int o2 = (GeometryHelper.orientation(q1, p2, q2));
                    if (o1 == o2)
                    {
                        intersections++;
                    }
                }
            }

        }
        return intersections;
    }

    public override string ToString()
    {
        // TODO get rid of this
        StringBuilder stringBuilder = new StringBuilder(name + "[");
        foreach (GPSPoint point in points)
        {
            stringBuilder.Append(point.ToString() + ",");
        }
        stringBuilder.Append("]");
        Debug.Log(stringBuilder.ToString());
        return stringBuilder.ToString();
    }
}
