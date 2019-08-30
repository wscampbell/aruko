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
        // TODO use JSONFromFilename here
        StreamReader reader = new StreamReader("Assets/Tours/Resources/" + tourFileName + "/metadata.json");
        string tourJSON = reader.ReadToEnd();
        reader.Close();

        return JSONHelper.JSONToEditourTour(tourJSON).regions.Select(eRegion =>
        {
            // there should only be one audio file so just get the first
            string audioName = eRegion.audio[0];
            Debug.Log("audio name: " + audioName);
            AudioClip audioClip = Resources.Load<AudioClip>("ritsu-tour/" + (audioName.Split('.'))[0]);
            return new GPSPolygon(editourCoordsToGPSPoints(eRegion.points), eRegion.images, audioClip, eRegion.name);
        }).ToList();
    }

    public static string JSONFromFilename(string filename)
    {
        StreamReader reader = new StreamReader("Assets/Tours/Resources/" + filename + "/metadata.json");
        string tourJSON = reader.ReadToEnd();
        reader.Close();
        return tourJSON;
    }

    // visible for testing
    public static List<GPSPoint> editourCoordsToGPSPoints(List<EditourCoordinate> eCoords)
    {
        // TODO make sure lat and lng are passed in in correct order
        return eCoords.Select(eCoord => new GPSPoint(eCoord.lat, eCoord.lng)).ToList();
    }

    public static void addTourToRegion(string tourFilename)
    {
        List<GPSPolygon> gPolygons = JSONHelper.editourTourToGPSPolygons(tourFilename);
        Regions.addAllPolygons(gPolygons);
    }

}
