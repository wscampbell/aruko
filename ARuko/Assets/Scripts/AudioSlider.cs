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
    }

    public void GoToBeginning()
    {
        slider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = audioSource.time / audioSource.clip.length;
        currTime.text = TimeToClocktime(audioSource.time);
        maxTime.text = TimeToClocktime(audioSource.clip.length);
    }

    // turns audio clip time (float of seconds) to string of clock time (format "00:00")
    public string TimeToClocktime(float audioTime)
    {
        string minutes = "0";
        string seconds = "00";
        int timeInt = (int)audioTime;

        // if the audio time is under 60s, simply display it as is
        if (timeInt < 60)
        {
            seconds = timeInt.ToString();
            // add a 0 to the front if it is under 10s so it looks correct in clocktime
            if (timeInt < 10)
            {
                seconds = "0" + seconds;
            }
        }
        // if audio time is more than 60s, need to turn it into mm:ss format
        else
        {
            minutes = (timeInt / 60).ToString();
            seconds = (timeInt % 60).ToString();
            if (timeInt % 60 < 10)
            {
                seconds = "0" + seconds;
            }
        }

        string clocktime = minutes + ":" + seconds;
        return clocktime;
    }
}
