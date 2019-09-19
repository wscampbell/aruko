using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeSwap : MonoBehaviour
{
    // for toggling AR mode
    private Camera arCam;

    void Start()
    {
        arCam = Camera.main;
        arCam.enabled = false;
    }

    // swaps between modes other than AR mode, takes string of Tag of new mode
    public void SwapMode(string newMode)
    {
        // disable the AR Camera so it's not searching in the background
        arCam.enabled = false;

        // disable child modes, if it's the desired mode, enable it
        for (int i = 0; i < this.transform.childCount; i++)
        {
            Transform child = this.transform.GetChild(i);
            if (child.gameObject.tag == newMode)
            {
                child.gameObject.SetActive(true);
            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    // for swapping to AR Mode
    public void ARMode()
    {
        // disable other modes
        for (int i = 0; i < this.transform.childCount; i++)
        {
            Transform child = this.transform.GetChild(i);
            child.gameObject.SetActive(false);
        }

        // turn on camera
        arCam.enabled = true;
    }
}
