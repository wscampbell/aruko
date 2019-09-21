using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateDropdown : MonoBehaviour
{
    [SerializeField] GameObject audioSlider;
    [SerializeField] Text regionName;
    [SerializeField] Image homeImage;
    private int stepsSinceUpdate = 0;
    private const int maxStep = 60;
    private string regionNameText = "";

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

    public void setToRegionName()
    {
        regionName.text = regionNameText;
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
                canvas.GetComponent<AudioSource>().clip = ((GPSPolygon)regions[0]).audioClip;

                int activeImageCount = 0;

                GameObject firstImage = null;

                foreach (KeyValuePair<string, GameObject> item in GenerateUI.imageMap)
                {
                    Debug.Log(item.Key);
                    if (names.Contains(item.Key))
                    {
                        item.Value.SetActive(true);
                        activeImageCount++;
                        if (firstImage == null)
                        {
                            firstImage = item.Value;
                        }
                    }
                    else
                    {
                        item.Value.SetActive(false);
                    }
                }

                // if the region has changed
                if (regions[0] != previousRegion)
                {
                    regionNameText = regions[0].name;
                    setToRegionName();
                    audioSlider.GetComponent<AudioSlider>().GoToBeginning();
                    canvas.GetComponentInChildren<AudioButton>().SwapButtons();
                    previousRegion = regions[0];
                    // TODO actually test this
                    this.GetComponent<ImageGallery>().imageCount = 0;
                    this.GetComponent<ImageGallery>().activeImageCount = activeImageCount;
                    canvas.GetComponentInChildren<Dropdown>().SetOpen();
                    homeImage.sprite = firstImage.GetComponent<Image>().sprite;
                }
            }
            else
            {
                regionName.text = "you're nowhere";
                foreach (KeyValuePair<string, GameObject> item in GenerateUI.imageMap)
                {
                    item.Value.SetActive(false);
                    previousRegion = null;
                }
            }
        }
    }
}
