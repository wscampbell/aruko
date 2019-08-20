using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ARButton : MonoBehaviour
{
    private bool AREnabled = true;
    public GameObject GroundPlane;

    void OnGUI() 
    {
        GUIStyle fontSize = new GUIStyle(GUI.skin.GetStyle("button"));
        fontSize.fontSize = 48;

        if (AREnabled)
        {
            if (GUI.Button (new Rect(700,50,480,160), "Disable AR", fontSize)) 
            {
                GroundPlane.SetActive(false);
                AREnabled = false;
            }
        }
        else
        {
            if (GUI.Button (new Rect(700,50,480,160), "Enable AR", fontSize))
            {
                GroundPlane.SetActive(true);
                AREnabled = true;
            }
        }
        
    }
}
