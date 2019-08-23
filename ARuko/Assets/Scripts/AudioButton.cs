using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioButton : MonoBehaviour
{
    public GameObject Play, Stop, Audio;
    private bool AudioPlaying = false;

    public void SwapButtons(){
        if (AudioPlaying){
            AudioPlaying = false;
            Audio.GetComponent<AudioSource>().Pause();
            Play.SetActive(true);
            Stop.SetActive(false);
        }
        else
        {
            AudioPlaying = true;
            Audio.GetComponent<AudioSource>().Play();
            Play.SetActive(false);
            Stop.SetActive(true);
        }
    }
}
