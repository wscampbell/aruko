using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class JSONHelper
{
    public static EditourRegion JSONToEditourRegion(string json)
    {
        return (EditourRegion)JsonUtility.FromJson(json, typeof(EditourRegion));
    }

    public static EditourTour JSONToEditourTour(string json)
    {
        return (EditourTour)JsonUtility.FromJson(json, typeof(EditourTour));
    }

    public static List<GPSPolygon> editourTourToGPSPolygons(string tourFileName)
    {
        StreamReader reader = new StreamReader("Assets/Tours/" + tourFileName + "/metadata.json");
        string tourJSON = reader.ReadToEnd();
        reader.Close();

        return JSONHelper.JSONToEditourTour(tourJSON).regions.Select(eRegion => new GPSPolygon(
           editourCoordsToGPSPoints(eRegion.points),
           eRegion.name)
        ).ToList();
    }

    // visible for testing
    public static List<GPSPoint> editourCoordsToGPSPoints(List<EditourCoordinate> eCoords)
    {
        // TODO make sure lat and lng are passed in in correct order
        return eCoords.Select(eCoord => new GPSPoint(eCoord.lat, eCoord.lng)).ToList();
    }

}
