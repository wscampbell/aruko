using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PocketScript : MonoBehaviour
{
    [SerializeField] GameObject pocketPanel;
    [SerializeField] Slider slider;
    private bool lerpBack = true;
    // Start is called before the first frame update
    void Start()
    {
        slider.minValue = 0;
        slider.maxValue = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value > 0.95)
        {
            slider.value = 0;
            pocketPanel.SetActive(false);
        }
        if (lerpBack)
        {
            slider.value = Mathf.Lerp(slider.value, 0, Time.deltaTime * 12);
        }
    }

    public void beginDrag()
    {
        Debug.Log("begun drag");
        lerpBack = false;
    }

    public void endDrag()
    {
        Debug.Log("ended drag");
        lerpBack = true;
    }

    public void activate()
    {
        pocketPanel.SetActive(true);
    }
}