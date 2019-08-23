using System.Collections.Generic;
using System.Linq;

public class Regions
{
    private static List<IRegion> regions = new List<IRegion>();

    public static void add(IRegion region)
    {
        regions.Add(region);
    }

    // We are only going to need GPSPolygon objects (bubbles are kind of defunct)
    public static void addAllPolygons(List<GPSPolygon> multipleRegions)
    {
        foreach (IRegion region in multipleRegions)
        {
            regions.Add(region);
        }
    }

    public static void clear()
    {
        regions.Clear();
    }

    public static int length()
    {
        return regions.Count;
    }

    public static List<IRegion> enclosingRegions(GPSPoint point)
    {
        return regions.Where(region => region.encompasses(point)).ToList();
    }
}
