using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.direction = Slider.Direction.LeftToRight;
        slider.minValue = 0;
        slider.maxValue = 1;
    }

    public void ChangeAudioTime()
    {
       audioSource.time = audioSource.clip.length * slider.value; 
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = audioSource.time / audioSource.clip.length;
    }
}
