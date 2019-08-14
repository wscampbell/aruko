using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    private void OnGUI()
    {
        int xCenter = (Screen.width / 2);
        int yCenter = (Screen.height / 2);
        int width = 400;
        int height = 120;

        GUIStyle fontSize = new GUIStyle(GUI.skin.GetStyle("button"));
        fontSize.fontSize = 32;

        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "SampleScene")
        {
            if(GUI.Button(new Rect(xCenter - width / 2, yCenter - height / 2, width, height), "Load Ground Plane Scene", fontSize))
            {
                SceneManager.LoadScene("GroundPlane");
            }
        }
        else
        {
            if(GUI.Button(new Rect(xCenter - width / 2, yCenter - height / 2, width, height), "Load Sample Scene", fontSize))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
