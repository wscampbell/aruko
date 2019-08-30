using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPS : MonoBehaviour
{
    public static GPS instance { set; get; }

    public float latitude { get; private set; }
    public float longitude { get; private set; }
    public float timesStarted = 0;

    private int timesUpdated = 0;

    private void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(StartLocationService());
    }

    // why does this need to return an IEnumerator?
    private IEnumerator StartLocationService()
    {
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("user has not enabled location services");
            yield break;
        }

        Input.location.Start();
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait <= 0)
        {
            Debug.Log("timed out");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("unable to determine device location");
            yield break;
        }

        UpdatePosition();

        timesStarted++;

        yield break;
    }

    public void UpdatePosition()
    {
        // uncomment these to fake the coordinates to always be in Creation Core
        /*
        latitude = (float)34.979536 + 0.0001f * timesUpdated;
        longitude = (float)135.964277;
        timesUpdated++;
        Debug.Log("lat: " + latitude + " lon: " + longitude);
        Debug.Log("times updated: " + timesUpdated);
        */

        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;
    }
}
