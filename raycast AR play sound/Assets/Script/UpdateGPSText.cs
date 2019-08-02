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
        stepsSinceUpdate++;
        if (stepsSinceUpdate >= maxStep)
        {
            stepsSinceUpdate = 0;
            timesUpdated++; // TODO get rid of this
            GPS.instance.UpdatePosition();
        }
        coordinates.text = "lat: " + GPS.instance.latitude.ToString() + " lon: " + GPS.instance.longitude.ToString();
        timesUpdatedText.text = "Times updated: " + timesUpdated.ToString();
    }
}
