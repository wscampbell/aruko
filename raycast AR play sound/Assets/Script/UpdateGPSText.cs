using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

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
        // load the regions from JSON

        // this commented out code added the regions to test
        /*
        Regions.add(new GPSBubble(new GPSPoint(0, 0)));
        Regions.add(new GPSPolygon(new List<GPSPoint>{
            new GPSPoint(33.799925, 127.361071),
            new GPSPoint(46.678526, 139.980040),
            new GPSPoint(42.821432, 151.449732),
            new GPSPoint(27.702284, 131.320996)
        }, "Japan"));
        Regions.add(new GPSPolygon(new List<GPSPoint>{
            new GPSPoint(34.979222, 135.963628),
            new GPSPoint(34.979187, 135.965130),
            new GPSPoint(34.979794, 135.965053),
            new GPSPoint(34.979754, 135.963669)
        }, "Creation Core"));
        */
    }

    private void Update()
    {
        setBottomText();
        setRegionText();
    }

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
