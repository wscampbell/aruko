using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageGallery : MonoBehaviour
{
    [SerializeField] GameObject imageGallery;
    [SerializeField] GameObject Left, Right;
    public int imageCount; // public so it can be set to zero when changing regions
    public int activeImageCount = 0;

    void Start()
    {
        Left.SetActive(false);
        Right.SetActive(true);
        imageCount = 0;
    }

    public void NextButton()
    {
        //if (imageCount + 1 < imageGallery.transform.childCount)
        if (imageCount + 1 < activeImageCount)
        {
            imageCount++;
        }
    }

    public void PrevButton()
    {
        if (imageCount - 1 >= 0)
        {
            imageCount--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = imageGallery.transform.localPosition;
        position.x = Mathf.Lerp(position.x, 0 - (900 * imageCount), Time.deltaTime * 12);
        imageGallery.transform.localPosition = position;

        Right.SetActive(true);
        if (imageCount + 1 == activeImageCount)
        {
            Right.SetActive(false);
        }

        Left.SetActive(true);
        if (imageCount == 0)
        {
            Left.SetActive(false);
        }
    }
}
