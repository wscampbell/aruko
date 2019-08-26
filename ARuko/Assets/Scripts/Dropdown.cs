using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dropdown : MonoBehaviour
{
    public RectTransform container; 
    public string menuname;
    public bool isOpen;

    // Update is called once per frame
    void Update()
    {
        Vector3 scale = container.localScale;
        scale.y = Mathf.Lerp(scale.y, isOpen ? 1 : 0, Time.deltaTime * 12);
        container.localScale = scale;
    }

    public void ToggleMenu()
    {
        this.GetComponentInChildren<Text>().text = isOpen ? "►" + menuname : "▼" + menuname;
        isOpen = isOpen ? false : true;
    }
}
