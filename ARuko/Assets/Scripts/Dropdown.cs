using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dropdown : MonoBehaviour
{
    public RectTransform container; 
    [SerializeField] Text menuname;
    private string temp;
    public bool isOpen = false;

    // Update is called once per frame
    void Update()
    {
        Vector3 scale = container.localScale;
        scale.y = Mathf.Lerp(scale.y, isOpen ? 1 : 0, Time.deltaTime * 12);
        container.localScale = scale;
    }

    public void ToggleMenu()
    {
        isOpen = isOpen ? false : true;
    }

    public void SetOpen()
    {
        isOpen = false;
    }

    public void ToggleHeader()
    {
        if (isOpen)
        {
            temp = menuname.text;
        } 

        menuname.text = isOpen ? "CHAPTERS" : temp;
    }
}
