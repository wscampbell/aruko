using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateDropdown : MonoBehaviour
{
    [SerializeField] GameObject audioSlider;
    [SerializeField] Text regionName;
    [SerializeField] Image homeImage;
    [SerializeField] Text transcriptText;
    [SerializeField] Text numberText;
    private int stepsSinceUpdate = 0;
    private const int maxStep = 60;
    private string regionNameText = "";

    public GameObject canvas;

    IRegion previousRegion = null;
    public static IRegion chapterRegion = null;

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

        // TODO update immediately if chapter region is selected
        if (stepsSinceUpdate == 0 || chapterRegion != null) // this means the GPS coordinates were just updated
        {
            GPSPoint point = new GPSPoint(GPS.instance.latitude, GPS.instance.longitude);
            List<IRegion> regions = Regions.enclosingRegions(point);

            IRegion switchRegion = null;
            if (chapterRegion != null)
            {
                switchRegion = chapterRegion;
                Debug.Log("CHAPTER REGION SET: " + chapterRegion.name);
            }
            else if (regions.Count != 0)
            {
                switchRegion = regions[0];
            }

            if (switchRegion != null)
            {
                // TODO get rid of this cast
                List<string> names = ((GPSPolygon)switchRegion).imageNames;
                int activeImageCount = 0;

                GameObject firstImage = null;

                // if the region has changed
                if (chapterRegion != null || (regions[0] != previousRegion))
                {
                    // switch the audio source
                    canvas.GetComponent<AudioSource>().clip = ((GPSPolygon)switchRegion).audioClip;

                    // keep images around
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

                    regionNameText = switchRegion.name;
                    setToRegionName();
                    audioSlider.GetComponent<AudioSlider>().GoToBeginning();
                    //canvas.GetComponentInChildren<AudioButton>().SwapButtons();
                    canvas.GetComponentInChildren<AudioButton>().PlayAudio();
                    if (chapterRegion == null)
                    {
                        previousRegion = regions[0];
                    }
                    // TODO actually test this
                    this.GetComponent<ImageGallery>().imageCount = 0;
                    this.GetComponent<ImageGallery>().activeImageCount = activeImageCount;
                    canvas.GetComponentInChildren<Dropdown>().SetOpen();
                    homeImage.sprite = firstImage.GetComponent<Image>().sprite;
                    transcriptText.text = "\n" + ((GPSPolygon)switchRegion).transcript + "\n";
                    numberText.text = ((GPSPolygon)switchRegion).index.ToString() + "/" + Regions.length().ToString();
                }
                chapterRegion = null;
            }
            else
            {
                regionName.text = "you're nowhere";
                /*
                foreach (KeyValuePair<string, GameObject> item in GenerateUI.imageMap)
                {
                    item.Value.SetActive(false);
                    previousRegion = null;
                }
                */
                //previousRegion = null;
            }
        }
    }
}
