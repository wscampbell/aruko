using UnityEngine;

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
}
