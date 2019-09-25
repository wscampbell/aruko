using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dropdown : MonoBehaviour
{
    public RectTransform container;
    [SerializeField] Text menuname;
    public bool isOpen = false;
    private string temp;

    // Update is called once per frame
    void Update()
    {
        // animate the dropdown to the position it should be in
        Vector3 scale = container.localScale;
        scale.y = Mathf.Lerp(scale.y, isOpen ? 1 : 0, Time.deltaTime * 12);
        container.localScale = scale;
    }

    public void ToggleMenu()
    {
        isOpen = isOpen ? false : true;
    }

    // closes the dropdown menu
    public void SetOpen()
    {
        isOpen = false;
    }

    // opens the dropdown menu
    public void SetOpenTrue()
    {
        isOpen = true;
    }

    // sets the header text to CHAPTERS if the menu is open, or to what it was before if the menu has been closed
    public void ToggleHeader()
    {
        if (isOpen)
        {
            temp = menuname.text;
        }

        menuname.text = isOpen ? "CHAPTERS" : temp;
    }
}
