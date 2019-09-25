using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// for the Play and Pause buttons for our audio
public class AudioButton : MonoBehaviour
{
    public GameObject Play, Stop, Audio;
    public AudioSource audioSource;

    void Start()
    {
        Play.SetActive(true);
        Stop.SetActive(false);
        audioSource = Audio.GetComponent<AudioSource>();
    }

    // called when you press either button. If the music is playing, pause it; if it's not, play it
    public void SwapButtons()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.Play();
        }
    }

    public void PauseAudio()
    {
        audioSource.Pause();
    }

    public void PlayAudio()
    {
        audioSource.Play();
    }

    // ensures the correct button is displayed at all times
    // particularly important for when audio file ends or is swapped on region change
    void Update()
    {
        if (audioSource.isPlaying)
        {
            Stop.SetActive(true);
            Play.SetActive(false);
        }
        else
        {
            Play.SetActive(true);
            Stop.SetActive(false);
        }
    }
}
