using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ARButton : MonoBehaviour
{
    private bool AREnabled = false;
    public GameObject GroundPlane;
    public PlaneFinderBehaviour PlaneFinder;

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
            PlaneFinder.PerformHitTest(new Vector2(Screen.width / 2,Screen.height / 2));
        }
    }
}
