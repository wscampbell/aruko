using System.Collections.Generic;
using System.Linq;

public class Regions
{
    private static List<IRegion> regions = new List<IRegion>();

    public static void add(IRegion region)
    {
        regions.Add(region);
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
