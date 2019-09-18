using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateDropdown : MonoBehaviour
{
    public Text regionName;
    private int stepsSinceUpdate = 0;
    private const int maxStep = 60;

    public AudioSource audioSource;
    public GameObject canvas;

    IRegion previousRegion = null;

    private void Start()
    {
        JSONHelper.addTourToRegion("ritsu-tour");
    }

    private void Update()
    {
        setRegionText();
    }

    // this is to tell what region you are in for testing (will get rid of this)
    private void setRegionText()
    {
        stepsSinceUpdate++;
        if (stepsSinceUpdate >= maxStep)
        {
            stepsSinceUpdate = 0;
            GPS.instance.UpdatePosition();
        }

        if (stepsSinceUpdate == 0) // this means the GPS coordinates were just updated
        {
            GPSPoint point = new GPSPoint(GPS.instance.latitude, GPS.instance.longitude);
            List<IRegion> regions = Regions.enclosingRegions(point);
            if (regions.Count != 0)
            {
                // TODO get rid of this cast
                List<string> names = ((GPSPolygon)regions[0]).imageNames;
                foreach (string image in ((GPSPolygon)regions[0]).imageNames)
                {
                    Debug.Log(image);
                }
                regionName.text = regions[0].name;
                audioSource.clip = ((GPSPolygon)regions[0]).audioClip;

                foreach (KeyValuePair<string, GameObject> item in GenerateUI.buttonMap)
                {
                    if (names.Contains(item.Key))
                    {
                        item.Value.SetActive(true);
                    }
                    else
                    {
                        item.Value.SetActive(false);
                    }
                }

                // play if the region has changed
                // TODO also reset audio slider before playing
                if (regions[0] != previousRegion)
                {
                    canvas.GetComponent<AudioButton>().SwapButtons();
                    previousRegion = regions[0];
                }
            }
            else
            {
                regionName.text = "you're nowhere";
                foreach (KeyValuePair<string, GameObject> item in GenerateUI.buttonMap)
                {
                    item.Value.SetActive(false);
                    previousRegion = null;
                }
            }
        }
    }
}
