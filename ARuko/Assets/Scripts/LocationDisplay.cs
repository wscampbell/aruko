using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationDisplay : MonoBehaviour
{
    public void setLocation(string location)
    {
        this.GetComponentInChildren<Text>().text = "Location:\n" + location;
    }
}
