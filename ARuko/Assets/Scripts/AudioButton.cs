using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // TODO check if this still makes sense
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

    // TODO does this really need to take place in the Update function?
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
