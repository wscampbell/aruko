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
        EditourTour eTour = (EditourTour)JsonUtility.FromJson(json, typeof(EditourTour));
        foreach (EditourRegion eRegion in eTour.regions)
        {
            eRegion.images.Sort();
        }
        return eTour;
    }

    public static List<GPSPolygon> editourTourToGPSPolygons(string tourFileName)
    {
        string tourJSON = JSONFromFilename(tourFileName);

        return JSONHelper.JSONToEditourTour(tourJSON).regions.Select(eRegion =>
        {
            // there should only be one audio file so just get the first
            // TODO get rid of the assumption that there has to be at least one audio file
            string audioName = eRegion.audio[0];
            AudioClip audioClip = Resources.Load<AudioClip>("ritsu-tour/" + (audioName.Split('.'))[0]);
            //eRegion.images.Sort();
            return new GPSPolygon(editourCoordsToGPSPoints(eRegion.points), eRegion.images, audioClip, eRegion.name, eRegion.transcript);
        }).ToList();
    }

    public static string JSONFromFilename(string filename)
    {
        return Resources.Load<TextAsset>(filename + "/metadata").text;
    }

    // visible for testing
    public static List<GPSPoint> editourCoordsToGPSPoints(List<EditourCoordinate> eCoords)
    {
        return eCoords.Select(eCoord => new GPSPoint(eCoord.lat, eCoord.lng)).ToList();
    }

    public static void addTourToRegion(string tourFilename)
    {
        List<GPSPolygon> gPolygons = JSONHelper.editourTourToGPSPolygons(tourFilename);
        for (int i = 0; i < gPolygons.Count; i++)
        {
            gPolygons[i].index = i + 1;
        }
        Regions.addAllPolygons(gPolygons);
    }
}
