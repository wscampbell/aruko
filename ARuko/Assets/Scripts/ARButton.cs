using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ARButton : MonoBehaviour
{
    private bool AREnabled = false;
    public GameObject GroundPlane;
    public PlaneFinderBehaviour PlaneFinder;

    // allows you to toggle ground plane AR
    public void ToggleAR()
    {
        if (AREnabled)
        {
            GroundPlane.SetActive(false);
            AREnabled = false;
        }
        else
        {
            GroundPlane.SetActive(true);
            AREnabled = true;
            // TODO: check if we need this line, it might not be doing anything
            PlaneFinder.PerformHitTest(new Vector2(Screen.width / 2,Screen.height / 2));
        }
    }
}
