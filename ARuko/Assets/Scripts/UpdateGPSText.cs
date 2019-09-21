using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

// TODO get rid of this whole class
public class UpdateGPSText : MonoBehaviour
{
    public Text coordinates;
    public Text timesUpdatedText;
    public Text regionText;
    public int timesUpdated = 0;
    private int stepsSinceUpdate = 0;
    private const int maxStep = 60;

    private void Start()
    {
        // TODO find a better place for this
        //JSONHelper.addTourToRegion("ritsu-tour");
    }

    private void Update()
    {
        setBottomText();
        setRegionText();
    }

    // TODO get rid of this
    private void setBottomText()
    {
        stepsSinceUpdate++;
        if (stepsSinceUpdate >= maxStep)
        {
            stepsSinceUpdate = 0;
            timesUpdated++; // TODO get rid of this
            GPS.instance.UpdatePosition();
        }

        coordinates.text = "Lat: " + GPS.instance.latitude.ToString() + " Lon: " + GPS.instance.longitude.ToString();
        timesUpdatedText.text = "times updated: " + timesUpdated.ToString();
    }

    // this is to tell what region you are in for testing (will get rid of this)
    private void setRegionText()
    {
        if (stepsSinceUpdate == 0) // this means the GPS coordinates were just updated
        {
            GPSPoint point = new GPSPoint(GPS.instance.latitude, GPS.instance.longitude);
            List<IRegion> regions = Regions.enclosingRegions(point);
            StringBuilder stringBuilder = new StringBuilder("Regions:\n");
            foreach (IRegion region in regions)
            {
                stringBuilder.Append(region.name + "\n");
            }
            // TODO get rid of this code; was only for testing
            stringBuilder.Append("End of region list\n");
            stringBuilder.AppendLine(timesUpdated.ToString());
            stringBuilder.AppendLine(Regions.length().ToString());
            stringBuilder.AppendLine(point.ToString());
            regionText.text = stringBuilder.ToString();
        }
    }
}
