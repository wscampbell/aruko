using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider slider;
    public Text currTime, maxTime;
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
       maxTime.text = TimeToClocktime(audioSource.clip.length);
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = audioSource.time / audioSource.clip.length;
        currTime.text = TimeToClocktime(audioSource.time);
    }

    // turns audio clip time (float of seconds) to string of clock time (format "00:00")
    public string TimeToClocktime(float audioTime)
    {
        string minutes = "0";
        string seconds = "00";

        int timeInt = (int) audioTime;
        if (timeInt < 60)
        {
            seconds = timeInt.ToString();
            if (timeInt < 10)
            {
                seconds = "0" + seconds;
            }
        }
        else
        {
            minutes = (timeInt/60).ToString();
            seconds = (timeInt%60).ToString();
            if (timeInt%60 < 10)
            {
                seconds = "0" + seconds;
            }
        }

        string clocktime = minutes + ":" + seconds;
        return clocktime;
    }
}
