using UnityEngine;
using UnityEngine.UI;

public class UpdateGPSText : MonoBehaviour
{
    public Text coordinates;
    public Text timesUpdatedText;
    public int timesUpdated = 0;
    private int stepsSinceUpdate = 0;
    private const int maxStep = 60;

    private void Update()
    {
        string success = "";

        stepsSinceUpdate++;
        if (stepsSinceUpdate >= maxStep)
        {
            stepsSinceUpdate = 0;
            timesUpdated++; // TODO get rid of this
            GPS.instance.UpdatePosition();
        }

        // TODO get rid of this
        if (new Coordinate(34.979493, 135.964419).checkWithin(GPS.instance.latitude, GPS.instance.longitude))
        {
            success = "You are here.";
        }
        coordinates.text = "Lat: " + GPS.instance.latitude.ToString() + " Lon: " + GPS.instance.longitude.ToString();
        timesUpdatedText.text = "times updated: " + timesUpdated.ToString() + success;
    }
}
