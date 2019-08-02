using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGPSText : MonoBehaviour
{
    public Text coordinates;
    public Text timesUpdatedText;
    public Text timesStartedText;
    public int timesUpdated = 0;

    private int stepsSinceUpdate = 0;

    private const int maxStep = 60;

    private void Update()
    {
        timesUpdated++; // TODO get rid of this
        stepsSinceUpdate++;
        if (stepsSinceUpdate >= maxStep)
        {
            stepsSinceUpdate = 0;
            GPS.instance.UpdatePosition();
        }
        coordinates.text = "Lat: " + GPS.instance.latitude.ToString() + " Lon: " + GPS.instance.longitude.ToString();
        timesUpdatedText.text = "times updated: " + timesUpdated.ToString();
        timesStartedText.text = "times started: " + GPS.instance.timesStarted.ToString();
    }
}
