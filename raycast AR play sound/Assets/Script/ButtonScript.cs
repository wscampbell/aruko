using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public void SetText(string text)
    {
        transform.Find("Text").GetComponent<Text>().text = text;
    }
}
